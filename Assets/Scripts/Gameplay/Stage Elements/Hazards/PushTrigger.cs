using System.Collections.Generic;
using UnityEngine;

public class PushTrigger : MonoBehaviour, ISimulationFixedUpdate
{
	[SerializeField] private Vector2 _forceDirection = Vector2.up;

	[SerializeField] private float _forceAmount = 5;

	private List<Rigidbody2D> _rigidbodies = new();

	protected void Awake()
	{
		_forceDirection.Normalize();
	}

	protected void OnTriggerEnter2D(Collider2D collider)
	{
		Rigidbody2D newRigidbody = collider.GetComponent<Rigidbody2D>();

		if (newRigidbody != null)
		{
			_rigidbodies.Add(newRigidbody);
		}
	}

	protected void OnTriggerExit2D(Collider2D collider)
	{
		Rigidbody2D newRigidbody = collider.GetComponent<Rigidbody2D>();

		if (_rigidbodies.Contains(newRigidbody))
		{
			_rigidbodies.Remove(newRigidbody);
		}
	}

	protected void FixedUpdate()
	{
		FixedUpdate_Simulation();
	}

	public void FixedUpdate_Simulation()
	{
		foreach (Rigidbody2D rb in _rigidbodies)
		{
			rb.AddForce(_forceAmount * _forceDirection, ForceMode2D.Force);
		}
	}
}
