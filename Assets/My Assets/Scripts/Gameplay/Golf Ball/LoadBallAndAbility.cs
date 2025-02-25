using UnityEngine;

public class LoadBallAndAbility : MonoBehaviour
{
	#region Fields
	[SerializeField] private Transform _ballSpawnPoint;
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		Messages_SetGolfBall.OnSetGolfBall += OnSetGolfBall;

		Messages_SetAbility.OnSetAbility += OnSetAbility;
	}

	protected void OnDisable()
	{
		Messages_SetGolfBall.OnSetGolfBall -= OnSetGolfBall;

		Messages_SetAbility.OnSetAbility -= OnSetAbility;
	}
	#endregion

	#region Event listener methods
	private void OnSetGolfBall(GameObject ball)
	{
		GameObject newBall = Instantiate(ball, _ballSpawnPoint.position, Quaternion.identity);

		/*GetGolfBall.GameObject_GolfBall = newBall;

		GetGolfBall.Rigidbody_GolfBall = newBall.GetComponent<Rigidbody2D>();

		GetGolfBall.Transform_GolfBall = newBall.transform;*/
	}

	private void OnSetAbility(GameObject ability)
	{
		Instantiate(ability);
	}
	#endregion
}
