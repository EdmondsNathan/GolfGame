using UnityEngine;

public class CardAction_Log : CardAction
{
	[SerializeField] private string _message;

	public override void DoAction()
	{
		Debug.Log(_message);
	}
}
