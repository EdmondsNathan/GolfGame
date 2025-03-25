using UnityEngine;

public class UFO_TakeDamageOnGolfBallHit : MonoBehaviour
{
	#region Fields
	[SerializeField] private UFO_Health _healthObject;

	[SerializeField] private float _maxDamage;

	[SerializeField] private float _minVelocity;

	[SerializeField] private float _maxVelocity;

	[SerializeField] private float _golfBallDamageMultiplier;
	#endregion

	#region Unity methods
	protected void OnCollisionEnter2D(Collision2D collision)
	{
		float vel = collision.relativeVelocity.magnitude;

		if (vel < _minVelocity)
		{
			return;
		}

		float damage = Mathf.Clamp((vel / _maxVelocity) * _maxDamage, 0, _maxDamage);
		if (collision.transform.ContainsTag(Tag.GolfBall))
		{
			damage *= _golfBallDamageMultiplier;
		}

		_healthObject.CurrentHealth -= damage;
	}
	#endregion
}
