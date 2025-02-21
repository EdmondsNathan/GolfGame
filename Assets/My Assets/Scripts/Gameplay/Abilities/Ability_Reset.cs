using System.Collections.Generic;
using UnityEngine;

public class Ability_Reset : Ability_SingleUse
{
	protected override void UseAbility()
	{
		Messages_ResetTimer.OnReset?.Invoke(false);
	}
}
