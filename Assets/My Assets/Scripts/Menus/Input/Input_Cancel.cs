using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Cancel : MonoBehaviour
{
	#region Event listener methods
	public void OnCancel(InputValue inputValue)
	{
		Messages_MenuChange.OnGoToPreviousMenu?.Invoke();
	}
	#endregion
}
