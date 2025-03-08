using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Cancel : MonoBehaviour
{
	#region Fields
	[SerializeField] private RotateMenu _rotateMenu;

	[SerializeField] private SetSelectedButton _setSelected;

	[SerializeField] private FadeMenu _fadeMenu;

	private List<GameObject> _previousSelecteds = new();

	private List<CanvasGroup> _previousCanvasGroups = new();
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		Messages_MenuChange.OnCanvasGroupChanged += OnCanvasGroupChange;

		Messages_MenuChange.OnSelectedChanged += OnSelectedChanged;
	}

	protected void OnDisable()
	{
		Messages_MenuChange.OnCanvasGroupChanged -= OnCanvasGroupChange;

		Messages_MenuChange.OnSelectedChanged -= OnSelectedChanged;
	}
	#endregion

	#region Event listener methods
	public void OnCancel(InputValue inputValue)
	{
		if (inputValue.isPressed == false)
		{
			return;
		}

		GoBack();
	}

	private void OnSelectedChanged(GameObject selected)
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

	private void OnCanvasGroupChange(CanvasGroup canvasGroup)
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
	#endregion

	#region Public methods
	public void GoBack()
	{
		if (_previousSelecteds.Count < 2)
		{
			return;
		}

		_rotateMenu.Rotate();

		_setSelected.SetSelectedGameObject(_previousSelecteds[_previousSelecteds.Count - 2]);

		_fadeMenu.FadeTransition(_previousCanvasGroups[_previousCanvasGroups.Count - 2]);
	}
	#endregion

	#region Private methods
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
	#endregion
}
