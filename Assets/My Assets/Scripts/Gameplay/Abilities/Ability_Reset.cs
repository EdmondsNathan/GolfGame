using System.Collections.Generic;
using UnityEngine;

public class Ability_Reset : Ability_Base
{
	[SerializeField] private int _cooldown = 1;

	private int _currentCooldown;

	private bool _isAvailable = true;

	protected void Awake()
	{
		_activeStates = new List<GameState> { GameState.BallMoving };

		_currentCooldown = _cooldown;
	}

	public override void OnStateEnter(GameState oldState, GameState newState)
	{
		base.OnStateEnter(oldState, newState);

		if (newState != GameState.EndTurn)
		{
			return;
		}

		if (_isAvailable == true)
		{
			return;
		}

		_currentCooldown--;

		if (_currentCooldown <= 0)
		{
			_isAvailable = true;

			_currentCooldown = _cooldown;
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

		//ResetBall.Instance.ResetTurn(false);
		Messages_ResetTimer.OnReset?.Invoke(false);

		_isAvailable = _currentCooldown <= 0;
	}
}
