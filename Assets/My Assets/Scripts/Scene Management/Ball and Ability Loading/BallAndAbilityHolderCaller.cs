using UnityEngine;

public class BallAndAbilityHolderCaller : MonoBehaviour
{
	#region Public methods
	public void ChooseBall(GameObject ball)
	{
		SelectGolfBall.Instance.Select(ball);
	}

	public void ChooseAbility(GameObject ability)
	{
		SelectAbility.Instance.Select(ability);
	}
	#endregion
}