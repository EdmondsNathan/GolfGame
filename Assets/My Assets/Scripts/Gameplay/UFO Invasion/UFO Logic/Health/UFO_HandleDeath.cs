using UnityEngine;

public class UFO_HandleDeath : MonoBehaviour
{
	#region Fields
	[SerializeField] private UFO_AbductedObject _abductedObject;

	[SerializeField] private GameObject _explosionPrefab;

	[SerializeField] private UFO_Health _healthObject;
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		_healthObject.OnDeath += OnDeath;
	}

	protected void OnDisable()
	{
		_healthObject.OnDeath -= OnDeath;
	}
	#endregion

	#region Event listener methods
	private void OnDeath()
	{
		Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

		if (_abductedObject.AbductedObject != null)
		{
			_abductedObject.AbductedObject.transform.position = transform.position;

			_abductedObject.AbductedObject.SetActive(true);
		}

		gameObject.SetActive(false);
	}
	#endregion
}
