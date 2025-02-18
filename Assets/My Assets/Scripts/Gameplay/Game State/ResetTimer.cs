using UnityEngine;
using UnityEngine.InputSystem;

public class ResetTimer : MonoBehaviour
{
	[SerializeField] private float _resetTimer = 10f;

	private float _currentTimer = 0;

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	protected void Update()
	{
		if (GameManager.CurrentState != GameState.BallMoving)
		{
			return;
		}

		if (_currentTimer >= _resetTimer)
		{
			return;
		}

		_currentTimer += Time.deltaTime;

		if (_currentTimer >= _resetTimer)
		{
			Messages_ResetTimer.OnTimerElapsed?.Invoke();
		}
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.BallMoving)
		{
			_currentTimer = 0;
		}
	}
}
