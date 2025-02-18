using System;

public static class Messages_GameStateChanged
{
	//oldState, newState
	public static Action<GameState, GameState> OnStateEnter;

	//public static Action<GameState, GameState> OnStateExit;

}
