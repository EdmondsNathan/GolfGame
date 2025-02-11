using UnityEngine;

public class SetGolfBallOnAwake : MonoBehaviour
{
	protected void Awake()
	{
		GetGolfBall.GolfBall = gameObject;
	}
}
