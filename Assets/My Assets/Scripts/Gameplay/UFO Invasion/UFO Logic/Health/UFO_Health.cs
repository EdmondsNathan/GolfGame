using System;
using UnityEngine;

public class UFO_Health : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _maxHealth = 100;

	private ResetableValue<float> _resetableCurrentHealth;
	#endregion

	#region Events
	public Action<float> OnHealthChanged;

	public Action OnDeath;
	#endregion

	#region Properties
	public float CurrentHealth
	{
		get => _resetableCurrentHealth.Value;
		set
		{
			if (_resetableCurrentHealth.Value != value)
			{
				_resetableCurrentHealth.Value = value;
				OnHealthChanged?.Invoke(_resetableCurrentHealth.Value);
				if (_resetableCurrentHealth.Value <= 0)
				{
					OnDeath?.Invoke();
				}
			}
		}
	}

	public float MaxHealth
	{
		get => _maxHealth;
	}
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_resetableCurrentHealth = new(_maxHealth);

		_resetableCurrentHealth.Subscribe();

		Messages_Reset.OnTurnReset += OnTurnReset;
	}

	protected void OnDestroy()
	{
		Messages_Reset.OnTurnReset -= OnTurnReset;

		_resetableCurrentHealth.Unsubscribe();
	}
	#endregion

	#region Event listener methods
	private void OnTurnReset(bool countTurn)
	{
		OnHealthChanged?.Invoke(_resetableCurrentHealth.ResetValue);
	}
	#endregion
}
