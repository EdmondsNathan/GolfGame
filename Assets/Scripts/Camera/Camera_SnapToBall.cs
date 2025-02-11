using UnityEngine;

public class Camera_SnapToBall : MonoBehaviour
{
	private float _cameraZ;

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

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.StartTurn/*  || newState == GameState.ShootBall */)
		{
			SnapToBall();
		}
	}

	private void SnapToBall()
	{
		transform.position = (Vector2)GetGolfBall.Transform_GolfBall.position;

		transform.position += Vector3.forward * _cameraZ;
	}
}
