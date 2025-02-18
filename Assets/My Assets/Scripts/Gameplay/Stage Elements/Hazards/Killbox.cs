using UnityEngine;

public class Killbox : MonoBehaviour
{
	protected void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject == GetGolfBall.GameObject_GolfBall)
		{
			if (GameManager.CurrentState != GameState.BallMoving)
			{
				return;
			}

			//ResetBall.Instance.ResetTurn();

			Messages_ResetTimer.OnReset?.Invoke(true);
		}
	}
}
