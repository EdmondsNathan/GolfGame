using System.Collections.Generic;
using UnityEngine;

public class ResetableManager : SingletonMonoBehaviour<ResetableManager>
{
	#region Fields
	private List<ResetableObject> _resetables = new();
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_Reset.OnTurnReset += OnResetTurn;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_Reset.OnTurnReset -= OnResetTurn;
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.AimShot)
		{
			foreach (var resetable in _resetables)
			{
				resetable.LastEnabled = resetable.gameObject.activeSelf;
			}
		}
	}

	private void OnResetTurn(bool countTurn)
	{
		Messages_BreakGrapple.BreakGrapple?.Invoke();

		foreach (var resetable in _resetables)
		{
			resetable.gameObject.SetActive(resetable.LastEnabled);

			resetable.Reset();
		}
	}
	#endregion

	#region Public methods
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
	#endregion
}
