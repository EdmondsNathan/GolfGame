using UnityEngine;

public class Rocket_Thrust : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _thrust;

	[SerializeField] private float _initialForce;

	private Rigidbody2D _rigidbody;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();

		_rigidbody.AddRelativeForce(Vector2.right * _initialForce, ForceMode2D.Impulse);
	}

	protected void FixedUpdate()
	{
		_rigidbody.AddRelativeForce(Vector2.right * _thrust * Time.fixedDeltaTime, ForceMode2D.Force);
	}
	#endregion
}