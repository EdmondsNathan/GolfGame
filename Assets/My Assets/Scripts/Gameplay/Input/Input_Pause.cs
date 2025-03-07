using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Pause : MonoBehaviour
{
	#region Fields
	public void OnPause(InputValue inputValue)
	{
		Messages_Pause.OnPause?.Invoke();
	}
	#endregion
}
