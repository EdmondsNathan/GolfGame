using UnityEngine;

public class SetTimeScaleAndGameStateOnPause : MonoBehaviour
{
	#region Fields
	private GameState _lastState;

	private float _lastTimeScale;
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_Pause.OnPause += OnPause;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_Pause.OnPause -= OnPause;
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.Paused)
		{
			return;
		}

		// Return to aim shot state if in the charge shot state. Fixes issue with holding charge when pausing
		_lastState = newState == GameState.ChargeShot ? GameState.AimShot : newState;

		if (oldState == GameState.Paused)
		{
			return;
		}

		_lastTimeScale = Time.timeScale;
	}

	private void OnPause()
	{
		if (GameManager.CurrentState == GameState.Paused)
		{
			GameManager.CurrentState = _lastState;

			Time.timeScale = _lastTimeScale;

			return;
		}

		GameManager.CurrentState = GameState.Paused;

		Time.timeScale = 0;
	}
	#endregion
}
