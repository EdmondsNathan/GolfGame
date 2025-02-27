using System.Collections.Generic;
using UnityEngine;


//TODO: Add a class that compares your new save to existing save and only overwrites if it is an improvement
public class SaveOnGoalScored : MonoBehaviour
{
	#region Fields
	private Save_Playlist _savePlaylist;

	private Save_Level _saveLevel;

	private bool _isPlaylist = false;
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	protected void Start()
	{
		_isPlaylist = PlaylistLoader.Instance.PlaylistReference != null;

		if (PlaylistLoader.Instance.Index == 0)
		{
			SaveManager.DeleteSave("CurrentPlaylist");
		}
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.GoalScored)
		{
			return;
		}

		PopulateSave();
	}
	#endregion

	#region Private methods
	private void PopulateSave()
	{
		_saveLevel = PopulateSaveLevel();

		if (_isPlaylist == false)
		{
			if (_saveLevel.IsSaveLevelBetterThanSave("HighScores") == true)
			{
				SaveManager.OverwriteLevel("HighScores", _saveLevel);
			}

			return;
		}

		_savePlaylist = PopulateSavePlaylist(_saveLevel);

		if (_savePlaylist.Levels.Count == PlaylistLoader.Instance.PlaylistReference.Playlist.Count)
		{
			if (_savePlaylist.IsSavePlaylistBetterThanSave("HighScores") == true)
			{
				SaveManager.OverwritePlaylist("HighScores", _savePlaylist);
			}

			SaveManager.DeleteSave("CurrentPlaylist");

			return;
		}

		SaveManager.OverwritePlaylist("CurrentPlaylist", _savePlaylist);

		return;
	}

	private Save_Playlist PopulateSavePlaylist(Save_Level saveLevel)
	{
		SaveObject saveObject;

		if (SaveManager.Load("CurrentPlaylist", out saveObject) == false)
		{
			return new Save_Playlist(
				name: PlaylistLoader.Instance.PlaylistReference.Name,
				levels: new List<Save_Level>() { saveLevel });
		}

		Save_Playlist savePlaylist;

		if (saveObject.GetPlaylistData(PlaylistLoader.Instance.PlaylistReference.Name, out savePlaylist) == false)
		{
			return new Save_Playlist(
				name: PlaylistLoader.Instance.PlaylistReference.Name,
				levels: new List<Save_Level>() { saveLevel });
		}

		savePlaylist.Levels.Add(saveLevel);

		return savePlaylist;
	}

	private Save_Level PopulateSaveLevel()
	{
		return new Save_Level(
			name: SceneLoader.Instance.CurrentScene.Name,
			score: FindFirstObjectByType<TurnCounter>().TurnCount,
			realTimeTaken: RoundTimer.Instance.RealTime,
			gameTimeTaken: RoundTimer.Instance.GameTime,
			golfBall: GetGolfBall.Name_GolfBall,
			ability: GetAbility.Name_Ability);
	}

	#endregion
}
