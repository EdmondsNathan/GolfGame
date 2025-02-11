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
		/* if (Input.GetKeyDown(KeyCode.O))
		{
			GameManager.CurrentState = GameState.StartTurn;
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			GameManager.CurrentState = GameState.AimShot;
		} */

		if (Input.GetKeyDown(KeyCode.I))
		{
			Debug.Log(GameManager.CurrentState);
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
