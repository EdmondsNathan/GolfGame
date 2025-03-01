using TMPro;
using UnityEngine;

public class TurnCounterTextbox : MonoBehaviour
{
	#region Fields
	[SerializeField] private TMP_Text _textbox;

	private int _turnCount = 1;
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		Messages_TurnCountChanged.OnTurnCountChanged += OnTurnCountChanged;
	}

	protected void OnDisable()
	{
		Messages_TurnCountChanged.OnTurnCountChanged -= OnTurnCountChanged;
	}

	protected void Start()
	{
		UpdateTextbox();
	}
	#endregion

	#region Event listener methods
	private void OnTurnCountChanged(int turnCount)
	{
		_turnCount = turnCount;

		UpdateTextbox();
	}
	#endregion

	private void UpdateTextbox()
	{
		_textbox.text = "Turn " + _turnCount;
	}
}
