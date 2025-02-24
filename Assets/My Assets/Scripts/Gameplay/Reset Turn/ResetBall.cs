using System;
using UnityEngine;

[Obsolete]
public class ResetBall : MonoBehaviour
{
	private Vector2 _lastPosition;

	private Quaternion _lastRotation;

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_Reset.OnTurnReset += ResetTurn;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_Reset.OnTurnReset -= ResetTurn;
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.ShootBall)
		{
			_lastPosition = GetGolfBall.Transform_GolfBall.position;

			_lastRotation = GetGolfBall.Transform_GolfBall.rotation;
		}
	}

	//StartTurn will prevent the turn count from increasing, EndTurn will increase the turn count
	public void ResetTurn(bool countTurn)
	{
		GetGolfBall.Rigidbody_GolfBall.linearVelocity = Vector2.zero;

		GetGolfBall.Rigidbody_GolfBall.angularVelocity = 0;

		GetGolfBall.Transform_GolfBall.position = _lastPosition;

		GetGolfBall.Transform_GolfBall.rotation = _lastRotation;
	}
}
