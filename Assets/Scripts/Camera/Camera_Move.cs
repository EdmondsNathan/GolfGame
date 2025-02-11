using UnityEngine;

public class Camera_Move : MonoBehaviour
{
	[SerializeField] private float _maxSpeed = 25;

	[SerializeField] private float _acceleration = .1f;

	private bool _isActiveState = false;

	private Vector3 _movementVector = new();

	private float _currentSpeed = 0;

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_MoveCamera.OnMoveCamera += OnMoveCamera;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_MoveCamera.OnMoveCamera += OnMoveCamera;
	}

	protected void Update()
	{
		if (_isActiveState == false || _movementVector.sqrMagnitude == 0)
		{
			return;
		}

		_currentSpeed = Mathf.Lerp(_currentSpeed, _maxSpeed, _acceleration);

		Debug.Log(_currentSpeed);

		transform.position += _movementVector * _currentSpeed * Time.deltaTime;
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.AimShot || newState == GameState.ChargeShot)
		{
			_isActiveState = true;
		}
		else
		{
			_isActiveState = false;

			_currentSpeed = 0;
		}
	}

	public void OnMoveCamera(Vector2 movement)
	{
		_movementVector = movement;

		if (_movementVector.sqrMagnitude == 0)
		{
			_currentSpeed = 0;
		}
	}
}
