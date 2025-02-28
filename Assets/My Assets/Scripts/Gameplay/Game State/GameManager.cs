using System;
using UnityEngine;

public enum GameState
{
	StartTurn,
	AimShot,
	ChargeShot,
	ShootBall,
	BallMoving,
	BallLanded,
	EndTurn,
	GoalScored,
	CameraFlyBack
}

public static class GameManager
{
	#region Fields
	private static GameState _oldState;

	private static GameState _currentState = GameState.StartTurn;
	#endregion

	#region Properties
	public static GameState CurrentState
	{
		get
		{
			return _currentState;
		}
		set
		{
			if (value == CurrentState)
			{
				return;
			}

			_oldState = CurrentState;

			_currentState = value;

			Messages_GameStateChanged.OnStateEnter?.Invoke(_oldState, value);
		}
	}
	#endregion

	#region Public methods
	/// <summary>
	/// Should only be used when starting a new level to reset state
	/// </summary>
	/// <param name="newState"></param>
	public static void ChangeStateWithoutSendingMessages(GameState newState)
	{
		_currentState = newState;
	}
	#endregion
}