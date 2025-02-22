using System.Collections.Generic;
using UnityEngine;

public class ResetableManager : MonoBehaviour
{
	private static ResetableManager _instance;

	private List<ResetableObject> _resetables = new();

	public static ResetableManager Instance
	{
		get
		{
			return _instance;
		}
	}

	protected void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
		}
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_ResetTimer.OnReset += OnReset;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_ResetTimer.OnReset -= OnReset;
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.AimShot)
		{
			foreach (var resetable in _resetables)
			{
				resetable.LastEnabled = resetable.gameObject.activeSelf;
			}
		}
	}

	public void AddResetable(ResetableObject resetable)
	{
		if (_resetables.Contains(resetable) == false)
		{
			_resetables.Add(resetable);
		}
	}

	public void RemoveResetable(ResetableObject resetable)
	{
		_resetables.Remove(resetable);
	}

	public void OnReset(bool countTurn)
	{
		Messages_BreakGrapple.BreakGrapple?.Invoke();

		foreach (var resetable in _resetables)
		{
			resetable.gameObject.SetActive(resetable.LastEnabled);

			resetable.Reset();
		}
	}
}
