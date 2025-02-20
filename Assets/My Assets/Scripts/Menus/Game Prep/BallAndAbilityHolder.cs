using UnityEngine;
using UnityEngine.SceneManagement;

public class BallAndAbilityHolder : MonoBehaviour
{
	private GameObject _abilityPrefab, _golfBallPrefab;

	protected void OnEnable()
	{
		Messages_SelectGolfBall.OnGolfBallSelected += OnGolfBallSelected;

		Messages_SelectAbility.OnAbilitySelected += OnAbilitySelected;

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	protected void OnDisable()
	{
		Messages_SelectGolfBall.OnGolfBallSelected -= OnGolfBallSelected;

		Messages_SelectAbility.OnAbilitySelected -= OnAbilitySelected;

		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	protected void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		Messages_SetGolfBall.SetGolfBall?.Invoke(_golfBallPrefab);

		Messages_SetAbility.SetAbility?.Invoke(_abilityPrefab);
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
