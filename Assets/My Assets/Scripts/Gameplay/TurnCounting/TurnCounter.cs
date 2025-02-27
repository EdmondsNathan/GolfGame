using UnityEngine;

public class TurnCounter : MonoBehaviour
{
	#region Fields
	//private static TurnCounter _instance;

	private int _turnCount = 1;
	#endregion

	#region Properties
	public int TurnCount
	{
		get
		{
			return _turnCount;
		}
		private set
		{
			_turnCount = value;
		}
	}
	#endregion

	#region Unity methods
	protected void Start()
	{
		Messages_TurnCountChanged.OnTurnCountChanged?.Invoke(TurnCount);
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
	#endregion

	#region Event listener methods
	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.EndTurn)
		{
			TurnCount++;

			Messages_TurnCountChanged.OnTurnCountChanged?.Invoke(TurnCount);
		}
	}

	public void OnTurnCountChanged(int turnCount)
	{
		TurnCount = turnCount;
	}
	#endregion
}