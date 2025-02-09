using UnityEngine;
using UnityEngine.InputSystem;

public class Input_ChargeShot : MonoBehaviour
{
	private bool _isChargeHeld = false;	

	public void OnChargeShot(InputValue inputValue)
	{
		_isChargeHeld = inputValue.isPressed;

		//insert message here if needed

		if (_isChargeHeld == false && GameStateManager.CurrentState == GameState.ChargeShot)
		{
			GameStateManager.CurrentState = GameState.ShootBall;
		}
		else if (_isChargeHeld == true && GameStateManager.CurrentState == GameState.AimShot)
		{
			GameStateManager.CurrentState = GameState.ChargeShot;
		}
	}

	public void OnCancelCharge(InputValue inputValue)
	{
		if (GameStateManager.CurrentState != GameState.ChargeShot)
		{
			return;
		}

		if (inputValue.isPressed == false)
		{
			return;
		}

		GameStateManager.CurrentState = GameState.AimShot;
	}
}
