using UnityEngine;

public class SelectGolfBall : SingletonMonoBehaviour<SelectGolfBall>
{
	#region Public methods
	public void Select(GameObject abilityPrefab)
	{
		Messages_SelectGolfBall.OnGolfBallSelected?.Invoke(abilityPrefab);
	}
	#endregion
}
