using UnityEngine;

public abstract class ExplosiveActivator : MonoBehaviour
{
	#region Fields
	[SerializeField] private Explosive _explosive;

	[SerializeField] private bool _deactivateAfterExplosion = true;
	#endregion

	#region Protected methods
	protected void ActivateExplosive()
	{
		_explosive.Explode();

		if (_deactivateAfterExplosion == true)
		{
			gameObject.SetActive(false);
		}
	}
	#endregion
}
