using UnityEngine;

public class Ability_Brake : Ability_Base
{
	[SerializeField] private Rigidbody2D _golfBallRigidbody;
	private bool _isAvailable = true;

	public override void OnStateEnter(GameState oldState, GameState newState)
	{
		base.OnStateEnter(oldState, newState);

		if (newState == GameState.StartTurn)
		{
			_isAvailable = true;
		}
	}

	public override void OnUseAbilityPressed(bool isPressed)
	{
		base.OnUseAbilityPressed(isPressed);

		if (_isPressed == false)
		{
			return;
		}

		if (_isActiveState == false)
		{
			return;
		}

		if (_isAvailable == false)
		{
			return;
		}

		_golfBallRigidbody.linearVelocity = Vector2.zero;

		_golfBallRigidbody.angularVelocity = 0;
	}
}
