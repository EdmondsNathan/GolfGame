using UnityEngine;
using System.Collections.Generic;

public class TrajectoryPreview : MonoBehaviour
{
	[SerializeField] private LineRenderer _lineRenderer;  // Reference to LineRenderer

	[SerializeField] private int _resolution = 30;        // Number of points in the trajectory

	[SerializeField] private int _maxBounces = 3;

	// [SerializeField] private float _timeStep = 0.05f;     // Time between trajectory points

	[SerializeField] private LayerMask _collisionMask;    // Mask to detect collisions

	private int _currentBounces = 0;

	private float _aimAngle;

	private float _chargeAmount;

	private float _chargeMultiplier;

	private float _dragMultiplier;

	private float _distanceToSurface;

	private float _ballRadius;

	private Vector2 _moveDirection;

	private Vector2 _origin;

	private bool _showTrajectory = false;

	protected void OnEnable()
	{
		Messages_AimChanged.OnAimChanged += OnAimChanged;

		Messages_ChargeShot.OnChargeChanged += OnChargeChanged;

		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_AimChanged.OnAimChanged -= OnAimChanged;

		Messages_ChargeShot.OnChargeChanged -= OnChargeChanged;

		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	protected void Start()
	{
		_chargeMultiplier = 1; /* GetGolfBall.GameObject_GolfBall.GetComponent<ShootBall>().ChargeMultiplier; */

		_dragMultiplier = Mathf.Exp(-1 * GetGolfBall.Rigidbody_GolfBall.linearDamping * Time.fixedDeltaTime);

		_ballRadius = GetGolfBall.Transform_GolfBall.localScale.x * 0.5f;
	}

	public void OnAimChanged(float aimAngle)
	{
		_aimAngle = aimAngle;
	}

	public void OnChargeChanged(float chargeAmount)
	{
		_chargeAmount = chargeAmount;

		if (_showTrajectory == true)
		{
			float aimRad = _aimAngle * Mathf.Deg2Rad;

			//DrawTrajectory(GetGolfBall.Transform_GolfBall.position, (_chargeAmount * _chargeMultiplier) * new Vector2(Mathf.Cos(_aimRad), Mathf.Sin(_aimRad)) / GetGolfBall.Rigidbody_GolfBall.mass * Mathf.Exp(-1 * GetGolfBall.Rigidbody_GolfBall.linearDamping * Time.fixedDeltaTime));

			DrawTrajectory(GetGolfBall.Transform_GolfBall.position, _chargeAmount * _chargeMultiplier * new Vector2(Mathf.Cos(aimRad), Mathf.Sin(aimRad)) / GetGolfBall.Rigidbody_GolfBall.mass);
		}
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.ChargeShot)
		{
			_showTrajectory = true;
		}
		else
		{
			_showTrajectory = false;

			//ClearTrajectory();
		}

	}

	private void DrawTrajectory(Vector2 startPosition, Vector2 initialVelocity)
	{
		List<Vector3> points = new();

		Vector2 currentPosition = startPosition;

		Vector2 currentVelocity = initialVelocity;

		_currentBounces = 0;

		for (int i = 0; i < _resolution; i++)
		{
			points.Add(currentPosition);

			// Simulate physics using kinematic equations
			Vector2 nextPosition = currentPosition + currentVelocity * Time.fixedDeltaTime;
			currentVelocity = currentVelocity * _dragMultiplier + GetGolfBall.Rigidbody_GolfBall.gravityScale * Time.fixedDeltaTime * Physics2D.gravity;

			// Check for collision
			//RaycastHit2D hit = Physics2D.Raycast(currentPosition, nextPosition - currentPosition, (nextPosition - currentPosition).magnitude, _collisionMask);

			_moveDirection = nextPosition - currentPosition;

			_origin = currentPosition + _moveDirection.normalized * _ballRadius;

			_distanceToSurface = _moveDirection.magnitude + _ballRadius;

			RaycastHit2D hit = Physics2D.Raycast(_origin, _moveDirection.normalized, _distanceToSurface, _collisionMask);


			if (hit)
			{
				points.Add(hit.point);

				currentVelocity = Vector2.Reflect(currentVelocity, hit.normal) * GetGolfBall.Rigidbody_GolfBall.sharedMaterial.bounciness;

				currentPosition = hit.point + hit.normal * 0.01f;

				if (_currentBounces >= _maxBounces)
				{
					break;
				}

				_currentBounces++;

				continue;
			}

			currentPosition = nextPosition;
		}

		_lineRenderer.positionCount = points.Count;
		_lineRenderer.SetPositions(points.ToArray());
	}

	public void ClearTrajectory()
	{
		_lineRenderer.positionCount = 0;
	}
}
