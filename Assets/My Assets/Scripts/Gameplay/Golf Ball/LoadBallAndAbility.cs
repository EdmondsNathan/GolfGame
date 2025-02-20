using UnityEngine;

public class LoadBallAndAbility : MonoBehaviour
{
	[SerializeField] private Transform _ballSpawnPoint;

	protected void OnEnable()
	{
		Messages_SetGolfBall.SetGolfBall += SetGolfBall;

		Messages_SetAbility.SetAbility += SetAbility;
	}

	protected void OnDisable()
	{
		Messages_SetGolfBall.SetGolfBall -= SetGolfBall;

		Messages_SetAbility.SetAbility -= SetAbility;
	}

	private void SetGolfBall(GameObject ball)
	{
		GameObject newBall = Instantiate(ball, _ballSpawnPoint.position, Quaternion.identity);

		/*GetGolfBall.GameObject_GolfBall = newBall;

		GetGolfBall.Rigidbody_GolfBall = newBall.GetComponent<Rigidbody2D>();

		GetGolfBall.Transform_GolfBall = newBall.transform;*/
	}

	private void SetAbility(GameObject ability)
	{
		Instantiate(ability);
	}
}
