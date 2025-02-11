using System.Collections;
using UnityEngine;

public class HasGoalScored : MonoBehaviour
{
	private bool _isGolfBallInGoal = false;

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	protected void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject == GetGolfBall.GameObject_GolfBall)
		{
			_isGolfBallInGoal = true;
		}
	}

	protected void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject == GetGolfBall.GameObject_GolfBall)
		{
			_isGolfBallInGoal = false;
		}
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.BallLanded)
		{
			return;
		}

		if (_isGolfBallInGoal == true)
		{
			StartCoroutine(GoalScored());
		}
	}

	IEnumerator GoalScored()
	{
		yield return null;

		GameManager.CurrentState = GameState.GoalScored;
	}
}
