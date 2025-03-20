using UnityEngine;

public class Rocket_ExplodeOnCollisionEnterOrTriggerEnter : MonoBehaviour
{
	#region Fields
	[SerializeField] private GameObject _explosionPrefab;
	#endregion

	#region Unity methods
	protected void OnCollisionEnter2D(Collision2D collision)
	{
		Explode();
	}

	protected void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.GetComponent<Collider2D>().isTrigger == true)
		{
			if (collider.ContainsTag(Tag.DestroyProjectiles))
			{
				Explode();
			}

			return;
		}

		Explode();
	}
	#endregion

	#region Private methods
	private void Explode()
	{
		Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

		gameObject.SetActive(false);
	}
	#endregion
}
