using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_AimShot : MonoBehaviour
{
	[SerializeField] private float _maxAngle = 90;

	[SerializeField] private float _aimSpeed = 5f;

	//0 = up, - = left, + = right
	private float _aimAngle = 0;

	private float _aimInput = 0;

	public float AimAngle
	{
		get
		{
			return _aimAngle;
		}
		set
		{
			_aimAngle = Math.Clamp(value, -_maxAngle, _maxAngle);
		}
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	protected void Update()
	{
		if (GameStateManager.CurrentState != GameState.AimShot && GameStateManager.CurrentState != GameState.ChargeShot)
		{
			return;
		}

		if (_aimInput == 0)
		{
			return;
		}

		AimAngle += _aimInput * Time.deltaTime * _aimSpeed;

		Messages_AimChanged.AimAngle?.Invoke(AimAngle);
	}

	public void OnAimShot(InputValue inputValue)
	{
		_aimInput = inputValue.Get<float>();
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.StartTurn)
		{
			return;
		}

		_aimAngle = 0;
	}
}
