using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveOnGoalScored : MonoBehaviour
{
	#region Fields
	private SaveObject_Playlist _savePlaylist;

	private SaveObject_Level _saveLevel;

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
			HighScoreSaveManager.DeleteSave("CurrentPlaylist");
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
				HighScoreSaveManager.OverwriteLevel("HighScores", _saveLevel);
			}

			return;
		}

		_savePlaylist = PopulateSavePlaylist(_saveLevel);

		if (_savePlaylist.Levels.Count == PlaylistLoader.Instance.PlaylistReference.Playlist.Count)
		{
			if (_savePlaylist.IsSavePlaylistBetterThanSave("HighScores") == true)
			{
				HighScoreSaveManager.OverwritePlaylist("HighScores", _savePlaylist);
			}

			HighScoreSaveManager.DeleteSave("CurrentPlaylist");

			return;
		}

		HighScoreSaveManager.OverwritePlaylist("CurrentPlaylist", _savePlaylist);

		return;
	}

	private SaveObject_Playlist PopulateSavePlaylist(SaveObject_Level saveLevel)
	{
		SaveObject_HighScore saveObject;

		if (HighScoreSaveManager.Load("CurrentPlaylist", out saveObject) == false)
		{
			return new SaveObject_Playlist(
				name: PlaylistLoader.Instance.PlaylistReference.Name,
				levels: new List<SaveObject_Level>() { saveLevel });
		}

		SaveObject_Playlist savePlaylist;

		if (saveObject.GetPlaylistData(PlaylistLoader.Instance.PlaylistReference.Name, out savePlaylist) == false)
		{
			return new SaveObject_Playlist(
				name: PlaylistLoader.Instance.PlaylistReference.Name,
				levels: new List<SaveObject_Level>() { saveLevel });
		}

		savePlaylist.Levels.Add(saveLevel);

		return savePlaylist;
	}

	private SaveObject_Level PopulateSaveLevel()
	{
		return new SaveObject_Level(
			name: SceneManager.GetActiveScene().name,
			score: FindFirstObjectByType<TurnCounter>().TurnCount,
			realTimeTaken: RoundTimer.Instance.RealTime,
			gameTimeTaken: RoundTimer.Instance.GameTime,
			golfBall: GetGolfBall.Name_GolfBall,
			ability: GetAbility.Name_Ability);
	}

	#endregion
}
