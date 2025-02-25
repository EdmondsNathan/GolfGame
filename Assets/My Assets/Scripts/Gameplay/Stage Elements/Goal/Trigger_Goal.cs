using System.Collections;
using UnityEngine;

public class Trigger_Goal : MonoBehaviour
{
	#region Unity methods
	protected void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject == GetGolfBall.GameObject_GolfBall)
		{
			GameManager.CurrentState = GameState.GoalScored;
		}
	}
	#endregion
}
