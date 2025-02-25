using UnityEngine;

public class PauseOnAwake : MonoBehaviour
{
	#region Unity methods
	protected void Awake()
	{
		Time.timeScale = 0;
	}
	#endregion
}
