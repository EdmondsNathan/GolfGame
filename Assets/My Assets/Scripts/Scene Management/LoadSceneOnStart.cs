using UnityEngine;

public class LoadSceneOnStart : MonoBehaviour
{
	#region Fields
	[SerializeField] private SO_SceneReference _scene;
	#endregion

	#region Unity methods
	protected void Start()
	{
		SceneLoader.Instance.LoadScene(_scene);
	}
	#endregion
}
