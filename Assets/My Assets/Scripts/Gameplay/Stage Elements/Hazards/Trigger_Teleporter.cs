using System.Collections.Generic;
using UnityEngine;

public class Trigger_Teleporter : MonoBehaviour
{
	[SerializeField] private Trigger_Teleporter _destination;

	[SerializeField] private bool _isExitOnly = false;

	[SerializeField] private bool _relativeVelocity = true;

	private Rigidbody2D _enteringBody;

	private List<Rigidbody2D> _teleportedBodies = new();

	protected void OnTriggerEnter2D(Collider2D collision)
	{
		if (_isExitOnly == true)
		{
			return;
		}

		if (_teleportedBodies.Contains(collision.attachedRigidbody) == true)
		{
			return;
		}

		if (collision.gameObject.TryGetComponent(out _enteringBody) == false)
		{
			return;
		}

		Messages_BreakGrapple.BreakGrapple?.Invoke();

		_teleportedBodies.Add(_enteringBody);

		_destination._teleportedBodies.Add(_enteringBody);

		_enteringBody.position = _destination.transform.position;

		if (_relativeVelocity == true)
		{
			var velocity = transform.InverseTransformDirection(_enteringBody.linearVelocity);

			_enteringBody.linearVelocity = _destination.transform.TransformDirection(transform.InverseTransformDirection(velocity));
		}

	}

	protected void OnTriggerExit2D(Collider2D collision)
	{
		_teleportedBodies.Remove(collision.attachedRigidbody);
	}
}
