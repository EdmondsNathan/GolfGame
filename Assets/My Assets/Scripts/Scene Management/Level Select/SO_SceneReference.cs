using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Scene Reference")]
public class SO_SceneReference : ScriptableObject
{
	[SerializeField] private string _name;

	public string Name
	{
		get
		{
			return _name;
		}
	}
}