using UnityEngine;

public class Rotate : MonoBehaviour
{
	#region Fields
	[SerializeField] private Vector3 _rotationAmount;

	[SerializeField] private Space _space = Space.World;
	#endregion

	#region Unity methods
	protected void Update()
	{
		transform.Rotate(_rotationAmount * Time.deltaTime, _space);
	}
	#endregion
}