using UnityEngine;

public abstract class Ability_DurationUpdate : Ability_Duration
{
	#region Unity methods
	protected void Update()
	{
		if (CanUse() == false)
		{
			return;
		}

		_currentDuration += Time.deltaTime;

		UseAbility_Update();
	}
	#endregion

	#region Abstract methods
	protected abstract void UseAbility_Update();
	#endregion
}