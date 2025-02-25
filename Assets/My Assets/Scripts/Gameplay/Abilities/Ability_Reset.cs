using System.Collections.Generic;
using UnityEngine;

public class Ability_Reset : Ability_SingleUse
{
	#region Overriden methods
	protected override void UseAbility()
	{
		Messages_Reset.OnTurnReset?.Invoke(false);
	}
	#endregion
}
