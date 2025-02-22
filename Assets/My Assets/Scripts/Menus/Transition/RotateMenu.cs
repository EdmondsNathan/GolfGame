using UnityEngine;

public class RotateMenu : MonoBehaviour
{
	[SerializeField] private Transform _planet;

	[SerializeField] private float _speed;

	private float _targetRotation = 0;

	private Vector3 _targetRotationV3 = Vector3.zero;

	private Vector3 _currentRotation = Vector3.zero;

	protected void Update()
	{
		_currentRotation.y = Mathf.Lerp(_currentRotation.y, _targetRotation, _speed * Time.deltaTime);

		_planet.localEulerAngles = _currentRotation;
	}

	public void Rotate()
	{
		_targetRotation += 180;

		if (_targetRotation > 360)
		{
			_targetRotation -= 360;
		}

		_targetRotationV3.y = _targetRotation;

		_currentRotation.y = _targetRotation - 180;
	}
}
