using System.Collections.Generic;
using UnityEngine;

public class Ability_Brake : Ability_SingleUse
{
	#region Overriden methods
	protected override void UseAbility()
	{
		GetGolfBall.Rigidbody_GolfBall.linearVelocity = Vector2.zero;

		GetGolfBall.Rigidbody_GolfBall.angularVelocity = 0;
	}
	#endregion
}
