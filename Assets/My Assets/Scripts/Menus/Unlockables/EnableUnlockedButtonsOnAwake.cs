using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableUnlockedButtonsOnAwake : MonoBehaviour
{
	[Serializable]
	private struct UnlockableButton
	{
		public Unlockables Unlockable;
		public Button UIButton;
	}

	#region Fields
	[SerializeField] private UnlockableButton[] _buttonUnlocks;
	//private Dictionary<Unlockables, Button> _unlockableButtons = new();
	#endregion

	#region Unity methods
	protected void Awake()
	{
		SaveObject_Unlockables saveUnlocks;

		SaveManager_Unlockables.Load(SaveManager_Unlockables.SaveName, out saveUnlocks);

		foreach (UnlockableButton buttonUnlock in _buttonUnlocks)
		{
			buttonUnlock.UIButton.gameObject.SetActive(saveUnlocks.Unlocks[buttonUnlock.Unlockable]);
		}
	}
	#endregion
}
