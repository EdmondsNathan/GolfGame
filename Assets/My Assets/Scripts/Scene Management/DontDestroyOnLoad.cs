using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
	#region Unity methods
	protected void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	#endregion
}