using UnityEngine;

public class SelectAbility : MonoBehaviour
{
	#region Fields
	private static SelectAbility _instance;
	#endregion

	#region Properties
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
	#endregion

	#region Unity methods
	public void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
		}
	}
	#endregion

	#region Public methods
	public void Select(GameObject abilityPrefab)
	{
		Messages_SelectAbility.OnAbilitySelected(abilityPrefab);
	}
	#endregion
}