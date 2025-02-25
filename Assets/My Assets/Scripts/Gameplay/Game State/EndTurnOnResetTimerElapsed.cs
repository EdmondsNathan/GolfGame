using UnityEngine;

public class EndTurnOnResetTimerElapsed : MonoBehaviour
{
	#region Unity methods
	protected void OnEnable()
	{
		Messages_Reset.OnResetTimerElapsed += OnResetTimerElapsed;
	}

	protected void OnDisable()
	{
		Messages_Reset.OnResetTimerElapsed += OnResetTimerElapsed;
	}
	#endregion

	#region Event listener methods
	private void OnResetTimerElapsed()
	{
		GameManager.CurrentState = GameState.EndTurn;
	}
	#endregion
}
