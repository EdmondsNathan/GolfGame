using UnityEngine;

public class SelectAbility : SingletonMonoBehaviour<SelectAbility>
{
	#region Unity methods
	protected override void Awake()
	{
		base.Awake();

		DontDestroyOnLoad(this);
	}
	#endregion

	#region Public methods
	public void Select(GameObject abilityPrefab)
	{
		Messages_SelectAbility.OnAbilitySelected?.Invoke(abilityPrefab);
	}
	#endregion
}