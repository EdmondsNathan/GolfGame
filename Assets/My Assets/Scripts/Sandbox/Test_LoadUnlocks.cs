using UnityEngine;

public class Test_LoadUnlocks : MonoBehaviour
{
	#region Fields
	SaveObject_Unlockables unlocks;
	#endregion

	#region Unity methods
	protected void Start()
	{
		SaveManager_Unlockables.Load(SaveManager_Unlockables.SaveName, out unlocks);

		Debug.Log(unlocks.Unlocks[Unlockables.Ball_Standard]);
		Debug.Log(unlocks.Unlocks[Unlockables.Ball_ZeroG]);

		unlocks.Unlocks[Unlockables.Ball_ZeroG] = true;

		SaveManager_Unlockables.Save(SaveManager_Unlockables.SaveName, unlocks);
	}
	#endregion
}