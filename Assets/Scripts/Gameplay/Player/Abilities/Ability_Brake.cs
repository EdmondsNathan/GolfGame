using System.Collections.Generic;
using UnityEngine;

public class Ability_Brake : Ability_Base
{
	private bool _isAvailable = true;

	protected void Awake()
	{
		_activeStates = new List<GameState> { GameState.BallMoving };
	}

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

		GetGolfBall.Rigidbody_GolfBall.linearVelocity = Vector2.zero;

		GetGolfBall.Rigidbody_GolfBall.angularVelocity = 0;

		_isAvailable = false;
	}
}
