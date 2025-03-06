using System;
using System.Threading.Tasks;

[Obsolete]
public class SaveManager_Async_Unlockables : SaveManager_Async_Base<SaveObject_Unlockables>
{
	#region Fields
	public static string SaveName = "Unlockables";
	#endregion

	public static async Task UnlockAsync(Unlockables unlock)
	{
		SaveObject_Unlockables saveObject = await LoadAsync(SaveName);

		if (saveObject.Unlocks[unlock] == false)
		{
			Messages_UnlockItem.OnFirstTimeUnlocked?.Invoke(unlock);
		}

		saveObject.Unlocks[unlock] = true;

		await SaveAsync(SaveName, saveObject);
	}
}
