using UnityEngine;

public class Test_LogChargeShot : MonoBehaviour
{
	protected void OnEnable()
	{
		Messages_ChargeShot.OnChargeChanged += LogCharge;
	}

	protected void OnDisable()
	{
		Messages_ChargeShot.OnChargeChanged -= LogCharge;
	}

	public void LogCharge(float charge)
	{
		Debug.Log(charge);
	}
}
