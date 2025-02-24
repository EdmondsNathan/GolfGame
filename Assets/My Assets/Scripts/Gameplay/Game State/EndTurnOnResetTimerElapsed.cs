using UnityEngine;

public class EndTurnOnResetTimerElapsed : MonoBehaviour
{
	protected void OnEnable()
	{
		Messages_Reset.OnResetTimerElapsed += OnResetTimerElapsed;
	}

	protected void OnDisable()
	{
		Messages_Reset.OnResetTimerElapsed += OnResetTimerElapsed;
	}

	public void OnResetTimerElapsed()
	{
		GameManager.CurrentState = GameState.EndTurn;
	}
}
