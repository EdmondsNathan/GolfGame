using UnityEngine;

public class BallAndAbilityHolder : MonoBehaviour
{
	private GameObject _abilityPrefab, _golfBallPrefab;

	protected void OnEnable()
	{
		Messages_SelectGolfBall.OnGolfBallSelected += OnGolfBallSelected;

		Messages_SelectAbility.OnAbilitySelected += OnAbilitySelected;
	}

	protected void OnDisable()
	{
		Messages_SelectGolfBall.OnGolfBallSelected -= OnGolfBallSelected;

		Messages_SelectAbility.OnAbilitySelected -= OnAbilitySelected;
	}

	private void OnGolfBallSelected(GameObject golfBallPrefab)
	{
		_golfBallPrefab = golfBallPrefab;
	}

	private void OnAbilitySelected(GameObject abilityPrefab)
	{
		_abilityPrefab = abilityPrefab;
	}
}
