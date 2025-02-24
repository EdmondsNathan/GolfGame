using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaylistLoader : MonoBehaviour
{
	#region Fields
	[SerializeField] private SO_SceneReference _defaultScene;

	private static PlaylistLoader _instance;

	private int _index = 0;

	private SO_PlaylistReference _playlistReference;
	#endregion

	#region Properties
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
			_index = Math.Clamp(value, 0, PlaylistReference.Playlist.Count - 1);
		}
	}

	public SO_PlaylistReference PlaylistReference
	{
		get
		{
			return _playlistReference;
		}
		private set
		{
			_playlistReference = value;
		}
	}
	#endregion

	#region Public methods
	public void SetPlaylist(SO_PlaylistReference playlist)
	{
		if (playlist == null)
		{
			PlaylistReference = null;
		}

		if (IsPlaylistValid(playlist) == false)
		{
			return;
		}

		PlaylistReference = playlist;

		Index = 0;

		SceneLoader.Instance.SetNextScene(PlaylistReference.Playlist[Index]);
	}
	#endregion

	#region Unity methods
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
	#endregion

	#region Event listener methods
	protected void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (IsPlaylistValid() == false)
		{
			return;
		}

		SetIndexToCurrentScene();

		if (Index < PlaylistReference.Playlist.Count - 1)
		{
			SceneLoader.Instance.SetNextScene(PlaylistReference.Playlist[Index + 1]);
		}
		else
		{
			SceneLoader.Instance.SetNextScene(_defaultScene);
		}
	}
	#endregion

	#region Private methods
	private void SetIndexToCurrentScene()
	{
		string currentScene = SceneManager.GetActiveScene().name;

		for (int i = 0; i < PlaylistReference.Playlist.Count; i++)
		{
			if (PlaylistReference.Playlist[i].Name == currentScene)
			{
				Index = i;

				return;
			}
		}
	}

	private bool IsPlaylistValid()
	{
		return IsPlaylistValid(PlaylistReference);
	}

	private bool IsPlaylistValid(SO_PlaylistReference playlist)
	{
		return playlist != null && playlist.Playlist.Count > 0;
	}
	#endregion
}