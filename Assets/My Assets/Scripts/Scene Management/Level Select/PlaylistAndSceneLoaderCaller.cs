using UnityEngine;

//using this for button events for the PlaylistLoader and SceneLoader since they aren't in the main menu at start
public class PlaylistAndSceneLoaderCaller : MonoBehaviour
{
	public void SetPlaylist(SO_PlaylistReference playlist)
	{
		PlaylistLoader.Instance.SetPlaylist(playlist);
	}

	public void LoadScene(SO_SceneReference scene)
	{
		SceneLoader.Instance.LoadScene(scene);
	}

	public void LoadNextScene()
	{
		SceneLoader.Instance.LoadNextScene();
	}

	public void SetNextScene(SO_SceneReference scene)
	{
		SceneLoader.Instance.SetNextScene(scene);
	}
}
