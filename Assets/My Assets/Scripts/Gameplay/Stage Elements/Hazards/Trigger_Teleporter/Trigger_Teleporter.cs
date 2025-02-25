using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Teleporter : MonoBehaviour
{
	[SerializeField] private Trigger_Teleporter _destination;

	[SerializeField] private bool _isExitOnly = false;

	[SerializeField] private bool _relativeVelocity = true;

	[SerializeField] private float _reenterDelay = 0.5f;

	private Rigidbody2D _enteringBody;

	private List<Rigidbody2D> _teleportedBodies = new();

	private List<Coroutine> _exitCoroutines = new();

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

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
		if (_teleportedBodies.Contains(collision.attachedRigidbody) == true)
		{
			_exitCoroutines.Add(StartCoroutine(ReenterDelay(collision.attachedRigidbody, _exitCoroutines.Count)));
		}
	}

	protected void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.StartTurn)
		{
			return;
		}

		_teleportedBodies.Clear();

		foreach (Coroutine coroutine in _exitCoroutines)
		{
			if (coroutine != null)
			{
				StopCoroutine(coroutine);
			}
		}
	}

	IEnumerator ReenterDelay(Rigidbody2D body, int index)
	{
		yield return new WaitForSeconds(_reenterDelay);

		_teleportedBodies.Remove(body);

		_exitCoroutines.RemoveAt(index);
	}
}
