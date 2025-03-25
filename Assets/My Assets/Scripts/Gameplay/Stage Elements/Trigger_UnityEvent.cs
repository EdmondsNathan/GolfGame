using UnityEngine;
using UnityEngine.Events;

public class Trigger_UnityEvent : MonoBehaviour
{
	#region Fields
	[SerializeField] private UnityEvent<GameObject> _onTriggerEnter;
	#endregion

	#region Unity methods
	protected void OnTriggerEnter2D(Collider2D collision)
	{
		_onTriggerEnter?.Invoke(collision.gameObject);
	}
	#endregion
}
