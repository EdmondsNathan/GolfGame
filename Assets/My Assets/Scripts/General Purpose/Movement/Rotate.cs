using UnityEngine;

public class Rotate : MonoBehaviour
{
	[SerializeField] private Vector3 _rotationAmount;

	[SerializeField] private Space _space = Space.World;

	protected void Update()
	{
		transform.Rotate(_rotationAmount * Time.deltaTime, _space);
		//transform.eulerAngles += _speed * Time.deltaTime * Vector3.up;
	}
}
