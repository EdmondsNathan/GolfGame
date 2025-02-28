using UnityEngine;

public class Camera_StartTurnFlyBack : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _startSpeed, _endSpeed;

	private float _currentSpeed;

	private float _cameraZ;

	private float _timer = 0;

	private Vector2 _startingPosition;

	private bool _isActive = false;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_cameraZ = transform.position.z;
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	protected void LateUpdate()
	{
		if (_isActive == false)
		{
			return;
		}

		if (_timer * _currentSpeed >= 1)
		{
			GameManager.CurrentState = GameState.StartTurn;

			return;
		}

		_timer += Time.unscaledDeltaTime;

		_currentSpeed = Mathf.Lerp(_startSpeed, _endSpeed, _timer);

		transform.position = Vector2.Lerp(_startingPosition, GetGolfBall.Transform_GolfBall.position, _timer * _currentSpeed);

		transform.position += Vector3.forward * _cameraZ;
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.CameraFlyBack)
		{
			_isActive = false;

			return;
		}

		_isActive = true;

		_timer = 0;

		_startingPosition = transform.position;

		return;
	}
	#endregion
}
