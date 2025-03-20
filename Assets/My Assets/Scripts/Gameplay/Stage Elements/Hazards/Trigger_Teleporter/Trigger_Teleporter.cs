using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Teleporter : MonoBehaviour
{
	#region Fields
	[SerializeField] private Trigger_Teleporter _destination;

	[SerializeField] private bool _isExitOnly = false;

	[SerializeField] private bool _relativeVelocity = true;

	[SerializeField] private float _reenterDelay = 0.5f;

	private Rigidbody2D _enteringBody;

	private Dictionary<Rigidbody2D, IEnumerator> _rigidbodyDictionary = new();
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	protected void OnTriggerEnter2D(Collider2D collider)
	{
		if (_isExitOnly == true)
		{
			return;
		}

		if (_rigidbodyDictionary.ContainsKey(collider.attachedRigidbody) == true)
		{
			return;
		}

		if (collider.gameObject.TryGetComponent(out _enteringBody) == false)
		{
			return;
		}

		if (collider.ContainsTag(Tag.IgnoreTeleporters))
		{
			return;
		}

		Messages_BreakGrapple.BreakGrapple?.Invoke();

		_rigidbodyDictionary.Add(_enteringBody, ReenterDelay(_enteringBody));

		_destination._rigidbodyDictionary.Add(_enteringBody, _destination.ReenterDelay(_enteringBody));

		_enteringBody.position = _destination.transform.position;

		if (_relativeVelocity == true)
		{
			Vector3 velocity = transform.InverseTransformDirection(_enteringBody.linearVelocity);

			_enteringBody.linearVelocity = _destination.transform.TransformDirection(velocity);
		}

	}

	protected void OnTriggerExit2D(Collider2D collision)
	{
		if (_rigidbodyDictionary.ContainsKey(collision.attachedRigidbody) == true)
		{
			StartCoroutine(_rigidbodyDictionary[collision.attachedRigidbody]);
		}
	}
	#endregion

	#region Event listener methods
	protected void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.StartTurn)
		{
			return;
		}
		foreach (KeyValuePair<Rigidbody2D, IEnumerator> pair in _rigidbodyDictionary)
		{
			StopCoroutine(pair.Value);
		}

		_rigidbodyDictionary.Clear();
	}
	#endregion

	#region Coroutines
	IEnumerator ReenterDelay(Rigidbody2D body)
	{
		yield return new WaitForSeconds(_reenterDelay);

		_rigidbodyDictionary.Remove(body);
	}
	#endregion
}
