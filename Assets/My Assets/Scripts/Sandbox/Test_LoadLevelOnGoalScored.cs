using UnityEngine;

public class Test_LoadLevelOnGoalScored : MonoBehaviour
{
	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.GoalScored)
		{
			SceneLoader.Instance.LoadNextScene();
		}
	}
}
