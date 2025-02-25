using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Playlist Reference")]
public class SO_PlaylistReference : ScriptableObject
{
	#region Fields
	[SerializeField] private string _name;

	[SerializeField] private List<SO_SceneReference> _playlist;
	#endregion

	#region Properties
	public string Name
	{
		get
		{
			return _name;
		}
	}

	public List<SO_SceneReference> Playlist
	{
		get
		{
			return _playlist;
		}
	}
	#endregion
}