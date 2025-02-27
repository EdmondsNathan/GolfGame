using UnityEngine;

public class DeleteCurrentPlaylistSave : MonoBehaviour
{
	protected void Awake()
	{
		SaveManager.DeleteSave("CurrentPlaylist");
	}
}
