using UnityEngine;

public class Trigger_Explode : ExplosiveActivator
{
	#region Unity methods
	protected void OnTriggerEnter2D(Collider2D collision)
	{
		ActivateExplosive();
	}
	#endregion
}
