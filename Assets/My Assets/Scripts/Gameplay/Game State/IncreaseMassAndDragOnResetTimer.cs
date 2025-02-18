using UnityEngine;

public class IncreaseMassAndDragOnResetTimer : MonoBehaviour
{
	[SerializeField] private float _increaseRate = 1;

	private bool _isElapsed = false;

	private float _startingMass, _startingDrag;

	protected void Start()
	{
		_startingMass = GetGolfBall.Rigidbody_GolfBall.mass;

		_startingDrag = GetGolfBall.Rigidbody_GolfBall.linearDamping;
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_ResetTimer.OnTimerElapsed += OnTimerElapsed;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_ResetTimer.OnTimerElapsed -= OnTimerElapsed;
	}

	protected void FixedUpdate()
	{
		if (_isElapsed)
		{
			GetGolfBall.Rigidbody_GolfBall.mass += _increaseRate * Time.fixedDeltaTime;

			//GetGolfBall.Rigidbody_GolfBall.linearDamping += _increaseRate * Time.fixedDeltaTime;
		}
	}

	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.BallMoving)
		{
			_isElapsed = false;

			GetGolfBall.Rigidbody_GolfBall.mass = _startingMass;

			//GetGolfBall.Rigidbody_GolfBall.linearDamping = _startingDrag;
		}
	}

	private void OnTimerElapsed()
	{
		_isElapsed = true;
	}
}
