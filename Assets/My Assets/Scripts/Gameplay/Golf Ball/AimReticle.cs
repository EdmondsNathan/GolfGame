using System;
using System.Collections.Generic;
using UnityEngine;

public class AimReticle : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _minChargeDistance, _maxChargeDistance;

	private float _minCharge, _maxCharge;

	private float _currentCharge;

	private float _aimRad;

	private Vector2 _aimVector = new();

	private Vector3 _positionVector = new();

	private float _zPosition;

	private List<GameState> _visibleState = new() { GameState.AimShot, GameState.ChargeShot };
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_zPosition = transform.position.z;
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_AimChanged.OnAimChanged += OnAimChanged;

		Messages_ChargeShot.OnChargeChanged += OnChargeChanged;

		Messages_ChargeShot.OnMinAndMaxChargeSet += OnMinAndMaxChargeSet;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_AimChanged.OnAimChanged -= OnAimChanged;

		Messages_ChargeShot.OnChargeChanged -= OnChargeChanged;

		Messages_ChargeShot.OnMinAndMaxChargeSet -= OnMinAndMaxChargeSet;
	}

	protected void Update()
	{
		if (GameManager.CurrentState == GameState.AimShot || GameManager.CurrentState == GameState.ChargeShot)
		{
			UpdatePosition(_currentCharge, _aimVector);
		}
	}
	#endregion

	#region Event listener methods
	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.StartTurn)
		{
			_aimVector = Vector2.up;
		}
		else if (newState == GameState.AimShot)
		{
			_currentCharge = _minCharge;

			UpdatePosition(_currentCharge, _aimVector);
		}

		GetComponent<Renderer>().enabled = _visibleState.Contains(newState);
	}

	private void OnAimChanged(float aimAngle)
	{
		_aimRad = aimAngle * Mathf.Deg2Rad;

		_aimVector.x = Mathf.Cos(_aimRad);

		_aimVector.y = Mathf.Sin(_aimRad);
	}

	private void OnChargeChanged(float charge)
	{
		//_currentCharge = (charge - _minCharge) / (_maxCharge - _minCharge);
		_currentCharge = charge;
	}

	private void OnMinAndMaxChargeSet(float min, float max)
	{
		_minCharge = min;

		_maxCharge = max;

		_currentCharge = min;
	}
	#endregion

	#region Private methods
	private void UpdatePosition(float charge, Vector2 vector)
	{
		_positionVector = Mathf.Lerp(_minChargeDistance, _maxChargeDistance, (charge - _minCharge) / (_maxCharge - _minCharge)) * vector + (Vector2)GetGolfBall.Transform_GolfBall.position;

		_positionVector.z = _zPosition;

		transform.position = _positionVector;
	}
	#endregion
}
