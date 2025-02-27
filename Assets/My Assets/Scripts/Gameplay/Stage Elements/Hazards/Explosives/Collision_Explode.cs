using UnityEngine;

public class Collision_Explode : ExplosiveActivator
{
	#region Unity methods
	protected void OnCollisionEnter2D(Collision2D collision)
	{
		ActivateExplosive();
	}
	#endregion
}
