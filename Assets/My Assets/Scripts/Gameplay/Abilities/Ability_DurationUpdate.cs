using UnityEngine;

public abstract class Ability_DurationUpdate : Ability_Duration
{
	protected void Update()
	{
		if (CanUse() == false)
		{
			return;
		}

		_currentDuration += Time.deltaTime;

		UseAbility();
	}
}