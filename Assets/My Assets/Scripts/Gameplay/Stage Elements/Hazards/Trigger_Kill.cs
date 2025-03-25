using UnityEngine;

//Shelved: Create an enum to switch between different actions when the golf ball enters the trigger. Reset, Respawn and continue, etc.
public class Trigger_Kill : MonoBehaviour
{
	#region Fields
	[SerializeField] private bool _destroyObjects = false;
	#endregion

	#region Unity methods
	protected void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.ContainsTag(Tag.IgnoreKillboxes))
		{
			return;
		}

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
