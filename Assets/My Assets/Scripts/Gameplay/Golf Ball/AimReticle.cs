using System;
using UnityEngine;

public class AimReticle : MonoBehaviour
{
	//[SerializeField] private float _distance = 1;

	[SerializeField] private float _minChargeDistance, _maxChargeDistance;

	private float _minCharge, _maxCharge;

	private float _charge;

	private float _aimRad;

	private Vector2 _aimVector = new();

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
			transform.position = (Vector2)GetGolfBall.Transform_GolfBall.position + Mathf.Lerp(_minChargeDistance, _maxChargeDistance, (_charge - _minCharge) / _maxCharge) * _aimVector;
		}
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.AimShot)
		{
			transform.position = GetGolfBall.Transform_GolfBall.position;

			_charge = _minCharge;
		}

		GetComponent<Renderer>().enabled = newState == GameState.AimShot || newState == GameState.ChargeShot;
	}

	private void OnAimChanged(float aimAngle)
	{
		_aimRad = aimAngle * Mathf.Deg2Rad;

		_aimVector.x = Mathf.Cos(_aimRad);

		_aimVector.y = Mathf.Sin(_aimRad);
	}

	private void OnChargeChanged(float charge)
	{
		_charge = charge;
	}

	private void MinAndMaxCharge(float min, float max)
	{
		_minCharge = min;

		_maxCharge = max;

		_charge = min;
	}
}
