using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public static class SaveManager
{
	#region Public methods
	public static string Output(SaveObject saveData)
	{
		return JsonConvert.SerializeObject(saveData, Formatting.Indented);
	}

	public static void Save(string saveName, SaveObject saveData)
	{
		File.WriteAllText(SavePath(saveName), Output(saveData));
	}

	public static void OverwriteLevel(string saveName, Save_Level saveLevel)
	{
		SaveObject saveObject;

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

	public static void OverwritePlaylist(string saveName, Save_Playlist savePlaylist)
	{
		SaveObject saveObject;

		if (Load(saveName, out saveObject) == false)
		{
			saveObject.AddPlaylistData(savePlaylist);

			Save(saveName, saveObject);

			return;
		}

		saveObject.RemoveLevelData(savePlaylist.Name);

		saveObject.AddPlaylistData(savePlaylist);

		Save(saveName, saveObject);
	}

	public static bool Load(string saveName, out SaveObject saveObject)
	{
		if (File.Exists(SavePath(saveName)) == false)
		{
			saveObject = new();

			return false;
		}

		saveObject = JsonConvert.DeserializeObject<SaveObject>(File.ReadAllText(SavePath(saveName)));

		return true;
	}

	public static void DeleteSave(string saveName)
	{
		File.Delete(SavePath(saveName));
	}
	#endregion

	#region Private methods
	private static string SavePath(string saveName)
	{
		return Path.Combine(Application.persistentDataPath, saveName) + ".json";
	}
	#endregion
}