using UnityEngine;

public class PauseOnAwake : MonoBehaviour
{
	protected void Awake()
	{
		Time.timeScale = 0;
	}
}
