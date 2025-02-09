using UnityEngine;

public class Test_LogState : MonoBehaviour
{
	protected void Start()
	{
		Messages_GameStateChanged.OnStateEnter += StateEnter;
		Messages_GameStateChanged.OnStateExit += StateExit;
	}

	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			GameStateManager.CurrentState = GameState.AimShot;
		}
	}

	public void StateEnter(GameState oldState, GameState newState)
	{
		Debug.Log("Entering " + newState);
	}

	public void StateExit(GameState oldState, GameState newState)
	{
		Debug.Log("Exiting " + oldState);
	}
}
