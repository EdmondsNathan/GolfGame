using UnityEngine;

public class Rotate_FixedUpdate : MonoBehaviour
{
	[SerializeField] private Vector3 _rotationAmount;

	[SerializeField] private Space _space = Space.World;

	protected void FixedUpdate()
	{
		transform.Rotate(_rotationAmount * Time.fixedDeltaTime, _space);
		//transform.eulerAngles += _speed * Time.deltaTime * Vector3.up;
	}
}
