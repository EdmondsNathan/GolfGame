using System.Collections.Generic;
using UnityEngine;

public abstract class Ability_SingleUse : Ability_Base
{
	#region Fields
	[SerializeField] private int _cooldown = 1;

	protected int _currentCooldown;

	private bool _isAvailable = true;
	#endregion

	#region Unity methods
	protected virtual void Awake()
	{
		_currentCooldown = _cooldown;
	}
	#endregion

	#region Event listener methods
	protected override void OnStateEnter(GameState oldState, GameState newState)
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

	protected override void OnUseAbilityPressed(bool isPressed)
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

		UseAbility();

		Messages_AbilityUsage.OnSingleUseAbilityUsed?.Invoke();

		_isAvailable = _currentCooldown <= 0;
	}
	#endregion

	#region Abstract methods
	protected abstract void UseAbility();
	#endregion
}
