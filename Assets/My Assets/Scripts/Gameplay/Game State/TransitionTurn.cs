using System.Collections;
using UnityEngine;

public class TransitionTurn : MonoBehaviour
{
	#region Unity methods
	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		switch (newState)
		{
			case GameState.BallLanded:
				StartCoroutine(ChangeStateNextFrame(GameState.BallLanded, GameState.EndTurn));

				break;

			case GameState.EndTurn:
				StartCoroutine(ChangeStateNextFrame(GameState.EndTurn, GameState.StartTurn));

				break;

			case GameState.StartTurn:
				StartCoroutine(ChangeStateNextFrame(GameState.StartTurn, GameState.AimShot));

				break;
		}
	}
	#endregion

	#region Coroutines
	IEnumerator ChangeStateNextFrame(GameState checkState, GameState nextState)
	{
		yield return null;

		if (GameManager.CurrentState == checkState)
		{
			GameManager.CurrentState = nextState;
		}
	}
	#endregion
}
