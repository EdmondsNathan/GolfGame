using UnityEngine;

public class LoadSceneOnStart : MonoBehaviour
{
	[SerializeField] private SO_SceneReference _scene;

	protected void Start()
	{
		SceneLoader.Instance.LoadScene(_scene);
	}
}
