using UnityEngine;

public class ResetTimer : MonoBehaviour
{
	[SerializeField] private float _tooLongTimer = 20f;

	[SerializeField] private float _resetTimer = 60f;

	private float _currentTimer = 0;

	private bool _calledTooLongTimer = false;

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

		if (_calledTooLongTimer == false && _currentTimer >= _tooLongTimer)
		{
			Messages_Reset.OnTooLongTimerElapsed?.Invoke();

			_calledTooLongTimer = true;
		}

		if (_currentTimer >= _resetTimer)
		{
			return;
		}

		_currentTimer += Time.deltaTime;

		if (_currentTimer >= _resetTimer)
		{
			Messages_Reset.OnResetTimerElapsed?.Invoke();
		}
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.BallMoving)
		{
			_currentTimer = 0;

			_calledTooLongTimer = false;
		}
	}
}
