using UnityEngine;

public class DeleteCurrentPlaylistSaveOnAwake : MonoBehaviour
{
	protected void Awake()
	{
		SaveManager.DeleteSave("CurrentPlaylist");
	}
}
