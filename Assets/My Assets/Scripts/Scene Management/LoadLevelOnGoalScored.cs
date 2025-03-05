using System.Collections;
using UnityEngine;

public class LoadLevelOnGoalScored : MonoBehaviour
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
			//SceneLoader.Instance.LoadNextScene();

			StartCoroutine(LoadSceneNextFrame());
		}
	}

	IEnumerator LoadSceneNextFrame()
	{
		yield return null;

		SceneLoader.Instance.LoadNextScene();
	}
}
