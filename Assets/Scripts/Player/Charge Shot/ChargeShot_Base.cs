using UnityEngine;

public abstract class ChargeShot_Base : MonoBehaviour
{
	[SerializeField] protected float _minCharge, _maxCharge;

	protected float _currentCharge = 0;

	protected virtual void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected virtual void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	protected void Update()
	{
		if (GameStateManager.CurrentState != GameState.ChargeShot)
		{
			return;
		}

		ChargeShot();
	}

	protected abstract void ChargeShot();

	public virtual void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.ChargeShot)
		{
			_currentCharge = 0f;
		}
		else if (newState == GameState.ShootBall)
		{
			_currentCharge = 0;
		}
	}
}
