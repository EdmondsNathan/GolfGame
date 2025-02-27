using UnityEngine;

public class SelectAbility : SingletonMonoBehaviour<SelectAbility>
{
	#region Public methods
	public void Select(GameObject abilityPrefab)
	{
		Messages_SelectAbility.OnAbilitySelected?.Invoke(abilityPrefab);
	}
	#endregion
}