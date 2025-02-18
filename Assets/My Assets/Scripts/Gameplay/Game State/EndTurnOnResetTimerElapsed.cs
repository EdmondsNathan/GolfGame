using UnityEngine;

public class EndTurnOnResetTimerElapsed : MonoBehaviour
{
	protected void OnEnable()
	{
		Messages_ResetTimer.OnTimerElapsed += OnTimerElapsed;
	}

	protected void OnDisable()
	{
		Messages_ResetTimer.OnTimerElapsed += OnTimerElapsed;
	}

	public void OnTimerElapsed()
	{
		GameManager.CurrentState = GameState.EndTurn;
	}
}
