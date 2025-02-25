using UnityEngine;

public class HasBallLanded : MonoBehaviour
{
	#region Unity methods
	protected void Update()
	{
		if (GameManager.CurrentState != GameState.BallMoving)
		{
			return;
		}

		if (GetGolfBall.Rigidbody_GolfBall.IsSleeping() == true)
		{
			GameManager.CurrentState = GameState.BallLanded;
		}
	}
	#endregion
}