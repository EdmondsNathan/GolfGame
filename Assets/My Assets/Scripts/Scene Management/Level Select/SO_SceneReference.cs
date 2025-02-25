using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Scene Reference")]
public class SO_SceneReference : ScriptableObject
{
	#region Fields
	[SerializeField] private string _name;
	#endregion

	#region Properties
	public string Name
	{
		get
		{
			return _name;
		}
	}
	#endregion
}