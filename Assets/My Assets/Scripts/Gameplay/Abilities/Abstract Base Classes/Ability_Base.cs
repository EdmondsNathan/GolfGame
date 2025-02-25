using System.Collections.Generic;
using UnityEngine;

public abstract class Ability_Base : MonoBehaviour
{
	#region Fields
	protected List<GameState> _activeStates = new List<GameState> { GameState.BallMoving };

	protected bool _isActiveState = false;

	protected bool _isPressed = false;
	#endregion

	#region Unity methods
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
	#endregion

	#region Event listener methods
	protected virtual void OnStateEnter(GameState oldState, GameState newState)
	{
		_isActiveState = _activeStates.Contains(newState);
	}

	protected virtual void OnUseAbilityPressed(bool isPressed)
	{
		_isPressed = isPressed;
	}
	#endregion
}
