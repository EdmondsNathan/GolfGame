using System;
using UnityEngine;

public class Trigger_AbductObject : MonoBehaviour
{
	#region Fields
	[SerializeField] private UFO_AbductedObject _abductedObject;
	#endregion

	#region Unity methods
	protected void OnTriggerEnter2D(Collider2D collider)
	{
		if (_abductedObject.AbductedObject != null)
		{
			return;
		}

		if (collider.ContainsTag(Tag.Abductable) == false)
		{
			return;
		}
		_abductedObject.OnAbducted?.Invoke(collider.gameObject);
	}
	#endregion
}