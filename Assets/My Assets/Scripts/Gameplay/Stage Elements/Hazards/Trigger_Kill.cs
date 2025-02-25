using UnityEngine;

public class Trigger_Kill : MonoBehaviour
{
	#region Fields
	[SerializeField] private bool _destroyObjects = false;
	#endregion

	#region Unity methods
	protected void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject == GetGolfBall.GameObject_GolfBall)
		{
			if (GameManager.CurrentState != GameState.BallMoving)
			{
				return;
			}

			Messages_Reset.OnTurnReset?.Invoke(true);

			return;
		}

		if (_destroyObjects == true)
		{
			collider.gameObject.SetActive(false);
		}
	}
	#endregion
}
