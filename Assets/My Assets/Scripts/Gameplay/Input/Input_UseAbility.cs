using UnityEngine;
using UnityEngine.InputSystem;

public class Input_UseAbility : MonoBehaviour
{
	public void OnUseAbility(InputValue inputValue)
	{
		Messages_UseAbility.OnUseAbilityPressed?.Invoke(inputValue.isPressed);
	}
}
