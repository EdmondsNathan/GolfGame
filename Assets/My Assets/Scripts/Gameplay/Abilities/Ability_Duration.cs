using System.Collections.Generic;
using UnityEngine;

public abstract class Ability_Duration : Ability_Base
{
	[SerializeField] protected float _duration = 2;

	protected float _currentDuration;

	protected bool _isUsing = false;

	public override void OnStateEnter(GameState oldState, GameState newState)
	{
		base.OnStateEnter(oldState, newState);

		if (_isActiveState == true)
		{
			_currentDuration = 0;
		}
	}

	protected bool CanUse()
	{
		if (_isActiveState == false)
		{
			return false;
		}

		if (_currentDuration >= _duration)
		{
			return false;
		}

		if (_isUsing == false)
		{
			return false;
		}

		return true;
	}
	protected abstract void UseAbility();
}
