using UnityEngine;


//Run this after every other script has had a chance to run their Start method
[DefaultExecutionOrder(100)]
public class SetStateOnStart : MonoBehaviour
{
	#region Fields
	[SerializeField] private GameState _startingState = GameState.StartTurn;

	[SerializeField] private bool _sendMessage = true;
	#endregion

	#region Unity methods
	protected void Start()
	{
		//Makes sure that any previous state that might be from another scene doesn't send junk messages
		GameManager.ChangeStateWithoutSendingMessages(_startingState);

		if (_sendMessage == true)
		{
			Messages_GameStateChanged.OnStateEnter?.Invoke(_startingState, _startingState);
		}
	}
	#endregion
}
