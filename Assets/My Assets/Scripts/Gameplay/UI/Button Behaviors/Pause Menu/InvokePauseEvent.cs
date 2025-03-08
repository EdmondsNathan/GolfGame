using UnityEngine;

public class InvokePauseEvent : MonoBehaviour
{
	#region Public methods
	public void InvokePause()
	{
		Messages_Pause.OnPause?.Invoke();
	}
	#endregion
}