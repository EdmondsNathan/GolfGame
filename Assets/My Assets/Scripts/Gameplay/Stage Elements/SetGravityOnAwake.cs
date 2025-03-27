using UnityEngine;

public class SetGravityOnAwake : SingletonMonoBehaviour<SetGravityOnAwake>
{
	#region Fields
	[SerializeField] private Vector2 _gravity;
	#endregion

	#region Unity methods
	protected override void Awake()
	{
		base.Awake();

		SetGravity(_gravity);
	}
	#endregion

	#region Public methods
	public void SetGravity(Vector2 gravity)
	{
		Physics2D.gravity = gravity;
	}

	public void SetGravity(float gravity)
	{
		SetGravity(Vector2.up * gravity);
	}
	#endregion
}
