using UnityEngine;

public abstract class Ability_DurationFixedUpdate : Ability_Duration
{
	protected void FixedUpdate()
	{
		if (CanUse() == false)
		{
			return;
		}

		_currentDuration += Time.fixedDeltaTime;

		UseAbility_FixedUpdate();
	}

	protected abstract void UseAbility_FixedUpdate();
}