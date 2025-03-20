using UnityEngine;

public class UFO_RotationStabilizer : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _minRotationSpeed, _maxRotationSpeed;

	[SerializeField] private float _activationAngle = 0.5f;

	private Rigidbody2D _rigidbody;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	protected void FixedUpdate()
	{
		StabilizeRotation();
	}
	#endregion

	#region Private methods
	private void StabilizeRotation()
	{
		float rotation = Mathf.DeltaAngle(transform.rotation.eulerAngles.z, 0);

		if (Mathf.Abs(rotation) < _activationAngle)
		{
			return;
		}

		float rotationSpeed = Mathf.Lerp(_minRotationSpeed, _maxRotationSpeed, Mathf.Abs(rotation) / 180);

		Debug.Log(rotationSpeed);

		_rigidbody.AddTorque(Mathf.Sign(rotation) * rotationSpeed);
	}
	#endregion
}
