using UnityEngine;

public class TurnCounter : MonoBehaviour
{
	private int _turnCount = 0;

	private int TurnCount
	{
		get
		{
			return _turnCount;
		}
		set
		{
			_turnCount = value;

			Messages_TurnCountChanged.OnTurnCountChanged?.Invoke(_turnCount);
		}
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.StartTurn)
		{
			TurnCount++;
		}
	}
}
