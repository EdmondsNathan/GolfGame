using System.Collections.Generic;

public enum Unlockables
{
	Ball_Standard,
	Ball_ZeroG,
	Ball_Sticky,
	Ball_Explosive,
	Ball_Square,

	Ability_Brake,
	Ability_Boost,
	Ability_Reset,
	Ability_Thrust,
	Ability_Rocket
}

public class SaveObject_Unlockables
{
	#region Fields
	public Dictionary<Unlockables, bool> Unlocks = new();
	#endregion

	#region Constructors
	public SaveObject_Unlockables()
	{
		Unlocks = new()
		{
			{ Unlockables.Ball_Standard, true},
			{ Unlockables.Ball_ZeroG, false},
			{ Unlockables.Ball_Sticky, false},
			{ Unlockables.Ball_Explosive, false},
			{ Unlockables.Ball_Square, false},

			{ Unlockables.Ability_Brake, true},
			{ Unlockables.Ability_Boost, false},
			{ Unlockables.Ability_Reset, false},
			{ Unlockables.Ability_Thrust, false},
			{ Unlockables.Ability_Rocket, false}
		};
	}
	#endregion
}