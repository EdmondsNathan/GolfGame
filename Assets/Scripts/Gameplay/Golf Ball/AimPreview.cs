using System;
using UnityEngine;

public class AimPreview : MonoBehaviour
{
	[SerializeField] private float _distance = 1;

	private float _aimRad;

	private Vector2 _aimVector = new();

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_AimChanged.OnAimChanged += OnAimChanged;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_AimChanged.OnAimChanged -= OnAimChanged;
	}

	protected void Update()
	{
		if (GameManager.CurrentState == GameState.AimShot)
		{
			transform.position = (Vector2)GetGolfBall.Transform_GolfBall.position + (_distance * _aimVector);
		}
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.AimShot)
		{
			transform.position = GetGolfBall.Transform_GolfBall.position;
		}

		GetComponent<Renderer>().enabled = newState == GameState.AimShot;
	}

	private void OnAimChanged(float aimAngle)
	{
		_aimRad = aimAngle * Mathf.Deg2Rad;

		_aimVector.x = Mathf.Cos(_aimRad);

		_aimVector.y = Mathf.Sin(_aimRad);
	}
}
