using UnityEngine;

public class SlideMenu : MonoBehaviour
{
	[SerializeField] private RectTransform _slidingCanvas;

	[SerializeField] private float _speed;

	private Vector2 _targetLocation;

	private Vector2 _previousTarget = Vector2.zero;

	protected void Update()
	{
		_slidingCanvas.anchoredPosition = Vector2.Lerp(_slidingCanvas.anchoredPosition, _targetLocation, _speed * Time.deltaTime);
	}

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
}