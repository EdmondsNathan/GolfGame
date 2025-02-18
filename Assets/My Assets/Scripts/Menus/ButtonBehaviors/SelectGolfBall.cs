using UnityEngine;

public class SelectGolfBall : MonoBehaviour
{
	public void Select(GameObject abilityPrefab)
	{
		Messages_SelectGolfBall.OnGolfBallSelected(abilityPrefab);
	}
}
