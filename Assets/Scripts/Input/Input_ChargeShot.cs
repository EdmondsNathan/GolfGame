using UnityEngine;
using UnityEngine.InputSystem;

public class Input_ChargeShot : MonoBehaviour
{
	private bool _isChargeHeld = false;

	public void OnChargeShot(InputValue inputValue)
	{
		_isChargeHeld = inputValue.isPressed;

		//insert message here if needed

		if (_isChargeHeld == false && GameManager.CurrentState == GameState.ChargeShot)
		{
			GameManager.CurrentState = GameState.ShootBall;
		}
		else if (_isChargeHeld == true && GameManager.CurrentState == GameState.AimShot)
		{
			GameManager.CurrentState = GameState.ChargeShot;
		}
	}

	public void OnCancelCharge(InputValue inputValue)
	{
		if (GameManager.CurrentState != GameState.ChargeShot)
		{
			return;
		}

		if (inputValue.isPressed == false)
		{
			return;
		}

		GameManager.CurrentState = GameState.AimShot;
	}
}
