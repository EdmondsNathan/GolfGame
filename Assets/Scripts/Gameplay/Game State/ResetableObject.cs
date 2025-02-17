using UnityEditor.Presets;
using UnityEngine;

public class ResetableObject : MonoBehaviour
{
	private Vector3 _lastPosition = new();

	private Quaternion _lastRotation = new();

	private Vector3 _lastScale = new();

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_ResetTimer.OnReset += OnReset;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_ResetTimer.OnReset += OnReset;
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.ShootBall)
		{
			_lastPosition = transform.position;

			_lastRotation = transform.rotation;

			_lastScale = transform.localScale;
		}
	}

	public void OnReset(bool countTurn)
	{
		transform.position = _lastPosition;

		transform.rotation = _lastRotation;

		transform.localScale = _lastScale;
	}
}
