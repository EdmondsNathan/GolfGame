using UnityEngine;

public class Test_LogState : MonoBehaviour
{
	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += StateEnter;

		//Messages_GameStateChanged.OnStateExit += StateExit;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= StateEnter;

		//Messages_GameStateChanged.OnStateExit -= StateExit;
	}

	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			Debug.Log(GameManager.CurrentState);
		}
	}

	public void StateEnter(GameState oldState, GameState newState)
	{
		Debug.Log("Entering " + newState);
	}
}
