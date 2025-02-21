using System.Collections.Generic;
using UnityEngine;

public class Ability_Thrust : Ability_DurationFixedUpdate
{
	[SerializeField] private float _speed = 10;

	private Vector2 _aimVector = new();

	protected override void OnEnable()
	{
		base.OnEnable();
		Messages_AimAbility.OnAimAbility += OnAimAbility;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		Messages_AimAbility.OnAimAbility += OnAimAbility;
	}

	protected void OnAimAbility(Vector2 aimVector)
	{
		_aimVector = aimVector;

		_isUsing = _aimVector != Vector2.zero;
	}

	protected override void UseAbility()
	{
		GetGolfBall.Rigidbody_GolfBall.AddForce(_speed * _aimVector, ForceMode2D.Force);
	}

	/*[SerializeField] private float _thurstDuration = 2;

	[SerializeField] private float _speed = 10;

	private float _currentDuration;

	private Vector2 _aimVector;

	protected void Awake()
	{
		_activeStates = new List<GameState> { GameState.BallMoving };
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		Messages_AimAbility.OnAimAbility += OnAimAbility;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		Messages_AimAbility.OnAimAbility += OnAimAbility;
	}

	protected void FixedUpdate()
	{
		if (_aimVector == Vector2.zero)
		{
			return;
		}

		if (_isActiveState == false)
		{
			return;
		}

		if (_currentDuration >= _thurstDuration)
		{
			return;
		}

		_currentDuration += Time.fixedDeltaTime;

		GetGolfBall.Rigidbody_GolfBall.AddForce(_speed * _aimVector, ForceMode2D.Force);
	}

	public override void OnStateEnter(GameState oldState, GameState newState)
	{
		base.OnStateEnter(oldState, newState);

		if (newState == GameState.BallMoving)
		{
			_currentDuration = 0;
		}
	}

	public void OnAimAbility(Vector2 aimVector)
	{
		_aimVector = aimVector;
	}*/
}
