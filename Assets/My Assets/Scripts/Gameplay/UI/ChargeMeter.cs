using UnityEngine;

public class ChargeMeter : MonoBehaviour
{
	#region Fields
	private float _minCharge, _maxCharge;

	private RectTransform _rectTransform;

	private float _startingWidth;

	private Vector2 _size;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();

		_size = _rectTransform.sizeDelta;

		_startingWidth = _size.x;

		SetSize(0);
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_ChargeShot.OnMinAndMaxChargeSet += OnMinAndMaxChargeSet;

		Messages_ChargeShot.OnChargeChanged += OnChargeChanged;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_ChargeShot.OnMinAndMaxChargeSet -= OnMinAndMaxChargeSet;

		Messages_ChargeShot.OnChargeChanged -= OnChargeChanged;
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.AimShot)
		{
			SetSize(0);
		}
	}

	private void OnMinAndMaxChargeSet(float min, float max)
	{
		_minCharge = min;

		_maxCharge = max;
	}

	private void OnChargeChanged(float charge)
	{
		SetSize(_startingWidth * (charge - _minCharge) / (_maxCharge - _minCharge));
	}
	#endregion

	#region	Private methods
	private void SetSize(float size)
	{
		_size.x = size;

		_rectTransform.sizeDelta = _size;
	}
	#endregion
}
