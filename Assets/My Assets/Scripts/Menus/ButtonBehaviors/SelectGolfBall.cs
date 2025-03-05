using UnityEngine;

public class SelectGolfBall : SingletonMonoBehaviour<SelectGolfBall>
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
		Messages_SelectGolfBall.OnGolfBallSelected?.Invoke(abilityPrefab);
	}
	#endregion
}
