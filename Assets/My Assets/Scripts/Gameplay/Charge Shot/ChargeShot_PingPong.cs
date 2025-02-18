using UnityEngine;
using UnityEngine.InputSystem;

public class ChargeShot_PingPong : ChargeShot_Base
{
	[SerializeField] private float _speed;

	private float _startingTime;

	private float _pingPongValue = 0;

	protected override void ChargeShot()
	{
		_pingPongValue = Mathf.PingPong((Time.unscaledTime - _startingTime) * _speed, _maxCharge - _minCharge);

		CurrentCharge = _minCharge + _pingPongValue;
	}

	public override void OnStateEnter(GameState oldState, GameState newState)
	{
		base.OnStateEnter(oldState, newState);

		if (newState != GameState.ChargeShot)
		{
			return;
		}

		_pingPongValue = 0;

		_startingTime = Time.unscaledTime;
	}
}
