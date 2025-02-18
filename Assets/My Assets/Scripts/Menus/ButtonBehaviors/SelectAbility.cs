using UnityEngine;

public class SelectAbility : MonoBehaviour
{
	public void Select(GameObject abilityPrefab)
	{
		Messages_SelectAbility.OnAbilitySelected(abilityPrefab);
	}
}
