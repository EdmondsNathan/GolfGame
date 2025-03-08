using UnityEngine;

public class SetTimeScaleOnAwake : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _timeScale = 0;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		Time.timeScale = _timeScale;
	}
	#endregion
}
