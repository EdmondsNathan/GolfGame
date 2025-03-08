using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ObjectActiveStates
{
	public GameObject Target;

	public List<GameState> ActiveStates;
}

public class EnableObjectsOnGameState : MonoBehaviour
{
	#region Fields
	[SerializeField]
	private List<ObjectActiveStates> _objects;
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
		foreach (var obj in _objects)
		{
			obj.Target.SetActive(obj.ActiveStates.Contains(newState));
		}
	}
	#endregion
}
