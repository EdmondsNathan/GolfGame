using Newtonsoft.Json;
using System.Collections.Generic;

public class SaveObject
{
	#region Fields
	[JsonProperty] private Dictionary<string, Save_Level> LevelSaves = new();

	[JsonProperty] private Dictionary<string, Save_Playlist> PlaylistSaves = new();
	#endregion

	#region Public methods
	public void AddLevelData(Save_Level saveLevel)
	{
		RemoveLevelData(saveLevel.Name);

		LevelSaves.Add(saveLevel.Name, saveLevel);
	}

	public bool GetLevelData(string levelName, out Save_Level levelSave)
	{
		return LevelSaves.TryGetValue(levelName, out levelSave);
	}

	public void RemoveLevelData(string levelName)
	{
		LevelSaves.Remove(levelName);
	}

	public void AddPlaylistData(Save_Playlist playlistSave)
	{
		RemovePlaylistData(playlistSave.Name);

		PlaylistSaves.Add(playlistSave.Name, playlistSave);
	}

	public bool GetPlaylistData(string playlistName, out Save_Playlist savePlaylist)
	{
		return PlaylistSaves.TryGetValue(playlistName, out savePlaylist);

		//return PlaylistSaves[playlistName];
	}

	public void RemovePlaylistData(string playlistName)
	{
		PlaylistSaves.Remove(playlistName);
	}
	#endregion
}