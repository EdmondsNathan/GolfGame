using UnityEngine;

public class IncreaseMassAndDragOnTooLongTimer : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _MassIncreaseRate = 1;

	[SerializeField] private float _dragIncreaseRate = 0f;

	private bool _isElapsed = false;

	private float _startingMass, _startingDrag;
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_Reset.OnTooLongTimerElapsed += OnTooLongTimerElapsed;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_Reset.OnTooLongTimerElapsed -= OnTooLongTimerElapsed;

		ResetMassAndDrag();
	}

	protected void Start()
	{
		_startingMass = GetGolfBall.Rigidbody_GolfBall.mass;

		_startingDrag = GetGolfBall.Rigidbody_GolfBall.linearDamping;
	}

	protected void FixedUpdate()
	{
		if (_isElapsed)
		{
			GetGolfBall.Rigidbody_GolfBall.mass += _MassIncreaseRate * Time.fixedDeltaTime;

			GetGolfBall.Rigidbody_GolfBall.linearDamping += _dragIncreaseRate * Time.fixedDeltaTime;
		}
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.BallMoving)
		{
			_isElapsed = false;

			ResetMassAndDrag();
		}
	}

	private void OnTooLongTimerElapsed()
	{
		_isElapsed = true;
	}
	#endregion

	#region Private methods
	private void ResetMassAndDrag()
	{
		if (GetGolfBall.Rigidbody_GolfBall == null)
		{
			return;
		}

		GetGolfBall.Rigidbody_GolfBall.mass = _startingMass;

		GetGolfBall.Rigidbody_GolfBall.linearDamping = _startingDrag;
	}
	#endregion
}
