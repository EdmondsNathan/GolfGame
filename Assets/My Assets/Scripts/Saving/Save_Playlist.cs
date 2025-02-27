using System.Collections.Generic;
using UnityEditor.Playables;

[System.Serializable]
public class Save_Playlist
{
	#region Fields
	public string Name;

	public List<Save_Level> Levels;
	#endregion

	#region Constructors
	public Save_Playlist()
	{ }

	public Save_Playlist(string name, List<Save_Level> levels)
	{
		Name = name;
		Levels = levels;
	}

	public Save_Playlist(SO_PlaylistReference playlistReference, List<Save_Level> levels) :
		this(playlistReference.Name, levels)
	{ }
	#endregion
}