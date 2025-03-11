using UnityEngine;

public class MenuItem : MonoBehaviour
{
	#region Fields
	[SerializeField] private GameObject _defaultButton;
	[SerializeField] private RectTransform _rTransform;
	[SerializeField] private CanvasGroup _canvasGroupObject;
	#endregion

	#region Properties
	public GameObject DefaultButton
	{
		get
		{
			return _defaultButton;
		}
	}

	public RectTransform RTransform
	{
		get
		{
			return _rTransform;
		}
	}

	public CanvasGroup CanvasGroupObject
	{
		get
		{
			return _canvasGroupObject;
		}
	}
	#endregion
}