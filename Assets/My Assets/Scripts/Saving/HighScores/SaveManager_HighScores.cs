using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class SaveManager_HighScores : SaveManager_Base<SaveObject_HighScores>
{
	#region Fields
	public static string SaveName = "HighScores";

	public static string CurrentSaveName = "CurrentPlaylist";
	#endregion

	#region Public methods
	public static void OverwriteLevel(string saveName, SaveObject_Level saveLevel)
	{
		SaveObject_HighScores saveObject;

		if (Load(saveName, out saveObject) == false)
		{
			saveObject.AddLevelData(saveLevel);

			Save(saveName, saveObject);

			return;
		}

		saveObject.RemoveLevelData(saveLevel.Name);

		saveObject.AddLevelData(saveLevel);

		Save(saveName, saveObject);
	}

	public static void OverwritePlaylist(string saveName, SaveObject_Playlist savePlaylist)
	{
		SaveObject_HighScores saveObject;

		if (Load(saveName, out saveObject) == false)
		{
			saveObject.AddPlaylistData(savePlaylist);

			Save(saveName, saveObject);

			return;
		}

		saveObject.RemovePlaylistData(savePlaylist.Name);

		saveObject.AddPlaylistData(savePlaylist);

		Save(saveName, saveObject);
	}
	#endregion
}