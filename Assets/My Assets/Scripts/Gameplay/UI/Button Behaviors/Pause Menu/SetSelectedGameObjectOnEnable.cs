using UnityEngine;
using UnityEngine.EventSystems;

public class SetSelectedGameObjectOnEnable : MonoBehaviour
{
	#region Fields
	[SerializeField] private GameObject _defaultButton;
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		EventSystem.current.SetSelectedGameObject(_defaultButton);
	}
	#endregion
}
