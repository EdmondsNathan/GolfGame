using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class Test_LogFPS : MonoBehaviour
{
	private float[] _fps = new float[10];

	private int _count = 0;

	protected void Update()
	{
		_fps[_count] = 1 / Time.deltaTime;

		_count++;

		if (_count >= 10)
		{
			_count = 0;
		}

		Debug.Log("avg fps: " + _fps.Sum() / 10);
		// Debug.Log("FPS: " + 1 / Time.deltaTime);
	}
}
