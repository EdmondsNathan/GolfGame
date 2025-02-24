using UnityEngine;

public class CountTurnOnReset : MonoBehaviour
{
	#region Unity methods
	protected void OnEnable()
	{
		Messages_Reset.OnTurnReset += OnResetTurn;
	}

	protected void OnDisable()
	{
		Messages_Reset.OnTurnReset -= OnResetTurn;
	}
	#endregion

	#region Event listener methods
	private void OnResetTurn(bool countTurn)
	{
		GameManager.CurrentState = countTurn ? GameState.EndTurn : GameState.StartTurn;
	}
	#endregion
}