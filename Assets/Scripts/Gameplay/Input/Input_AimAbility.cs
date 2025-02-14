using UnityEngine;
using UnityEngine.InputSystem;

public class Input_AimAbility : MonoBehaviour
{
	protected void Start()
	{
		Messages_AimAbility.OnAimAbility?.Invoke(Vector2.zero);
	}
	public void OnAimAbility(InputValue inputValue)
	{
		Messages_AimAbility.OnAimAbility?.Invoke(inputValue.Get<Vector2>());
	}
}
