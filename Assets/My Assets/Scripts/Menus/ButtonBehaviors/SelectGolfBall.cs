using UnityEngine;

public class SelectGolfBall : MonoBehaviour
{
	private static SelectGolfBall _instance;

	public static SelectGolfBall Instance
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
		Messages_SelectGolfBall.OnGolfBallSelected(abilityPrefab);
	}
}
