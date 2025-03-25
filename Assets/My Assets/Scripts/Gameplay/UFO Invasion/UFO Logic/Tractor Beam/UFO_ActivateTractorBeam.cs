using System.Collections.Generic;
using UnityEngine;

//TODO: Add event for when the tractor beam is (de)activated
public class UFO_ActivateTractorBeam : MonoBehaviour
{
	#region Fields
	[SerializeField] private GameObject _tractorBeam;

	[SerializeField] private UFO_AbductedObject _abductedObject;

	[SerializeField] private float _maxAngleToActivate;

	private List<GameObject> _abductables = new();
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		_abductedObject.OnAbducted += OnAbducted;
	}

	protected void OnDisable()
	{
		_abductedObject.OnAbducted -= OnAbducted;
	}

	protected void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.ContainsTag(Tag.Abductable) == false)
		{
			return;
		}

		_abductables.Add(collider.gameObject);

		ActivateTractorBeam(true);
	}

	protected void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.ContainsTag(Tag.Abductable) == false)
		{
			return;
		}

		_abductables.Remove(collider.gameObject);

		if (_abductables.Count == 0)
		{
			ActivateTractorBeam(false);
		}
	}
	#endregion

	#region Event listener methods
	private void OnAbducted(GameObject abductedObject)
	{
		if (abductedObject == null)
		{
			return;
		}

		ActivateTractorBeam(false);
	}

	#endregion

	#region Private methods
	private void ActivateTractorBeam(bool isActive)
	{
		if (Mathf.DeltaAngle(transform.eulerAngles.z, 0) > _maxAngleToActivate)
		{
			isActive = false;
		}

		if (_abductedObject.AbductedObject != null)
		{
			isActive = false;
		}

		_tractorBeam.SetActive(isActive);
	}
	#endregion
}