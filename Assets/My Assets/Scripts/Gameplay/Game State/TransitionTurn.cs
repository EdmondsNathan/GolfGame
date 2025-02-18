using System.Collections;
using UnityEngine;

public class TransitionTurn : MonoBehaviour
{
	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	public void OnStateEnter(GameState oldState, GameState newState)
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

	IEnumerator ChangeStateNextFrame(GameState checkState, GameState nextState)
	{
		if (GameManager.CurrentState == checkState)
		{
			GameManager.CurrentState = nextState;
		}

		yield return null;
	}
}
