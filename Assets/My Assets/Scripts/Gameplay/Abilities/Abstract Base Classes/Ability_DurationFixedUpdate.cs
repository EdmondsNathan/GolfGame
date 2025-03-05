using UnityEngine;

public abstract class Ability_DurationFixedUpdate : Ability_Duration
{
	#region Unity methods
	protected void FixedUpdate()
	{
		if (CanUse() == false)
		{
			return;
		}

		_currentDuration -= Time.fixedDeltaTime;

		UseAbility_FixedUpdate();

		Messages_AbilityUsage.OnDurationAbilityUsed?.Invoke(_currentDuration);
	}
	#endregion

	#region Abstract methods
	protected abstract void UseAbility_FixedUpdate();
	#endregion
}