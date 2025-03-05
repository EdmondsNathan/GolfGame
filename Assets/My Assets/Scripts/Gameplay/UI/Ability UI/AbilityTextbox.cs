using System;
using TMPro;
using UnityEngine;

public class AbilityTextbox : MonoBehaviour
{
	#region Fields
	[SerializeField] private TMP_Text _textbox;

	[SerializeField] private Color _deactivatedColor;

	private Color _activeColor;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_activeColor = _textbox.color;
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_AbilityUsage.OnSingleUseAbilityUsed += OnSingleUseAbilityUsed;

		Messages_AbilityUsage.OnDurationAbilityUsed += OnDurationAbilityUsed;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_AbilityUsage.OnSingleUseAbilityUsed -= OnSingleUseAbilityUsed;

		Messages_AbilityUsage.OnDurationAbilityUsed -= OnDurationAbilityUsed;
	}

	private void Start()
	{
		ObjectTagManager.TryFindFirstObjectWithTag(Tag.Ability, out GameObject ability);

		_textbox.text = ability.GetComponent<ObjectName>().Name;
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		_textbox.color = newState == GameState.BallMoving ? _activeColor : _deactivatedColor;
	}

	private void OnSingleUseAbilityUsed()
	{
		_textbox.color = _deactivatedColor;
	}

	private void OnDurationAbilityUsed(float currentDuration)
	{
		if (currentDuration > 0)
		{
			return;
		}

		_textbox.color = _deactivatedColor;
	}
	#endregion
}
