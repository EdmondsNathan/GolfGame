using System.Collections.Generic;
using UnityEngine;

public class Ability_Grapple : Ability_SingleUse
{
	[SerializeField] SO_GrappleJoint _grappleJoint;

	private Joint2D _joint;

	/*protected void Start()
	{
		_joint = _grappleJoint.AddJoint(GetGolfBall.GameObject_GolfBall);
	}*/

	protected override void UseAbility()
	{

	}
}
