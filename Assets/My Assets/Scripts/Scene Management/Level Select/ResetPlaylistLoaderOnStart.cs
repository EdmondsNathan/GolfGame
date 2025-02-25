using UnityEngine;

public class ResetPlaylistLoaderOnStart : MonoBehaviour
{
	#region Unity methods
	protected void Start()
	{
		PlaylistLoader.Instance.SetPlaylist(null);
	}
	#endregion
}
