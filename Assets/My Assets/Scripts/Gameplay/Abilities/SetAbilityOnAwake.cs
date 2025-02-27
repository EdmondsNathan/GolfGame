using UnityEngine;

[RequireComponent(typeof(ObjectName))]
public class SetAbilityOnAwake : MonoBehaviour
{
	#region Unity methods
	protected void Awake()
	{
		if (GetAbility.GameObject_Ability != null)
		{
			return;
		}

		GetAbility.GameObject_Ability = gameObject;

		GetAbility.Name_Ability = GetComponent<ObjectName>().Name;
	}
	#endregion
}