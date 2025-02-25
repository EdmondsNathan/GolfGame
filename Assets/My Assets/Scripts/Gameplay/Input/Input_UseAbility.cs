using UnityEngine;
using UnityEngine.InputSystem;

public class Input_UseAbility : MonoBehaviour
{
	#region Event listener methods
	public void OnUseAbility(InputValue inputValue)
	{
		Messages_UseAbility.OnUseAbilityPressed?.Invoke(inputValue.isPressed);
	}
	#endregion
}
