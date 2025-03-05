using UnityEngine;
using UnityEngine.Events;

public class InvokeUnityEventOnTriggerEnter : MonoBehaviour
{
	#region Fields
	[SerializeField] private UnityEvent<GameObject> _onCollisionEnter;
	#endregion

	#region Unity methods
	protected void OnTriggerEnter2D(Collider2D collision)
	{
		_onCollisionEnter?.Invoke(collision.gameObject);
	}
	#endregion
}
