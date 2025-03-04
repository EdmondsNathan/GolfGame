using System.Collections.Generic;
public class SaveObject_Playlist
{
	#region Fields
	public string Name;

	public List<SaveObject_Level> Levels;
	#endregion

	#region Constructors
	public SaveObject_Playlist()
	{ }

	public SaveObject_Playlist(string name, List<SaveObject_Level> levels)
	{
		Name = name;
		Levels = levels;
	}

	public SaveObject_Playlist(SO_PlaylistReference playlistReference, List<SaveObject_Level> levels) :
		this(playlistReference.Name, levels)
	{ }
	#endregion
}