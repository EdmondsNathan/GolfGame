using UnityEngine;

public abstract class ChargeShot_Base : MonoBehaviour
{
	[SerializeField] protected float _minCharge, _maxCharge;

	private float _currentCharge = 0;

	protected void Start()
	{
		Messages_ChargeShot.OnChargeChanged?.Invoke(_minCharge);
	}

	protected float CurrentCharge
	{
		get
		{
			return _currentCharge;
		}
		set
		{
			_currentCharge = value;

			Messages_ChargeShot.OnChargeChanged?.Invoke(_currentCharge);
		}
	}

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
		if (GameManager.CurrentState != GameState.ChargeShot)
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
			_currentCharge = 0;
		}
	}
}
