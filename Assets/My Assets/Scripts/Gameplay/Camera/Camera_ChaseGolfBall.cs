using UnityEngine;

[DefaultExecutionOrder(100)]
public class Camera_ChaseGolfBall : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _chaseSpeed;

	[SerializeField] private float _catchUpSpeed;

	[SerializeField] private float _maxDistance;

	private float _currentSpeed;

	private float _cameraZ;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_cameraZ = transform.position.z;
	}

	protected void FixedUpdate()
	{
		if (GameManager.CurrentState != GameState.BallMoving && GameManager.CurrentState != GameState.GoalScored)
		{
			return;
		}

		/* value = distance
		oldMin = 0
		oldMax = maxDistance
		newMin = chasespeed
		newMax = catchupspeed
		(value - oldMin) / (oldMax - oldMin) * (newMax - newMin) + newMin */

		_currentSpeed = Mathf.Clamp((Vector2.Distance(transform.position, GetGolfBall.Transform_GolfBall.position)) / (_maxDistance) * (_catchUpSpeed - _chaseSpeed) + _chaseSpeed, 0, _catchUpSpeed);

		transform.position = Vector2.Lerp(transform.position, GetGolfBall.Transform_GolfBall.position, _currentSpeed);

		transform.position += Vector3.forward * _cameraZ;
	}
	#endregion
}
