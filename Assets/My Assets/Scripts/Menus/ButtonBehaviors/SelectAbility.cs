using UnityEngine;

public class SelectAbility : MonoBehaviour
{
	private static SelectAbility _instance;

	public static SelectAbility Instance
	{
		get
		{
			return _instance;
		}
		set
		{
			_instance = value;
		}
	}

	public void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
		}
	}

	public void Select(GameObject abilityPrefab)
	{
		Messages_SelectAbility.OnAbilitySelected(abilityPrefab);
	}
}
