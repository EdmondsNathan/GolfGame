using System.Collections.Generic;
using UnityEngine;

public class Ability_Thrust : Ability_DurationFixedUpdate
{
	#region Fields
	[SerializeField] private float _speed = 10;

	private Vector2 _aimVector = new();
	#endregion

	#region Unity methods
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
	#endregion

	#region Event listener methods
	protected void OnAimAbility(Vector2 aimVector)
	{
		_aimVector = aimVector;

		_isUsing = _aimVector != Vector2.zero;
	}

	protected override void UseAbility_FixedUpdate()
	{
		GetGolfBall.Rigidbody_GolfBall.AddForce(_speed * _aimVector, ForceMode2D.Force);
	}
	#endregion
}
