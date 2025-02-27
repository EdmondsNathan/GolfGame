using UnityEngine;

//SHELVED: Get grappling hook to work, probably need to rewrite the whole thing
public class Ability_Grapple : Ability_SingleUse
{
	#region Fields
	[SerializeField] SO_GrappleJoint _grappleJoint;

	[SerializeField] private float _duration = 10;

	[SerializeField] private float _range = 5;

	private float _currentDuration = 0;

	private DistanceJoint2D _joint;

	private bool _connected = false;

	private Rigidbody2D _connectedRigidbody;
	#endregion

	#region Unity methods
	protected override void OnEnable()
	{
		base.OnDisable();

		Messages_BreakGrapple.BreakGrapple += Disconnect;
	}

	protected override void OnDisable()
	{
		base.OnDisable();

		Messages_BreakGrapple.BreakGrapple -= Disconnect;
	}

	protected void Start()
	{
		_joint = _grappleJoint.AddJoint(GetGolfBall.GameObject_GolfBall);

		_joint.distance = _range;

		_joint.enabled = false;
	}

	protected void Update()
	{
		if (_connected)
		{
			_currentDuration += Time.deltaTime;

			if (_currentDuration >= _duration)
			{
				Disconnect();
			}
		}
	}
	#endregion

	#region Overriden methods
	protected override void OnStateEnter(GameState oldState, GameState newState)
	{
		base.OnStateEnter(oldState, newState);

		if (newState != GameState.BallMoving)
		{
			Disconnect();

			return;
		}

		if (_isActiveState == true)
		{
			_currentDuration = 0;
		}
	}

	protected override void UseAbility()
	{
		RaycastHit2D[] hits = Physics2D.CircleCastAll(GetGolfBall.Transform_GolfBall.position, _range, Vector2.zero, 0, ~(1 << LayerMask.NameToLayer("GolfBall")));

		float minDist = Mathf.Infinity;

		RaycastHit2D closestHit = hits[0];

		foreach (RaycastHit2D hit in hits)
		{
			if (hit.collider.isTrigger == true)
			{
				continue;
			}

			if (Vector2.Distance(GetGolfBall.Transform_GolfBall.position, hit.point) < minDist)
			{
				minDist = Vector2.Distance(GetGolfBall.Transform_GolfBall.position, hit.point);

				closestHit = hit;
			}
		}

		if (minDist == Mathf.Infinity)
		{
			_currentCooldown++;
			return;
		}

		if (closestHit.collider.TryGetComponent(out _connectedRigidbody) == true)
		{
			_joint.connectedBody = _connectedRigidbody;

			_joint.connectedAnchor = _connectedRigidbody.transform.InverseTransformPoint(closestHit.point);

			transform.position = _connectedRigidbody.transform.InverseTransformPoint(closestHit.point);

		}
		else
		{
			_joint.connectedAnchor = closestHit.point;

			transform.position = closestHit.point;
		}

		_joint.enabled = true;

		_joint.distance = _range;

		_connected = true;
	}
	#endregion

	#region Private methods
	private void Disconnect()
	{
		_joint.enabled = false;

		_joint.connectedBody = null;

		_connected = false;
	}
	#endregion
}
