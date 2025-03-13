using UnityEngine;

public class Ability_Rocket : Ability_SingleUse
{
	#region Fields
	[SerializeField] private GameObject _rocketPrefab;

	//[SerializeField] private float _velocity;
	#endregion

	#region Overriden methods
	protected override void UseAbility()
	{
		Vector2 velocity = GetGolfBall.Rigidbody_GolfBall.linearVelocity;

		//velocity += velocity.normalized * _velocity;

		var rocket = Instantiate<GameObject>(_rocketPrefab, GetGolfBall.Transform_GolfBall.position, Quaternion.Euler(0, 0, Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg));

		rocket.GetComponent<Rigidbody2D>().linearVelocity = velocity;
	}
	#endregion
}