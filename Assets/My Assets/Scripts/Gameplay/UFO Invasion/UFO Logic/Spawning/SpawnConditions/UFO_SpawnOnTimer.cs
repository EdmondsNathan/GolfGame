using UnityEngine;

public class UFO_SpawnOnTimer : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _spawnTimer;

	private float _currentTimer = 0;

	private float _resetTimer = 0;
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

	protected void Update()
	{
		_currentTimer += Time.deltaTime;

		if (_currentTimer >= _spawnTimer)
		{
			Messages_SpawnUFO.OnSpawnUFO?.Invoke();

			_currentTimer = 0;
		}
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.StartTurn)
		{
			return;
		}

		_resetTimer = _currentTimer;
	}

	private void OnTurnReset(bool countTurn)
	{
		_currentTimer = _resetTimer;
	}
	#endregion
}
