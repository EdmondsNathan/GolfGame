using UnityEngine;
using UnityEngine.InputSystem;

public class ChargeShot_PingPong : ChargeShot_Base
{
	#region Fields
	[SerializeField] private float _speed;

	//private float _startingTime;

	private float _pingPongValue = 0;

	private int _direction = 1;
	#endregion

	#region Overriden methods
	protected override void ChargeShot()
	{
		//_pingPongValue = Mathf.PingPong((Time.unscaledTime - _startingTime) * _speed, _maxCharge - _minCharge);

		_pingPongValue += Time.unscaledDeltaTime * _speed * _direction;

		if (_pingPongValue >= 1)
		{
			_pingPongValue = 1;

			_direction *= -1;
		}
		else if (_pingPongValue <= 0)
		{
			_pingPongValue = 0;

			_direction *= -1;
		}

		CurrentCharge = _pingPongValue * (_maxCharge - _minCharge) + _minCharge;
	}
	#endregion

	#region Event listener methods
	public override void OnStateEnter(GameState oldState, GameState newState)
	{
		base.OnStateEnter(oldState, newState);

		if (newState != GameState.ChargeShot)
		{
			return;
		}

		_pingPongValue = 0;

		//_startingTime = Time.unscaledTime;
	}
	#endregion
}
