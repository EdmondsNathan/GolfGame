public class SaveManager_Unlockables : SaveManager_Base<SaveObject_Unlockables>
{
	#region Fields
	public static string SaveName = "Unlockables";
	#endregion

	public static void Unlock(Unlockables unlock)
	{
		Load(SaveName, out SaveObject_Unlockables saveObject);

		if (saveObject.Unlocks[unlock] == false)
		{
			Messages_UnlockItem.OnFirstTimeUnlocked?.Invoke(unlock);
		}

		saveObject.Unlocks[unlock] = true;

		Save(SaveName, saveObject);
	}
}