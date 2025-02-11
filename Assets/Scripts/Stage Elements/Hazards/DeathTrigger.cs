using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
	protected void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject == GetGolfBall.GameObject_GolfBall)
		{
			ResetBall.Instance.ResetTurn(GameState.EndTurn);
		}
	}
}
