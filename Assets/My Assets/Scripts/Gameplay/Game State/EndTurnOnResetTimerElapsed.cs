using UnityEngine;

public class EndTurnOnResetTimerElapsed : MonoBehaviour
{
	protected void OnEnable()
	{
		Messages_ResetTimer.OnResetTimerElapsed += OnTimerElapsed;
	}

	protected void OnDisable()
	{
		Messages_ResetTimer.OnResetTimerElapsed += OnTimerElapsed;
	}

	public void OnTimerElapsed()
	{
		GameManager.CurrentState = GameState.EndTurn;
	}
}
