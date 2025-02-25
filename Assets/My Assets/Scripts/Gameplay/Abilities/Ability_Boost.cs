using System.Collections.Generic;
using UnityEngine;

public class Ability_Boost : Ability_SingleUse
{
	#region Fields
	[SerializeField] private float _boostForce;
	#endregion

	#region Overriden methods
	protected override void UseAbility()
	{
		GetGolfBall.Rigidbody_GolfBall.AddForce(_boostForce * GetGolfBall.Rigidbody_GolfBall.linearVelocity.normalized, ForceMode2D.Impulse);
	}
	#endregion
}
