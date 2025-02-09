using UnityEngine;

public class Test_LogAim : MonoBehaviour
{
	protected void OnEnable()
	{
		Messages_AimChanged.AimAngle += LogAim;
	}

	protected void OnDisable()
	{
		Messages_AimChanged.AimAngle -= LogAim;
	}

	public void LogAim(float aimAngle)
	{
		Debug.Log(aimAngle);
	}
}
