using UnityEngine;
using UnityEngine.EventSystems;

public class SetSelected : MonoBehaviour
{
	#region Fields
	private GameObject _previousSelected, _currentSelected;
	#endregion

	#region Properties
	public GameObject PreviousSelected
	{
		get
		{
			return _previousSelected;
		}
	}
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_currentSelected = EventSystem.current.firstSelectedGameObject;
	}

	protected void Start()
	{
		Messages_MenuChange.OnSelectedChanged?.Invoke(_currentSelected);
	}
	#endregion

	#region Public methods
	public void SetSelectedGameObject(GameObject selected)
	{
		EventSystem.current.SetSelectedGameObject(selected);

		_previousSelected = _currentSelected;

		_currentSelected = selected;

		Messages_MenuChange.OnSelectedChanged?.Invoke(selected);
	}

	public void SetPreviousSelected()
	{
		SetSelectedGameObject(_previousSelected);
	}
	#endregion
}
