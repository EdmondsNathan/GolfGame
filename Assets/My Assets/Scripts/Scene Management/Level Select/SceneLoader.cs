using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	#region Fields
	private static SceneLoader _instance;

	private SO_SceneReference _nextScene;

	private SO_SceneReference _currentScene;
	#endregion

	#region Properties
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

	public SO_SceneReference CurrentScene
	{
		get
		{
			return _currentScene;
		}
	}
	#endregion

	#region Unity methods
	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
		}
	}
	#endregion

	#region Public methods
	public void LoadScene(SO_SceneReference sceneReference)
	{
		SceneManager.LoadScene(sceneReference.Name);
	}

	public void LoadNextScene()
	{
		_currentScene = NextScene;

		LoadScene(NextScene);
	}

	public void SetNextScene(SO_SceneReference nextScene)
	{
		NextScene = nextScene;
	}
	#endregion
}
