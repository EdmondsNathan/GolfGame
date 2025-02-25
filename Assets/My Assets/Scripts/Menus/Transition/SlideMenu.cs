using UnityEngine;

public class SlideMenu : MonoBehaviour
{
	#region Fields
	[SerializeField] private RectTransform _slidingCanvas;

	[SerializeField] private float _speed;

	private Vector2 _targetLocation;

	private Vector2 _previousTarget = Vector2.zero;
	#endregion

	#region Unity methods
	protected void Update()
	{
		_slidingCanvas.anchoredPosition = Vector2.Lerp(_slidingCanvas.anchoredPosition, _targetLocation, _speed * Time.deltaTime);
	}
	#endregion

	#region Public methods
	public void SetTarget(RectTransform target)
	{
		_previousTarget = _targetLocation;

		_targetLocation = -1 * target.anchoredPosition;
	}

	public void SelectPreviousTarget()
	{
		Vector2 previousTarget = _targetLocation;

		_targetLocation = _previousTarget;

		_previousTarget = previousTarget;
	}
	#endregion
}