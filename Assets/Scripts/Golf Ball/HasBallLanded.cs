using UnityEngine;

public class HasBallLanded : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _golfBallRigidbody;

	protected void Update()
	{
		if (GameManager.CurrentState != GameState.BallMoving)
		{
			return;
		}

		if (_golfBallRigidbody.IsSleeping() == true)
		{
			GameManager.CurrentState = GameState.BallLanded;
		}
	}
}