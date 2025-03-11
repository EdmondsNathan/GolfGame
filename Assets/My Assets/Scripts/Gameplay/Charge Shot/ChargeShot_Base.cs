using UnityEngine;

public abstract class ChargeShot_Base : MonoBehaviour
{
	#region Fields
	[SerializeField] protected float _minCharge, _maxCharge;

	private float _currentCharge = 0;
	#endregion

	#region Properties
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
	#endregion

	#region Unity methods
	protected virtual void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_ChargeShot.OnRequestMinAndMaxCharge += OnRequestMinAndMaxCharge;
	}

	protected virtual void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_ChargeShot.OnRequestMinAndMaxCharge -= OnRequestMinAndMaxCharge;
	}

	protected void Start()
	{
		Messages_ChargeShot.OnMinAndMaxChargeSet?.Invoke(_minCharge, _maxCharge);

		//Messages_ChargeShot.OnChargeChanged?.Invoke(_minCharge);
	}

	protected void Update()
	{
		if (GameManager.CurrentState != GameState.ChargeShot)
		{
			return;
		}

		ChargeShot();
	}
	#endregion

	#region Abstract methods
	protected abstract void ChargeShot();
	#endregion

	#region Event listener methods
	protected virtual void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.ChargeShot)
		{
			CurrentCharge = 0;
		}
	}

	private void OnRequestMinAndMaxCharge()
	{
		Messages_ChargeShot.OnMinAndMaxChargeSet?.Invoke(_minCharge, _maxCharge);
	}
	#endregion
}
