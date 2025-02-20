using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Scene Playlist")]
public class SO_ScenePlaylist : ScriptableObject
{
	[SerializeField] private List<SO_SceneReference> _playlist;

	public List<SO_SceneReference> Playlist
	{
		get
		{
			return _playlist;
		}
	}
}
