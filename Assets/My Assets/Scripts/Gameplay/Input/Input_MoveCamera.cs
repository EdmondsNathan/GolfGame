using UnityEngine;
using UnityEngine.InputSystem;

public class Input_MoveCamera : MonoBehaviour
{
	#region Event listener methods
	public void OnMoveCamera(InputValue inputValue)
	{
		Messages_MoveCamera.OnMoveCamera?.Invoke(inputValue.Get<Vector2>());
	}
	#endregion
}
