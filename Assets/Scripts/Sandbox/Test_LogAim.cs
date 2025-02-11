using UnityEngine;

public class Test_LogAim : MonoBehaviour
{
	protected void OnEnable()
	{
		Messages_AimChanged.OnAimChanged += LogAim;
	}

	protected void OnDisable()
	{
		Messages_AimChanged.OnAimChanged -= LogAim;
	}

	public void LogAim(float aimAngle)
	{
		Debug.Log(aimAngle);
	}
}
