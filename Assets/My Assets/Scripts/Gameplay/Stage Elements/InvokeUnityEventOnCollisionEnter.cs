using UnityEngine;
using UnityEngine.Events;

public class InvokeUnityEventOnCollisionEnter : MonoBehaviour
{
	#region Fields
	[SerializeField] private UnityEvent<GameObject> _onCollisionEnter;
	#endregion

	#region Unity methods
	protected void OnCollisionEnter2D(Collision2D collision)
	{
		_onCollisionEnter?.Invoke(collision.gameObject);
	}
	#endregion
}
