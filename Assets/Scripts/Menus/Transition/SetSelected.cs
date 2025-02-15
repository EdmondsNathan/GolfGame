using UnityEngine;
using UnityEngine.EventSystems;

public class SetSelected : MonoBehaviour
{
	private GameObject _previousSelected, _currentSelected;

	public void SetSelectedGameObject(GameObject selected)
	{
		EventSystem.current.SetSelectedGameObject(selected);

		_previousSelected = _currentSelected;

		_currentSelected = selected;
	}

	public void SetPreviousSelected()
	{
		SetSelectedGameObject(_previousSelected);

		/*EventSystem.current.SetSelectedGameObject(_previousSelected);

		GameObject previousSelected = _currentSelected;

		_currentSelected = _previousSelected;

		_previousSelected = previousSelected;*/
	}
}
