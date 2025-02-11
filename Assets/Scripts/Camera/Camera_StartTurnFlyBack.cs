using UnityEngine;

public class Camera_StartTurnFlyBack : MonoBehaviour
{
	[SerializeField] private float _maxSpeed;

	[SerializeField] private float _acceleration;

	private float _currentSpeed;

	private float _cameraZ;

	private bool _isActive = false;

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

		_currentSpeed = Mathf.Lerp(_currentSpeed, _maxSpeed, _acceleration * Time.deltaTime);

		transform.position = Vector2.Lerp(transform.position, GetGolfBall.Transform_GolfBall.position, _maxSpeed * Time.deltaTime);

		transform.position += Vector3.forward * _cameraZ;
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.StartTurn)
		{
			_isActive = true;
		}
	}

	public void OnMoveCamera(Vector2 movement)
	{
		if (GameManager.CurrentState != GameState.AimShot && GameManager.CurrentState != GameState.ChargeShot)
		{
			return;
		}

		_isActive = false;
	}
}
