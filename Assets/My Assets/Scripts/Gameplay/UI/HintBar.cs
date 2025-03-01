using System;
using System.Collections.Generic;
using UnityEngine;

public class HintBar : MonoBehaviour
{
	#region Fields
	[SerializeField] private List<GameObject> _menus;

	[SerializeField] private List<ActiveStates> _activeStates;
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		for (int i = 0; i < _menus.Count; i++)
		{
			_menus[i].SetActive(_activeStates[i].GameStates.Contains(newState));
		}
	}
	#endregion
}

[System.Serializable]
public class ActiveStates
{
	[SerializeField] private List<GameState> _gameStates;

	public List<GameState> GameStates
	{
		get
		{
			return _gameStates;
		}
		set
		{
			_gameStates = value;
		}
	}
}