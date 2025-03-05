public class UnlockHandler : SingletonMonoBehaviour<UnlockHandler>
{
	#region Unity methods
	protected void OnEnable()
	{
		Messages_UnlockItem.OnItemUnlocked += OnItemUnlocked;
	}

	protected void OnDisable()
	{
		Messages_UnlockItem.OnItemUnlocked -= OnItemUnlocked;
	}
	#endregion

	#region Event listener methods
	private void OnItemUnlocked(Unlockables unlock)
	{
		//Load from savemanager_unlockables and then overwrite the dictionary for unlock and then save it back

	}