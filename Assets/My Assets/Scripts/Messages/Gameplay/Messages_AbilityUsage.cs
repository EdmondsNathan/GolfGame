using System;

public static class Messages_AbilityUsage
{
	public static Action OnSingleUseAbilityUsed;

	public static Action<float> OnDurationAbilityUsed;

	public static Action<float> OnSetMaxAbilityDuration;
}