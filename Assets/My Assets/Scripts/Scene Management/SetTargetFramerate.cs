using UnityEngine;

public class SetTargetFramerate : MonoBehaviour
{
	[SerializeField] private int _targetFrameRate = 60;

	protected void Awake()
	{
		Application.targetFrameRate = _targetFrameRate;
	}
}
