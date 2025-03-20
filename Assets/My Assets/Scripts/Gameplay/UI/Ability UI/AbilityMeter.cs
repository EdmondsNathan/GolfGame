using System.Drawing;
using UnityEngine;

//TODO: Make this work for swapping abilities during a round
public class AbilityMeter : MonoBehaviour
{
	#region	Fields
	[SerializeField] private RectTransform _rectTransform;

	[SerializeField] private GameObject _meterCanvas;

	private float _maxDuration;

	private Vector2 _size;

	private float _startingWidth;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_size = _rectTransform.sizeDelta;

		_startingWidth = _size.x;

		SetSize(0);
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_AbilityUsage.OnSetMaxAbilityDuration += OnSetMaxAbilityDuration;

		Messages_AbilityUsage.OnDurationAbilityUsed += OnDurationAbilityUsed;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_AbilityUsage.OnSetMaxAbilityDuration -= OnSetMaxAbilityDuration;

		Messages_AbilityUsage.OnDurationAbilityUsed -= OnDurationAbilityUsed;
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		SetSize(newState == GameState.BallMoving ? _startingWidth : 0);
	}

	private void OnSetMaxAbilityDuration(float maxDuration)
	{
		_maxDuration = maxDuration;

		_meterCanvas.SetActive(true);
	}

	private void OnDurationAbilityUsed(float currentDuration)
	{
		SetSize(currentDuration / _maxDuration * _startingWidth);
	}
	#endregion

	#region Private methods
	private void SetSize(float size)
	{
		_size.x = size;

		_rectTransform.sizeDelta = _size;
	}
	#endregion
}
