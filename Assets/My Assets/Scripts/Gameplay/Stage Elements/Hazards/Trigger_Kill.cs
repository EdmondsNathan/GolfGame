using UnityEngine;

public class Trigger_Kill : MonoBehaviour
{
	[SerializeField] private bool _destroyObjects = false;

	protected void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject == GetGolfBall.GameObject_GolfBall)
		{
			if (GameManager.CurrentState != GameState.BallMoving)
			{
				return;
			}

			//ResetBall.Instance.ResetTurn();

			Messages_Reset.OnTurnReset?.Invoke(true);

			return;
		}

		if (_destroyObjects == true)
		{
			//Destroy(collider.gameObject);

			collider.gameObject.SetActive(false);
		}
	}
}
