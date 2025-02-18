using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_OnCancel : MonoBehaviour
{
	[SerializeField] private RotateMenu _rotateMenu;

	[SerializeField] private SetSelected _setSelected;

	[SerializeField] private FadeMenu _fadeMenu;

	private List<GameObject> _previousSelecteds = new();

	private List<CanvasGroup> _previousCanvasGroups = new();

	protected void OnEnable()
	{
		Messages_MenuChange.OnCanvasGroupChanged += AddCanvasGroup;

		Messages_MenuChange.OnSelectedChange += AddSelected;
	}

	protected void OnDisable()
	{
		Messages_MenuChange.OnCanvasGroupChanged -= AddCanvasGroup;

		Messages_MenuChange.OnSelectedChange -= AddSelected;
	}

	public void OnCancel(InputValue inputValue)
	{
		if (inputValue.isPressed == false)
		{
			return;
		}


		if (_previousSelecteds.Count < 2)
		{
			return;
		}

		_rotateMenu.Rotate();

		_setSelected.SetSelectedGameObject(_previousSelecteds[_previousSelecteds.Count - 2]);

		_fadeMenu.FadeTransition(_previousCanvasGroups[_previousCanvasGroups.Count - 2]);
	}

	public void AddSelected(GameObject selected)
	{
		if (_previousSelecteds.Count < 2)
		{
			_previousSelecteds.Add(selected);

			return;
		}

		if (selected == _previousSelecteds[_previousSelecteds.Count - 2])
		{
			PopSelected();

			return;
		}

		_previousSelecteds.Add(selected);
	}

	public void AddCanvasGroup(CanvasGroup canvasGroup)
	{
		if (_previousCanvasGroups.Count < 2)
		{
			_previousCanvasGroups.Add(canvasGroup);

			return;
		}

		if (canvasGroup == _previousCanvasGroups[_previousCanvasGroups.Count - 2])
		{
			PopCanvasGroup();

			return;
		}

		_previousCanvasGroups.Add(canvasGroup);
	}

	private void PopSelected()
	{
		if (_previousSelecteds.Count > 1)
		{
			_previousSelecteds.RemoveAt(_previousSelecteds.Count - 1);
		}

	}

	private void PopCanvasGroup()
	{
		if (_previousCanvasGroups.Count > 1)
		{
			_previousCanvasGroups.RemoveAt(_previousCanvasGroups.Count - 1);
		}
	}
}
