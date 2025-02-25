using UnityEngine;

public class PauseTimeWhileAiming : MonoBehaviour
{
	#region Unity methods
	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.StartTurn)
		{
			Time.timeScale = 0f;
		}
		else if (newState == GameState.ShootBall)
		{
			Time.timeScale = 1f;
		}
	}
	#endregion
}