using UnityEngine;

public class SetTargetFramerate : MonoBehaviour
{
	#region Fields
	[SerializeField] private int _targetFrameRate = 60;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		Application.targetFrameRate = _targetFrameRate;
	}
	#endregion
}
