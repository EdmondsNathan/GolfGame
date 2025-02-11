using UnityEngine;

public class ResetBall : MonoBehaviour
{
	public static ResetBall Instance;

	private Vector2 _lastPosition;

	private int _turnCount = 0;

	protected void Awake()
	{
		Instance = this;
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_TurnCountChanged.OnTurnCountChanged += OnTurnCountChanged;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_TurnCountChanged.OnTurnCountChanged += OnTurnCountChanged;
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.ShootBall)
		{
			_lastPosition = transform.position;
		}
	}

	public void ResetTurn(bool increaseTurnCount = true)
	{
		GetGolfBall.Rigidbody_GolfBall.linearVelocity = Vector2.zero;

		GetGolfBall.Rigidbody_GolfBall.angularVelocity = 0;

		GetGolfBall.Rigidbody_GolfBall.transform.position = _lastPosition;

		GameManager.CurrentState = GameState.StartTurn;

		if (increaseTurnCount == false)
		{
			_turnCount--;

			Messages_TurnCountChanged.OnTurnCountChanged?.Invoke(_turnCount);
		}
	}

	public void OnTurnCountChanged(int turnCount)
	{
		_turnCount = turnCount;
	}
}
