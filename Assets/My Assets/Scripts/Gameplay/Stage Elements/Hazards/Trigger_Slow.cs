using System.Collections.Generic;
using UnityEngine;

public class Trigger_Slow : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _slowRate = .1f;

	private List<Rigidbody2D> _rigidbodies = new();
	#endregion

	#region Unity methods
	protected void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.TryGetComponent<Rigidbody2D>(out var newRigidbody))
		{
			_rigidbodies.Add(newRigidbody);
		}
	}

	protected void OnTriggerExit2D(Collider2D collider)
	{
		_rigidbodies.Remove(collider.attachedRigidbody);
	}

	protected void FixedUpdate()
	{
		for (int i = _rigidbodies.Count - 1; i >= 0; i--)
		{
			if (_rigidbodies[i] == null || _rigidbodies[i].gameObject.activeSelf == false)
			{
				_rigidbodies.RemoveAt(i);

				continue;
			}

			_rigidbodies[i].linearVelocity *= 1 - (_slowRate * Time.fixedDeltaTime);
		}
	}
	#endregion
}
