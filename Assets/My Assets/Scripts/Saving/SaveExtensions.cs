using System.Linq;

public static class SaveExtensions
{
	#region Extension methods
	public static bool IsSaveLevelBetterThanSave(this Save_Level save_Level, string saveName)
	{
		SaveObject loadedSaveObject;

		if (SaveManager.Load(saveName, out loadedSaveObject) == false)
		{
			return true;
		}

		Save_Level loadedSaveLevel;

		if (loadedSaveObject.GetLevelData(save_Level.Name, out loadedSaveLevel) == false)
		{
			return true;
		}

		//We know at this point that a save for this level exists
		return save_Level.IsScoreBetter(loadedSaveLevel);
	}

	public static bool IsScoreBetter(this Save_Level save_Level, Save_Level compareToLevel)
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

	public static bool IsSavePlaylistBetterThanSave(this Save_Playlist save_Playlist, string saveName)
	{
		SaveObject loadedSaveObject;

		if (SaveManager.Load(saveName, out loadedSaveObject) == false)
		{
			return true;
		}

		Save_Playlist loadedSavePlaylist;

		if (loadedSaveObject.GetPlaylistData(save_Playlist.Name, out loadedSavePlaylist) == false)
		{
			return true;
		}

		//We know at this point that a save for this playlist exists
		return save_Playlist.IsScoreBetter(loadedSavePlaylist);
	}

	public static bool IsScoreBetter(this Save_Playlist save_Playlist, Save_Playlist compareToPlaylist)
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

	public static int ScoreSum(this Save_Playlist save_Playlist)
	{
		return save_Playlist.Levels.Sum(level => level.Score);
	}

	public static float RealTimeSum(this Save_Playlist save_Playlist)
	{
		return save_Playlist.Levels.Sum(level => level.RealTimeTaken);
	}

	public static float GameTimeSum(this Save_Playlist save_Playlist)
	{
		return save_Playlist.Levels.Sum(level => level.GameTimeTaken);
	}
	#endregion
}