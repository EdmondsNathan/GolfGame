using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Input_OnCancel : MonoBehaviour
{
	[SerializeField] private RotateMenu _rotateMenu;

	[SerializeField] private SetSelected _setSelected;

	[SerializeField] private FadeMenu _fadeMenu;

	/*TODO BUG: Fix where you can cancel twice to keep looping through menus
	I think I need to create a list that holds all the menus in order of access,
	and then any time you go back, pop the last element off*/
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
