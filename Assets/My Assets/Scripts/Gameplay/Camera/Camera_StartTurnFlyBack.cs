using UnityEngine;

public class Camera_StartTurnFlyBack : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _maxSpeed;

	[SerializeField] private float _acceleration;

	private float _currentSpeed = 0;

	private float _cameraZ;

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

		Messages_MoveCamera.OnMoveCamera += OnMoveCamera;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_MoveCamera.OnMoveCamera -= OnMoveCamera;
	}

	protected void LateUpdate()
	{
		if (_isActive == false)
		{
			return;
		}

		if (GameManager.CurrentState != GameState.AimShot && GameManager.CurrentState != GameState.ChargeShot)
		{
			_currentSpeed = 0;

			return;
		}

		_currentSpeed = Mathf.Lerp(_currentSpeed, _maxSpeed, _acceleration * Time.unscaledDeltaTime);

		transform.position = Vector2.Lerp(transform.position, GetGolfBall.Transform_GolfBall.position, _maxSpeed * Time.unscaledDeltaTime);

		transform.position += Vector3.forward * _cameraZ;
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.StartTurn)
		{
			_isActive = true;
		}
	}

	private void OnMoveCamera(Vector2 movement)
	{
		if (GameManager.CurrentState != GameState.AimShot && GameManager.CurrentState != GameState.ChargeShot)
		{
			return;
		}

		_isActive = false;
	}
	#endregion
}
