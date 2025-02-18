using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Reset : MonoBehaviour
{
	private bool _canReset = false;

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_ResetTimer.OnTimerElapsed += OnTimerElapsed;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_ResetTimer.OnTimerElapsed += OnTimerElapsed;
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.BallMoving)
		{
			_canReset = false;
		}
	}

	public void OnTimerElapsed()
	{
		_canReset = true;
	}

	public void OnReset(InputValue inputValue)
	{
		if (inputValue.isPressed == false)
		{
			return;
		}

		if (_canReset == true)
		{
			//ResetBall.Instance.ResetTurn(true);

			Messages_ResetTimer.OnReset?.Invoke(true);
		}
	}
}
