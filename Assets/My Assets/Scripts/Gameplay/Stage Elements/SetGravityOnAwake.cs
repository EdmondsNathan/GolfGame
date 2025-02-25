using UnityEngine;

public class SetGravityOnAwake : MonoBehaviour
{
	[SerializeField] private Vector2 _gravity;

	protected void Awake()
	{
		Physics2D.gravity = _gravity;
	}
}
