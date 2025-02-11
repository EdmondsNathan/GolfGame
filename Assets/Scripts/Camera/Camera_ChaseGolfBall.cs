using UnityEngine;

[DefaultExecutionOrder(100)]
public class Camera_ChaseGolfBall : MonoBehaviour
{
	[SerializeField] private float _chaseSpeed;

	[SerializeField] private float _maxDistance;

	private float _cameraZ;

	private Vector2 _direction;

	protected void Awake()
	{
		_cameraZ = transform.position.z;
	}

	protected void FixedUpdate()
	{
		if (GameManager.CurrentState != GameState.BallMoving)
		{
			return;
		}

		transform.position = Vector2.Lerp(transform.position, GetGolfBall.Transform_GolfBall.position, _chaseSpeed);

		if (Vector2.Distance(transform.position, GetGolfBall.Transform_GolfBall.position) > _maxDistance)
		{
			transform.position = (Vector2)GetGolfBall.Transform_GolfBall.position + ((Vector2)transform.position - (Vector2)GetGolfBall.Transform_GolfBall.position).normalized * _maxDistance;
		}

		transform.position += Vector3.forward * _cameraZ;
	}
}
