using System;
using UnityEngine;

[Obsolete]
public class Camera_FlyBackWhenSleeping : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _maxSpeed;

	[SerializeField] private float _acceleration;

	private float _currentSpeed;

	private float _cameraZ;

	private bool _isActive = true;

	private bool _isSleeping = true;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_cameraZ = transform.position.z;
	}

	protected void OnEnable()
	{
		Messages_MoveCamera.OnMoveCamera += OnMoveCamera;
	}

	protected void OnDisable()
	{
		Messages_MoveCamera.OnMoveCamera -= OnMoveCamera;
	}

	protected void LateUpdate()
	{
		if (_isActive == false)
		{
			if (_isSleeping == false)
			{
				if (GetGolfBall.Rigidbody_GolfBall.IsSleeping() == true)
				{
					_isActive = true;

					_isSleeping = true;

					_currentSpeed = 0;
				}
			}

			return;
		}

		if (GetGolfBall.Rigidbody_GolfBall.IsSleeping() == false)
		{
			_isSleeping = false;

			_isActive = false;

			return;
		}

		_currentSpeed = Mathf.Lerp(_currentSpeed, _maxSpeed, _acceleration * Time.deltaTime);

		transform.position = Vector2.Lerp(transform.position, GetGolfBall.Transform_GolfBall.position, _maxSpeed * Time.deltaTime);

		transform.position += Vector3.forward * _cameraZ;
	}
	#endregion

	#region Event listener methods
	public void OnMoveCamera(Vector2 movement)
	{
		if (GameManager.CurrentState != GameState.AimShot && GameManager.CurrentState != GameState.ChargeShot)
		{
			return;
		}

		_isActive = false;
	}
	#endregion
}
