using UnityEngine;

public class PauseTimeWhileAiming : MonoBehaviour
{
	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.StartTurn)
		{
			Time.timeScale = 0f;
		}
		else if (newState == GameState.ShootBall)
		{
			Time.timeScale = 1f;
		}

		Debug.Log(Time.timeScale);
	}
}
