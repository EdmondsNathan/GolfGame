using System.Collections;
using UnityEngine;

public class MenuFader : MonoBehaviour
{
	#region Fields
	[SerializeField] private CanvasGroup _startingCanvasGroup;

	[SerializeField] private float _fadeInSpeed, _fadeOutSpeed;

	private CanvasGroup _previousCanvasGroup, _currentCanvasGroup;
	#endregion

	#region Unity methods
	public void Awake()
	{
		_currentCanvasGroup = _startingCanvasGroup;
	}

	protected void Update()
	{
		_currentCanvasGroup.alpha = Mathf.Lerp(_currentCanvasGroup.alpha, 1, _fadeInSpeed * Time.deltaTime);

		if (_previousCanvasGroup != null)
		{
			_previousCanvasGroup.alpha = Mathf.Lerp(_previousCanvasGroup.alpha, 0, _fadeOutSpeed * Time.deltaTime);
		}

	}
	#endregion

	#region Public methods
	public void FadeTransition(CanvasGroup canvasGroup)
	{
		if (_previousCanvasGroup != null)
		{
			_previousCanvasGroup.alpha = 0;
		}

		_previousCanvasGroup = _currentCanvasGroup;

		_currentCanvasGroup = canvasGroup;

		_previousCanvasGroup.blocksRaycasts = false;

		_currentCanvasGroup.blocksRaycasts = true;
	}
	#endregion
}
