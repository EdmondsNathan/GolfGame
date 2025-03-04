using System.Linq;

public static class SaveObjectExtensions
{
	#region Extension methods
	public static bool IsSaveLevelBetterThanSave(this SaveObject_Level save_Level, string saveName)
	{
		SaveObject_HighScore loadedSaveObject;

		if (HighScoreSaveManager.Load(saveName, out loadedSaveObject) == false)
		{
			return true;
		}

		SaveObject_Level loadedSaveLevel;

		if (loadedSaveObject.GetLevelData(save_Level.Name, out loadedSaveLevel) == false)
		{
			return true;
		}

		//We know at this point that a save for this level exists
		return save_Level.IsSaveLevelScoreBetter(loadedSaveLevel);
	}

	public static bool IsSaveLevelScoreBetter(this SaveObject_Level save_Level, SaveObject_Level compareToLevel)
	{
		if (save_Level.Score < compareToLevel.Score)
		{
			return true;
		}
		else if (save_Level.Score > compareToLevel.Score)
		{
			return false;
		}

		//Scores are equal, time to compare other stats
		if (save_Level.GameTimeTaken < compareToLevel.GameTimeTaken)
		{
			return true;
		}
		else if (save_Level.GameTimeTaken > compareToLevel.GameTimeTaken)
		{
			return false;
		}

		//Somehow the game times are equal, resort to real time
		return save_Level.RealTimeTaken <= compareToLevel.RealTimeTaken;
	}

	public static bool IsSavePlaylistBetterThanSave(this SaveObject_Playlist save_Playlist, string saveName)
	{
		SaveObject_HighScore loadedSaveObject;

		if (HighScoreSaveManager.Load(saveName, out loadedSaveObject) == false)
		{
			return true;
		}

		SaveObject_Playlist loadedSavePlaylist;

		if (loadedSaveObject.GetPlaylistData(save_Playlist.Name, out loadedSavePlaylist) == false)
		{
			return true;
		}

		//We know at this point that a save for this playlist exists
		return save_Playlist.IsSavePlaylistScoreBetter(loadedSavePlaylist);
	}

	public static bool IsSavePlaylistScoreBetter(this SaveObject_Playlist save_Playlist, SaveObject_Playlist compareToPlaylist)
	{
		if (save_Playlist.ScoreSum() < compareToPlaylist.ScoreSum())
		{
			return true;
		}
		else if (save_Playlist.ScoreSum() > compareToPlaylist.ScoreSum())
		{
			return false;
		}

		//Scores are equal, time to compare other stats
		if (save_Playlist.GameTimeSum() < compareToPlaylist.GameTimeSum())
		{
			return true;
		}
		else if (save_Playlist.GameTimeSum() > compareToPlaylist.GameTimeSum())
		{
			return false;
		}

		//Somehow the game times are equal, resort to real time
		return save_Playlist.RealTimeSum() <= compareToPlaylist.RealTimeSum();
	}

	public static int ScoreSum(this SaveObject_Playlist save_Playlist)
	{
		return save_Playlist.Levels.Sum(level => level.Score);
	}

	public static float RealTimeSum(this SaveObject_Playlist save_Playlist)
	{
		return save_Playlist.Levels.Sum(level => level.RealTimeTaken);
	}

	public static float GameTimeSum(this SaveObject_Playlist save_Playlist)
	{
		return save_Playlist.Levels.Sum(level => level.GameTimeTaken);
	}
	#endregion
}