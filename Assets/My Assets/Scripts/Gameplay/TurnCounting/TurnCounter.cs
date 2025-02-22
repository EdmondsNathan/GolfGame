using UnityEngine;

public class TurnCounter : MonoBehaviour
{
	private int _turnCount = 1;

	protected void Start()
	{
		Messages_TurnCountChanged.OnTurnCountChanged?.Invoke(_turnCount);
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_TurnCountChanged.OnTurnCountChanged += OnTurnCountChanged;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_TurnCountChanged.OnTurnCountChanged -= OnTurnCountChanged;
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.EndTurn)
		{
			_turnCount++;

			Messages_TurnCountChanged.OnTurnCountChanged?.Invoke(_turnCount);
		}
	}

	public void OnTurnCountChanged(int turnCount)
	{
		_turnCount = turnCount;
	}
}