using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

[Obsolete]
public static class SaveManager
{
	#region Public methods
	public static void Save(string saveName, SaveObject_HighScores saveData)
	{
		File.WriteAllText(SavePath(saveName), JsonOutput(saveData));
	}

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

	public static bool Load(string saveName, out SaveObject_HighScores saveObject)
	{
		if (File.Exists(SavePath(saveName)) == false)
		{
			saveObject = new();

			return false;
		}

		saveObject = JsonConvert.DeserializeObject<SaveObject_HighScores>(File.ReadAllText(SavePath(saveName)));

		return true;
	}

	public static void DeleteSave(string saveName)
	{
		File.Delete(SavePath(saveName));
	}
	#endregion

	#region Private methods
	private static string JsonOutput(SaveObject_HighScores saveData)
	{
		return JsonConvert.SerializeObject(saveData, Formatting.Indented);
	}

	private static string SavePath(string saveName)
	{
		return Path.Combine(Application.persistentDataPath, saveName) + ".json";
	}
	#endregion
}