using UnityEngine;
using UnityEngine.InputSystem;

public class Input_AimAbility : MonoBehaviour
{
	#region Event listener methods
	public void OnAimAbility(InputValue inputValue)
	{
		Messages_AimAbility.OnAimAbility?.Invoke(inputValue.Get<Vector2>());
	}
	#endregion
}
