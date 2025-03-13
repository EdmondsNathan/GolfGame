using UnityEngine;

public class DisableAfterTimer : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _time;

	[SerializeField] private bool _resetable = true;

	private float _currentTime = 0;

	private float _resetTime;
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
		_currentTime += Time.deltaTime;
		if (_currentTime >= _time)
		{
			gameObject.SetActive(false);
		}
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.ShootBall)
		{
			return;
		}

		_resetTime = _currentTime;
	}

	private void OnTurnReset(bool countTurn)
	{
		if (_resetable == false)
		{
			return;
		}

		_currentTime = _resetTime;
	}
	#endregion
}
