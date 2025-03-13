using UnityEngine;

public class Rocket_ExplodeOnCollisionEnter : MonoBehaviour
{
	#region Fields
	[SerializeField] private GameObject _explosionPrefab;
	#endregion

	#region Unity methods
	protected void OnCollisionEnter2D(Collision2D collision)
	{
		Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

		gameObject.SetActive(false);
	}
	#endregion
}
