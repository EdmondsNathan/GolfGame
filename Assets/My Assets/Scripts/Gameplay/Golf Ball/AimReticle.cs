using System;
using System.Collections.Generic;
using UnityEngine;

public class AimReticle : MonoBehaviour
{
	//[SerializeField] private float _distance = 1;

	[SerializeField] private float _minChargeDistance, _maxChargeDistance;

	private float _minCharge, _maxCharge;

	private float _currentCharge;

	private float _aimRad;

	private Vector2 _aimVector = new();

	private Vector3 _positionVector = new();

	private float _zPosition;

	private List<GameState> _visibleState = new() { GameState.AimShot, GameState.ChargeShot };


	protected void Awake()
	{
		_zPosition = transform.position.z;
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_AimChanged.OnAimChanged += OnAimChanged;

		Messages_ChargeShot.OnChargeChanged += OnChargeChanged;

		Messages_ChargeShot.MinAndMaxCharge += MinAndMaxCharge;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_AimChanged.OnAimChanged -= OnAimChanged;

		Messages_ChargeShot.OnChargeChanged -= OnChargeChanged;

		Messages_ChargeShot.MinAndMaxCharge -= MinAndMaxCharge;
	}

	protected void Update()
	{
		if (GameManager.CurrentState == GameState.AimShot || GameManager.CurrentState == GameState.ChargeShot)
		{
			UpdatePosition(_currentCharge, _aimVector);
		}
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.StartTurn)
		{
			_aimVector = Vector2.up;
		}
		else if (newState == GameState.AimShot)
		{
			//transform.position = GetGolfBall.Transform_GolfBall.position;
			_currentCharge = _minCharge;

			UpdatePosition(_minCharge, _aimVector);
		}

		GetComponent<Renderer>().enabled = _visibleState.Contains(newState);
	}

	private void UpdatePosition(float charge, Vector2 vector)
	{
		_positionVector = (Vector2)GetGolfBall.Transform_GolfBall.position + Mathf.Lerp(_minChargeDistance, _maxChargeDistance, (charge - _minCharge) / _maxCharge) * vector;

		_positionVector.z = _zPosition;

		transform.position = _positionVector;
	}

	private void OnAimChanged(float aimAngle)
	{
		_aimRad = aimAngle * Mathf.Deg2Rad;

		_aimVector.x = Mathf.Cos(_aimRad);

		_aimVector.y = Mathf.Sin(_aimRad);
	}

	private void OnChargeChanged(float charge)
	{
		_currentCharge = charge;
	}

	private void MinAndMaxCharge(float min, float max)
	{
		_minCharge = min;

		_maxCharge = max;

		_currentCharge = min;
	}
}
