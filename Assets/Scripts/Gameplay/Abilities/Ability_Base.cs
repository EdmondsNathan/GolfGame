using System.Collections.Generic;
using UnityEngine;

public abstract class Ability_Base : MonoBehaviour
{
	protected List<GameState> _activeStates;

	protected bool _isActiveState = false;

	protected bool _isPressed = false;

	protected virtual void OnEnable()
	{
		_isActiveState = false;

		_isPressed = false;

		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_UseAbility.OnUseAbilityPressed += OnUseAbilityPressed;
	}

	protected virtual void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_UseAbility.OnUseAbilityPressed -= OnUseAbilityPressed;
	}

	public virtual void OnStateEnter(GameState oldState, GameState newState)
	{
		if (_activeStates.Contains(newState) == false)
		{
			_isActiveState = false;

			return;
		}

		_isActiveState = true;
	}

	public virtual void OnUseAbilityPressed(bool isPressed)
	{
		_isPressed = isPressed;
	}
}
