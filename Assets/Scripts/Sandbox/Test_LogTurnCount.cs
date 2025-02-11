using UnityEngine;

public class Test_LogTurnCount : MonoBehaviour
{
	protected void OnEnable()
	{
		Messages_TurnCountChanged.OnTurnCountChanged += OnTurnCountChanged;
	}

	protected void OnDisable()
	{
		Messages_TurnCountChanged.OnTurnCountChanged -= OnTurnCountChanged;
	}

	public void OnTurnCountChanged(int TurnCount)
	{
		Debug.Log("turn " + TurnCount);
	}
}
