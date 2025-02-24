using UnityEngine;

public class ResetPlaylistLoaderOnStart : MonoBehaviour
{
	protected void Start()
	{
		PlaylistLoader.Instance.SetPlaylist(null);
	}
}
