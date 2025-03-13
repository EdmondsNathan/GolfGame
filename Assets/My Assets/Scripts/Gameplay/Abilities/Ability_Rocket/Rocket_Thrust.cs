using UnityEngine;

public class Rocket_Thrust : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _thrust;

	private Rigidbody2D _rigidbody;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	protected void FixedUpdate()
	{
		_rigidbody.AddRelativeForce(Vector2.right * _thrust * Time.fixedDeltaTime, ForceMode2D.Force);
	}
	#endregion
}