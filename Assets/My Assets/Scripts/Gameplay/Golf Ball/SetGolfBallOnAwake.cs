using UnityEngine;

public class SetGolfBallOnAwake : MonoBehaviour
{
	protected void Awake()
	{
		if (GetGolfBall.GameObject_GolfBall != null)
		{
			return;
		}

		GetGolfBall.GameObject_GolfBall = gameObject;

		GetGolfBall.Rigidbody_GolfBall = GetComponent<Rigidbody2D>();

		GetGolfBall.Transform_GolfBall = transform;
	}
}
