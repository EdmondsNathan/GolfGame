using UnityEngine;

public class Camera_SnapToBall : MonoBehaviour
{
	#region Fields
	private float _cameraZ;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_cameraZ = transform.position.z;
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.StartTurn)
		{
			SnapToBall();
		}
	}
	#endregion

	#region Private methods
	private void SnapToBall()
	{
		transform.position = (Vector2)GetGolfBall.Transform_GolfBall.position;

		transform.position += Vector3.forward * _cameraZ;
	}
	#endregion
}
