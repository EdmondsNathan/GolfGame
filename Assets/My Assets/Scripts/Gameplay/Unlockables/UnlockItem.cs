using UnityEngine;

public class UnlockItem : MonoBehaviour
{
	#region Fields
	[SerializeField] private Unlockables unlockable;
	#endregion

	#region Public methods
	public void Unlock(Unlockables unlock)
	{
		SaveManager_Unlockables.Unlock(unlock);
	}

	public void Unlock()
	{
		Unlock(unlockable);
	}
	#endregion
}
