using System.Collections;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
	/* [SerializeField]  */
	private float _chargeMultiplier = 1;

	public float ChargeMultiplier
	{
		get
		{
			return _chargeMultiplier;
		}
		set
		{
			_chargeMultiplier = value;
		}
	}

	private float _aimAngle;

	private float _aimRad;

	private float _chargeAmount;

	private Vector2 _aimVector;

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_AimChanged.OnAimChanged += OnAimChanged;

		Messages_ChargeShot.OnChargeChanged += OnChargeChanged;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_AimChanged.OnAimChanged -= OnAimChanged;

		Messages_ChargeShot.OnChargeChanged -= OnChargeChanged;
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.ShootBall)
		{
			return;
		}

		_aimRad = _aimAngle * Mathf.Deg2Rad;

		_aimVector.x = Mathf.Cos(_aimRad);

		_aimVector.y = Mathf.Sin(_aimRad);

		GetGolfBall.Rigidbody_GolfBall.AddForce(_chargeAmount * _chargeMultiplier * _aimVector, ForceMode2D.Impulse);

		StartCoroutine(EnterBallMovingState());
	}

	IEnumerator EnterBallMovingState()
	{
		yield return null;

		GameManager.CurrentState = GameState.BallMoving;
	}

	public void OnAimChanged(float angle)
	{
		_aimAngle = angle;
	}

	public void OnChargeChanged(float charge)
	{
		_chargeAmount = charge;
	}
}
