using UnityEngine;

public class ResetBall : MonoBehaviour
{
	public static ResetBall Instance;

	private Vector2 _lastPosition;

	//private int _turnCount = 1;

	protected void Awake()
	{
		Instance = this;
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		//Messages_TurnCountChanged.OnTurnCountChanged += OnTurnCountChanged;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		//Messages_TurnCountChanged.OnTurnCountChanged += OnTurnCountChanged;
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.ShootBall)
		{
			_lastPosition = GetGolfBall.Transform_GolfBall.position;
		}
	}

	//StartTurn will prevent the turn count from increasing, EndTurn will increase the turn count
	public void ResetTurn(bool countTurn = true)
	{
		GetGolfBall.Rigidbody_GolfBall.linearVelocity = Vector2.zero;

		GetGolfBall.Rigidbody_GolfBall.angularVelocity = 0;

		GetGolfBall.Rigidbody_GolfBall.transform.position = _lastPosition;

		// GameManager.CurrentState = nextState;

		GameManager.CurrentState = countTurn ? GameState.EndTurn : GameState.StartTurn;
	}

	/*public void OnTurnCountChanged(int turnCount)
	{
		_turnCount = turnCount;
	}*/
}
