using System.Collections.Generic;
using UnityEngine;

public abstract class Ability_Duration : Ability_Base
{
	#region Fields
	[SerializeField] protected float _maxDuration = 2;

	protected float _currentDuration;

	protected bool _isUsing = false;
	#endregion

	#region Unity methods
	protected void Start()
	{
		Messages_AbilityUsage.OnSetMaxAbilityDuration?.Invoke(_maxDuration);
	}
	#endregion

	#region Overriden methods
	protected override void OnStateEnter(GameState oldState, GameState newState)
	{
		base.OnStateEnter(oldState, newState);

		if (_isActiveState == true)
		{
			_currentDuration = _maxDuration;
		}
	}
	#endregion

	#region Protected methods
	protected bool CanUse()
	{
		if (_isActiveState == false)
		{
			return false;
		}

		if (_currentDuration <= 0)
		{
			return false;
		}

		if (_isPressed == false)
		{
			return false;
		}

		if (_isUsing == false)
		{
			return false;
		}

		return true;
	}
	#endregion
}
