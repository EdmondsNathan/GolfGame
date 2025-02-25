using UnityEngine;

public class SetGravityOnAwake : MonoBehaviour
{
	#region Fields
	[SerializeField] private Vector2 _gravity;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		Physics2D.gravity = _gravity;
	}
	#endregion
}
