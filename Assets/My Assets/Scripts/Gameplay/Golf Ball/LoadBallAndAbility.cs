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
	}

	private void OnSetAbility(GameObject ability)
	{
		Instantiate(ability);
	}
	#endregion
}
