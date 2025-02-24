using System;

public static class Messages_ResetTimer
{
	public static Action OnTooLongTimerElapsed;

	public static Action OnResetTimerElapsed;

	//bool countTurn
	public static Action<bool> OnReset;
}
