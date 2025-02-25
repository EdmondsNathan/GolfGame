using System.Collections.Generic;
using UnityEngine;

public class Trigger_Push : MonoBehaviour
{
	#region Fields
	[SerializeField] private Vector2 _forceDirection = Vector2.up;

	[SerializeField] private float _forceAmount = 5;

	private List<Rigidbody2D> _rigidbodies = new();
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_forceDirection.Normalize();
	}

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
		foreach (Rigidbody2D rb in _rigidbodies)
		{
			rb.AddForce(_forceAmount * transform.TransformDirection(_forceDirection), ForceMode2D.Force);
		}
	}
	#endregion
}
