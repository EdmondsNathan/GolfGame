using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public abstract class SaveManager_Base<T> where T : new()
{
	#region Public methods
	public static void Save(string saveName, T saveObject)
	{
		File.WriteAllText(SavePath(saveName), JsonOutput(saveObject));
	}

	public static bool Load(string saveName, out T saveObject)
	{
		if (File.Exists(SavePath(saveName)) == false)
		{
			saveObject = new();

			return false;
		}

		saveObject = JsonConvert.DeserializeObject<T>(File.ReadAllText(SavePath(saveName)));

		return true;
	}

	public static void DeleteSave(string saveName)
	{
		File.Delete(SavePath(saveName));
	}
	#endregion

	#region Protected methods
	private static string JsonOutput(T saveObject)
	{
		return JsonConvert.SerializeObject(saveObject, Formatting.Indented);
	}

	private static string SavePath(string saveName)
	{
		return Path.Combine(Application.persistentDataPath, saveName) + ".json";
	}
	#endregion
}