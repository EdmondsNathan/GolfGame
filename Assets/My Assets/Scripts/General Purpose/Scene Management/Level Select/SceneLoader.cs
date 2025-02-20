using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	private static SceneLoader _instance;

	private SO_SceneReference _nextScene;

	public static SceneLoader Instance
	{
		get
		{
			return _instance;
		}
	}

	public SO_SceneReference NextScene
	{
		get
		{
			return _nextScene;
		}
		private set
		{
			_nextScene = value;
		}
	}

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
		}
	}

	public void LoadScene(SO_SceneReference sceneReference)
	{
		SceneManager.LoadScene(sceneReference.SceneName);
	}

	public void LoadNextScene()
	{
		LoadScene(NextScene);
	}

	public void SetNextScene(SO_SceneReference nextScene)
	{
		NextScene = nextScene;
	}
}
