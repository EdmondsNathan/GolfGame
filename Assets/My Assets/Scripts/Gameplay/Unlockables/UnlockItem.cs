using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UnlockItem : MonoBehaviour
{
	#region Fields
	[SerializeField] private Unlockables _unlockable;

	private Queue<Unlockables> _unlockQueue = new();
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

		Messages_Reset.OnTurnReset += OnTurnReset;
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.StartTurn && newState != GameState.GoalScored)
		{
			return;
		}

		if (_unlockQueue.Count == 0)
		{
			return;
		}

		while (_unlockQueue.Count > 0)
		{
			SaveManager_Unlockables.Unlock(_unlockQueue.Dequeue());
		}
	}

	private void OnTurnReset(bool countTurn)
	{
		_unlockQueue.Clear();
	}
	#endregion

	#region Public methods
	public void Unlock(Unlockables unlock)
	{
		_unlockQueue.Enqueue(unlock);
	}

	public void Unlock()
	{
		Unlock(_unlockable);
	}
	#endregion
}
