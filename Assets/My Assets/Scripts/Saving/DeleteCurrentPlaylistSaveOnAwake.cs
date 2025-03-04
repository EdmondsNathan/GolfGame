using UnityEngine;

public class DeleteCurrentPlaylistSaveOnAwake : MonoBehaviour
{
	protected void Awake()
	{
		HighScoreSaveManager.DeleteSave("CurrentPlaylist");
	}
}
