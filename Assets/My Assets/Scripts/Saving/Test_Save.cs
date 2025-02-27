using System.Collections.Generic;
using UnityEngine;

public class Test_Save : MonoBehaviour
{
	#region Fields
	[SerializeField] private List<Save_Level> _levelSaves = new();

	[SerializeField] private List<Save_Playlist> _playlistSaves = new();

	private SaveObject _saveData = new();
	#endregion

	#region Unity methods
	protected void Start()
	{
		//Adding data from list of levels and saving
		for (int i = 0; i < _levelSaves.Count; i++)
		{
			_saveData.AddLevelData(_levelSaves[i]);
		}

		for (int i = 0; i < _playlistSaves.Count; i++)
		{
			_saveData.AddPlaylistData(_playlistSaves[i]);
		}

		SaveManager.Save("TestSave", _saveData);


		//Save loading
		SaveObject loadedSave;

		if (SaveManager.Load("TestSave", out loadedSave) == false)
		{
			Debug.Log("No save present");

			return;
		}

		Debug.Log("Save loaded");


		//Getting data from SaveObject
		Save_Playlist playlistSave;

		Save_Level levelSave;

		if (loadedSave.GetPlaylistData("xyz", out playlistSave) == true)
		{
			Debug.Log(playlistSave.Name);
		}
		else
		{
			Debug.Log("No playlist of that name found");
		}

		if (loadedSave.GetLevelData("SampleScene", out levelSave) == true)
		{
			Debug.Log(levelSave.Name);
		}
		else
		{
			Debug.Log("No level of that name found");
		}
	}
	#endregion
}
