using System.Collections;
using UnityEngine;

public class Explosive : MonoBehaviour
{
	#region Fields
	[SerializeField] private GameObject _explosionField;

	[SerializeField] private float _duration = 0.5f;

	[SerializeField] private bool _onlyActivateOnce = true;
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		Messages_Reset.OnTurnReset += OnTurnReset;
	}

	protected void OnDisable()
	{
		Messages_Reset.OnTurnReset -= OnTurnReset;

		StopAllCoroutines();

		_explosionField.SetActive(false);
	}
	#endregion

	#region Event listener methods
	private void OnTurnReset(bool countTurn)
	{
		StopAllCoroutines();
	}
	#endregion

	#region Public methods
	public void Explode()
	{
		StartCoroutine(ActivateForDuration(_explosionField, _duration));
	}
	#endregion

	#region Coroutines
	IEnumerator ActivateForDuration(GameObject explosionField, float duration)
	{
		explosionField.SetActive(true);

		yield return null;

		yield return new WaitForSeconds(duration);

		explosionField.SetActive(false);

		if (_onlyActivateOnce == true)
		{
			gameObject.SetActive(false);
		}
	}
	#endregion
}
