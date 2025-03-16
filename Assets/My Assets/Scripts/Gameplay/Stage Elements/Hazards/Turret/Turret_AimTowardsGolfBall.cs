using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret_AimTowardsGolfBall : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _rotationSpeed;

	[SerializeField] private float _minAngle, _maxAngle;

	[SerializeField] private Transform _turretRotator;

	private float _targetAngle, _currentAngle, _parentAngle, _relativeAngle, _clampedTargetAngle, _newAngle;

	private Vector2 _direction = new();
	#endregion

	#region Unity methods
	protected void Update()
	{
		TurnTowardsGolfBall();
	}
	#endregion

	#region Private methods
	private void TurnTowardsGolfBall()
	{
		// Get _direction to the target
		_direction = GetGolfBall.Transform_GolfBall.position - _turretRotator.position;

		// Get the target angle in world space
		_targetAngle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;

		// Get the parent’s world rotation (if exists, otherwise assume 0)
		_parentAngle = _turretRotator.parent.eulerAngles.z;

		// Convert the target angle relative to the parent's rotation
		_relativeAngle = Mathf.DeltaAngle(_parentAngle, _targetAngle);

		// Clamp the relative angle
		_relativeAngle = Mathf.Clamp(_relativeAngle, -_maxAngle, _maxAngle);

		// Convert back to world space
		_clampedTargetAngle = _parentAngle + _relativeAngle;

		// Smoothly rotate towards the clamped angle
		_currentAngle = _turretRotator.eulerAngles.z;
		_newAngle = Mathf.MoveTowardsAngle(_currentAngle, _clampedTargetAngle, Time.deltaTime * _rotationSpeed);

		// Apply the rotation
		_turretRotator.rotation = Quaternion.Euler(0, 0, _newAngle);
	}
	#endregion
}

