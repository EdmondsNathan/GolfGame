using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Scene Reference")]
public class SO_SceneReference : ScriptableObject
{
	[SerializeField] private string sceneName;

	public string SceneName
	{
		get
		{
			return sceneName;
		}
	}
}