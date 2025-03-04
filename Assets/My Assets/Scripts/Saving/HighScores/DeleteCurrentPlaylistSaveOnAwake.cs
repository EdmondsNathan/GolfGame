using UnityEngine;

public class DeleteCurrentPlaylistSaveOnAwake : MonoBehaviour
{
	protected void Awake()
	{
		SaveManager_HighScores.DeleteSave(SaveManager_HighScores.CurrentSaveName);
	}
}
