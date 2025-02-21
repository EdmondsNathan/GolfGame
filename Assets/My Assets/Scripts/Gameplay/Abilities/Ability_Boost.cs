using System.Collections.Generic;
using UnityEngine;

public class Ability_Boost : Ability_SingleUse
{
	[SerializeField] private float _boostForce;

	protected override void UseAbility()
	{
		GetGolfBall.Rigidbody_GolfBall.AddForce(_boostForce * GetGolfBall.Rigidbody_GolfBall.linearVelocity.normalized, ForceMode2D.Impulse);
	}
}
