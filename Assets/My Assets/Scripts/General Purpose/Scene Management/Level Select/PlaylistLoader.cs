using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaylistLoader : MonoBehaviour
{
	//[SerializeField] private SceneLoader _sceneLoader;

	[SerializeField] private SO_SceneReference _defaultScene;

	private static PlaylistLoader _instance;

	private int _index = 0;

	private SO_ScenePlaylist _playlist;

	public static PlaylistLoader Instance
	{
		get
		{
			return _instance;
		}
		set
		{
			_instance = value;
		}
	}


	public int Index
	{
		get
		{
			return _index;
		}
		private set
		{
			_index = Math.Clamp(value, 0, Playlist.Playlist.Count - 1);
		}
	}

	public SO_ScenePlaylist Playlist
	{
		get
		{
			return _playlist;
		}
		set
		{
			_playlist = value;
		}
	}

	protected void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
		}
	}

	protected void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	protected void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	protected void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (IsPlaylistValid() == false)
		{
			return;
		}

		SetIndexToCurrentScene();

		if (Index < Playlist.Playlist.Count - 1)
		{
			SceneLoader.Instance.SetNextScene(Playlist.Playlist[Index + 1]);
		}
		else
		{
			SceneLoader.Instance.SetNextScene(_defaultScene);
		}
	}


	public void SetPlaylist(SO_ScenePlaylist playlist)
	{
		if (IsPlaylistValid(playlist) == false)
		{
			return;
		}

		Playlist = playlist;

		Index = 0;

		SceneLoader.Instance.SetNextScene(Playlist.Playlist[Index]);
	}

	/*public void LoadScene()
	{
		if (IsPlaylistValid() == false)
		{
			return;
		}

		SceneManager.LoadScene(Playlist.Playlist[Index].SceneName);
	}

	public void LoadScene(int index)
	{
		if (IsPlaylistValid() == false)
		{
			return;
		}

		SetIndex(index);

		LoadScene();
	}*/

	/*private void SetIndex(int index)
	{
		if (IsPlaylistValid() == false)
		{
			return;
		}

		Index = Math.Clamp(index, 0, Playlist.Playlist.Count - 1);
	}*/

	/*public void IncrementIndex(int amount)
	{
		if (IsPlaylistValid() == false)
		{
			return;
		}

		SetIndex(Index + amount);
	}*/

	private void SetIndexToCurrentScene()
	{
		string currentScene = SceneManager.GetActiveScene().name;

		for (int i = 0; i < Playlist.Playlist.Count; i++)
		{
			if (Playlist.Playlist[i].SceneName == currentScene)
			{
				Index = i;

				return;
			}
		}
	}

	private bool IsPlaylistValid()
	{
		return IsPlaylistValid(Playlist);
	}

	private bool IsPlaylistValid(SO_ScenePlaylist playlist)
	{
		return playlist != null && playlist.Playlist.Count > 0;
	}
}