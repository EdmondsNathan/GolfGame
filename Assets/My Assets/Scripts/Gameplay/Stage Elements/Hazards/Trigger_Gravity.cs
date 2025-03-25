using System.Collections.Generic;
using UnityEngine;

public class Trigger_Gravity : MonoBehaviour
{
	#region Fields
	private enum FalloffFormula
	{
		Linear,
		InverseSquare,
		None
	}

	[SerializeField] private Transform _target;

	[SerializeField] private float _forceAmount = 5;

	[SerializeField] private bool _ignoreMass = false;

	[SerializeField] private FalloffFormula _fallOffFormula = FalloffFormula.InverseSquare;

	[SerializeField] private float _falloffStrength = 1;

	private List<Rigidbody2D> _rigidbodies = new();

	private Vector2 _forceDirection = new();
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

			_forceDirection = ((Vector2)_target.position - _rigidbodies[i].position).normalized;

			_forceDirection *= _fallOffFormula switch
			{
				FalloffFormula.Linear => _falloffStrength / (1 + Vector2.Distance(_rigidbodies[i].position, _target.position)),

				FalloffFormula.InverseSquare => _falloffStrength / (1 + Mathf.Pow(Vector2.Distance(_rigidbodies[i].position, _target.position), 2)),

				_ => 1
			};

			_forceDirection *= _ignoreMass ? _rigidbodies[i].mass : 1;

			_rigidbodies[i].AddForce(_forceAmount * _forceDirection, ForceMode2D.Force);
		}
	}
	#endregion
}
