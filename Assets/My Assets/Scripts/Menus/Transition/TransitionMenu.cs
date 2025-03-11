using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TransitionMenu : MonoBehaviour
{
	#region Fields
	[SerializeField] private MenuFader _menuFader;
	[SerializeField] private MenuRotator _menuRotator;
	[SerializeField] private List<Transform> _frontAndBackCanvases = new();
	[SerializeField] private MenuItem _startingMenuItem;
	[SerializeField] private bool _spinToFirstMenu = false;

	private Stack<MenuItem> _previousMenuItems = new();
	private int _sideIndex = 0;
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		Messages_MenuChange.OnGoToPreviousMenu += OnGoToPreviousMenu;
	}

	protected void OnDisable()
	{
		Messages_MenuChange.OnGoToPreviousMenu -= OnGoToPreviousMenu;
	}

	protected void Start()
	{
		if (_spinToFirstMenu == true)
		{
			OnGoToMenu(_startingMenuItem);
		}
		else
		{
			_previousMenuItems.Push(_startingMenuItem);
		}
	}
	#endregion

	#region Event listener methods
	public void OnGoToMenu(MenuItem menuItem)
	{
		_previousMenuItems.Push(menuItem);

		_sideIndex = (_sideIndex + 1) % 2;
		_menuRotator.Rotate();

		EventSystem.current.SetSelectedGameObject(menuItem.DefaultButton);

		_menuFader.FadeTransition(menuItem.CanvasGroupObject);

		SetupCanvas(menuItem.RTransform);
	}

	public void OnGoToPreviousMenu()
	{
		if (_previousMenuItems.Count < 2)
		{
			return;
		}

		// The current menu is in the last position, so we need to pop that off
		// in order to get the previous menu
		_previousMenuItems.Pop();
		OnGoToMenu(_previousMenuItems.Pop());
	}
	#endregion

	#region Private methods
	private void SetupCanvas(RectTransform rTransform)
	{
		rTransform.SetParent(_frontAndBackCanvases[_sideIndex], false);
		rTransform.anchoredPosition3D = Vector3.zero;
		rTransform.localEulerAngles = Vector3.zero;
	}
	#endregion
}