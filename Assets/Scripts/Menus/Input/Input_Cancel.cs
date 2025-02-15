using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Input_OnCancel : MonoBehaviour
{
	[SerializeField] private RotateMenu _rotateMenu;

	[SerializeField] private SetSelected _setSelected;

	[SerializeField] private FadeMenu _fadeMenu;

	//TODO BUG: Fix where you can cancel twice to keep looping through menus
	public void OnCancel(InputValue inputValue)
	{
		if (inputValue.isPressed == false)
		{
			return;
		}

		if (_setSelected.PreviousSelected == null)
		{
			return;
		}

		if (_fadeMenu.PreviousCanvasGroup == null)
		{
			return;
		}

		_rotateMenu.Rotate();

		_setSelected.SetPreviousSelected();

		_fadeMenu.PreviousFade();
	}
}
