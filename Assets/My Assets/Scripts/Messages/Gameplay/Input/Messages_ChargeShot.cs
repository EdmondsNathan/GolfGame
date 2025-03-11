using System;

public static class Messages_ChargeShot
{
	public static Action<float> OnChargeChanged;

	public static Action<float, float> OnMinAndMaxChargeSet;

	public static Action OnRequestMinAndMaxCharge;
}
