using UnityEngine;

public class SelectGolfBall : MonoBehaviour
{
	#region Fields
	private static SelectGolfBall _instance;
	#endregion

	#region Properties
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
		Messages_SelectGolfBall.OnGolfBallSelected(abilityPrefab);
	}
	#endregion
}
