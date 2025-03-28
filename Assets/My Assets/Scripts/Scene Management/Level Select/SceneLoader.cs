﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
{
	#region Fields
	[SerializeField] private SO_SceneReference _defaultScene;

	private SO_SceneReference _nextScene;

	private SO_SceneReference _currentScene;
	#endregion

	#region Properties
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

	public SO_SceneReference DefaultScene
	{
		get
		{
			if (_defaultScene == null)
			{
				_defaultScene = Resources.Load<SO_SceneReference>("DefaultScene");
			}

			return _defaultScene;
		}
	}
	#endregion

	#region Unity methods
	protected override void Awake()
	{
		base.Awake();

		transform.parent = null;    //DontDestroyOnLoad only works on for root GameObjects

		DontDestroyOnLoad(this);
	}
	#endregion

	#region Public methods
	public void LoadScene(SO_SceneReference sceneReference)
	{
		SceneManager.LoadScene(sceneReference.Name);
	}

	public void LoadNextScene()
	{
		if (NextScene == null)
		{
			SetNextScene(DefaultScene);
		}

		_currentScene = NextScene;

		LoadScene(NextScene);

		NextScene = null;
	}

	public void SetNextScene(SO_SceneReference nextScene)
	{
		NextScene = nextScene;
	}
	#endregion
}
