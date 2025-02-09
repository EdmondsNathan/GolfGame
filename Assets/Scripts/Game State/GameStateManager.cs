using System;

public enum GameState
{
	StartTurn,
	AimShot,
	ChargeShot,
	ShootBall,
	BallMoving,
	BallLanded,
	EndTurn
}

public static class GameStateManager
{
	private static GameState _oldState;

	private static GameState _currentState = GameState.StartTurn;

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

			Messages_GameStateChanged.OnStateExit?.Invoke(_oldState, value);

			_currentState = value;

			Messages_GameStateChanged.OnStateEnter?.Invoke(_oldState, value);
		}
	}

	public static void ChangeStateWithoutSendingMessages(GameState newState)
	{
		_currentState = newState;
	}
}