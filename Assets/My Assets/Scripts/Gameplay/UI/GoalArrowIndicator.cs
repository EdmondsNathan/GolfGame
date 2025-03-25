using UnityEngine;

public class GoalArrowIndicator : MonoBehaviour
{
	#region Fields
	[SerializeField] private RectTransform _arrow;

	[SerializeField] private RectTransform _parentCanvas;

	[SerializeField] private Transform _goal;

	[SerializeField] private float _offset = 50;

	private float _factorX, _factorY, _factor;

	private Camera _camera;

	private bool _isGoalOffScreen = false;

	private Vector2 _direction;

	private Vector2 _arrowPosition = new();

	private Vector3 _screenPosition;
	#endregion

	#region Unity methods
	protected void Start()
	{
		_camera = Camera.main;

		if (_goal == null)
		{
			if (ObjectTagManager.TryFindFirstComponentWithTag(Tag.Goal, out _goal))
			{
				return;
			}

			Debug.LogWarning("Goal not found");

			this.enabled = false;
		}
	}

	protected void Update()
	{
		if (GameManager.CurrentState != GameState.AimShot && GameManager.CurrentState != GameState.ChargeShot)
		{
			_arrow.gameObject.SetActive(false);

			return;
		}

		UpdateArrow();
	}
	#endregion

	#region Private methods
	private void UpdateArrow()
	{
		_isGoalOffScreen = IsGoalOffScreen();

		_arrow.gameObject.SetActive(_isGoalOffScreen);

		if (_isGoalOffScreen == false)
		{
			return;
		}

		SetArrowRotation();

		SetArrowPosition();
	}

	private bool IsGoalOffScreen()
	{
		_screenPosition = _camera.WorldToScreenPoint(_goal.position);

		return _screenPosition.x < 0 || _screenPosition.x > Screen.width ||
			_screenPosition.y < 0 || _screenPosition.y > Screen.height;
	}

	private void SetArrowRotation()
	{
		_direction = (_goal.position - _camera.transform.position).normalized;

		_arrow.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg);
	}

	private void SetArrowPosition()
	{
		_factorX = _direction.x == 0 ? Mathf.Infinity : ((_parentCanvas.rect.width / 2) - _offset) / Mathf.Abs(_direction.x);

		_factorY = _direction.y == 0 ? Mathf.Infinity : ((_parentCanvas.rect.height / 2) - _offset) / Mathf.Abs(_direction.y);

		_factor = _factorX * Mathf.Abs(_direction.y) > ((_parentCanvas.rect.height / 2) - _offset) ? _factorY : _factorX;

		_arrowPosition.x = _factor * _direction.x;

		_arrowPosition.y = _factor * _direction.y;

		_arrow.anchoredPosition = _arrowPosition;
	}
	#endregion
}
