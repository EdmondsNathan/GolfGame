using Newtonsoft.Json;
using System.Collections.Generic;

public class SaveObject_HighScores
{
	#region Fields
	[JsonProperty] private Dictionary<string, SaveObject_Level> _levelSaves = new();

	[JsonProperty] private Dictionary<string, SaveObject_Playlist> _playlistSaves = new();
	#endregion

	#region Public methods
	public void AddLevelData(SaveObject_Level saveLevel)
	{
		RemoveLevelData(saveLevel.Name);

		_levelSaves.Add(saveLevel.Name, saveLevel);
	}

	public bool GetLevelData(string levelName, out SaveObject_Level levelSave)
	{
		return _levelSaves.TryGetValue(levelName, out levelSave);
	}

	public void RemoveLevelData(string levelName)
	{
		_levelSaves.Remove(levelName);
	}

	public void AddPlaylistData(SaveObject_Playlist playlistSave)
	{
		RemovePlaylistData(playlistSave.Name);

		_playlistSaves.Add(playlistSave.Name, playlistSave);
	}

	public bool GetPlaylistData(string playlistName, out SaveObject_Playlist savePlaylist)
	{
		return _playlistSaves.TryGetValue(playlistName, out savePlaylist);

		//return PlaylistSaves[playlistName];
	}

	public void RemovePlaylistData(string playlistName)
	{
		_playlistSaves.Remove(playlistName);
	}
	#endregion
}