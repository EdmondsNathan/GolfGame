using UnityEngine;

public class Test_LogChargeShot : MonoBehaviour
{
	protected void OnEnable()
	{
		Messages_ChargeShot.ChargeShot += LogCharge;
	}

	protected void OnDisable()
	{
		Messages_ChargeShot.ChargeShot -= LogCharge;
	}

	public void LogCharge(float charge)
	{
		Debug.Log(charge);
	}
}
