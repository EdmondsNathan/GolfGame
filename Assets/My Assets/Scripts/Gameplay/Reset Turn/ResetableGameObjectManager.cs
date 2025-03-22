using System.Collections.Generic;
using UnityEngine;

public class ResetableGameObjectManager : SingletonMonoBehaviour<ResetableGameObjectManager>
{
	#region Fields
	private List<ResetableGameObject> _resetables = new();
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_Reset.OnTurnReset += OnTurnReset;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_Reset.OnTurnReset -= OnTurnReset;
	}

	protected void Start()
	{
		foreach (var resetable in FindObjectsByType<ResetableGameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None))
		{
			if (resetable.gameObject.activeSelf == false)
			{
				AddResetable(resetable);
			}
		}
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.AimShot)
		{
			return;
		}

		foreach (var resetable in _resetables)
		{
			SaveResetableObject(resetable);
		}
	}

	private void OnTurnReset(bool countTurn)
	{
		Messages_BreakGrapple.BreakGrapple?.Invoke();

		foreach (var resetable in _resetables)
		{
			ResetObject(resetable);
		}
	}
	#endregion

	#region Public methods
	public void AddResetable(ResetableGameObject resetable)
	{
		if (_resetables.Contains(resetable) == false)
		{
			_resetables.Add(resetable);
		}
	}

	public void RemoveResetable(ResetableGameObject resetable)
	{
		_resetables.Remove(resetable);
	}

	public bool ContainsResetable(ResetableGameObject resetable)
	{
		return _resetables.Contains(resetable);
	}
	#endregion

	#region Private methods
	private void SaveResetableObject(ResetableGameObject resetable)
	{
		resetable.LastPosition = resetable.transform.localPosition;

		resetable.LastRotation = resetable.transform.localRotation;

		resetable.LastScale = resetable.transform.localScale;

		resetable.LastEnabled = resetable.gameObject.activeSelf;

		if (resetable.Body != null)
		{
			resetable.LastLinearVelocity = resetable.Body.linearVelocity;

			resetable.LastAngularVelocity = resetable.Body.angularVelocity;
		}
	}

	private void ResetObject(ResetableGameObject resetable)
	{
		resetable.transform.localPosition = resetable.LastPosition;

		resetable.transform.localRotation = resetable.LastRotation;

		resetable.transform.localScale = resetable.LastScale;

		if (resetable.Body != null)
		{
			resetable.Body.linearVelocity = resetable.LastLinearVelocity;

			resetable.Body.angularVelocity = resetable.LastAngularVelocity;
		}

		resetable.gameObject.SetActive(resetable.LastEnabled);

	}
	#endregion
}
