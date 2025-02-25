using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_AimShot : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _maxAngle = 90;

	[SerializeField] private float _aimSpeed = 45f;

	[SerializeField] private float _preciseSpeed = 2f;

	private float _currentSpeed = 1f;

	//0 = up, + = left, - = right
	private float _aimAngle = 0;

	private float _aimInput = 0;
	#endregion

	#region Properties
	private float AimAngle
	{
		get
		{
			return _aimAngle;
		}
		set
		{
			_aimAngle = value;

			if (_aimAngle >= 360)
			{
				_aimAngle -= 360;
			}
			else if (_aimAngle <= -360)
			{
				_aimAngle += 360;
			}

			_aimAngle = Math.Clamp(_aimAngle, -_maxAngle, _maxAngle);

			Messages_AimChanged.OnAimChanged?.Invoke(_aimAngle + 90);
		}
	}
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		_currentSpeed = _aimSpeed;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	protected void Update()
	{
		if (GameManager.CurrentState != GameState.AimShot && GameManager.CurrentState != GameState.ChargeShot)
		{
			return;
		}

		if (_aimInput == 0)
		{
			return;
		}

		AimAngle -= _aimInput * Time.unscaledDeltaTime * _currentSpeed;
	}
	#endregion

	#region Event listener methods
	public void OnAimShot(InputValue inputValue)
	{
		_aimInput = inputValue.Get<float>();
	}

	public void OnAimPrecise(InputValue inputValue)
	{
		if (inputValue.isPressed == true)
		{
			_currentSpeed = _preciseSpeed;
		}
		else
		{
			_currentSpeed = _aimSpeed;
		}
	}

	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.StartTurn)
		{
			return;
		}

		AimAngle = 0;
	}
	#endregion
}
