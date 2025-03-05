using UnityEngine;
using UnityEngine.SceneManagement;

public class BallAndAbilityHolder : SingletonMonoBehaviour<BallAndAbilityHolder>
{
	#region Fields
	private GameObject _abilityPrefab, _golfBallPrefab;
	#endregion

	#region Unity methods
	protected override void Awake()
	{
		base.Awake();

		DontDestroyOnLoad(this);
	}

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
	#endregion

	#region Event listener methods
	protected void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		Messages_SetGolfBall.OnSetGolfBall?.Invoke(_golfBallPrefab);

		Messages_SetAbility.OnSetAbility?.Invoke(_abilityPrefab);
	}

	private void OnGolfBallSelected(GameObject golfBallPrefab)
	{
		_golfBallPrefab = golfBallPrefab;
	}

	private void OnAbilitySelected(GameObject abilityPrefab)
	{
		_abilityPrefab = abilityPrefab;
	}
	#endregion
}
