using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

[Obsolete]
public abstract class SaveManager_Async_Base<T> where T : new()
{
	#region Public methods
	public static async Task SaveAsync(string saveName, T saveObject)
	{
		await File.WriteAllTextAsync(SavePath(saveName), JsonOutput(saveObject));
	}

	public static async Task<T> LoadAsync(string saveName)
	{
		if (File.Exists(SavePath(saveName)) == false)
		{
			return new();
		}

		return JsonConvert.DeserializeObject<T>(await File.ReadAllTextAsync(SavePath(saveName)));
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
