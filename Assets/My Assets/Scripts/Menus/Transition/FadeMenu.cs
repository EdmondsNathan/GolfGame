using System.Collections;
using UnityEngine;

public class FadeMenu : MonoBehaviour
{
	[SerializeField] private CanvasGroup _startingCanvasGroup;

	[SerializeField] private float _fadeInSpeed, _fadeOutSpeed;

	//[SerializeField] private float _fadeTime = 1f;

	private CanvasGroup _previousCanvasGroup, _currentCanvasGroup;

	/*public CanvasGroup CurrentCanvasGroup
	{
		get
		{
			return _currentCanvasGroup;
		}
	}*/

	public CanvasGroup PreviousCanvasGroup
	{
		get
		{
			return _previousCanvasGroup;
		}
	}

	public void Awake()
	{
		_currentCanvasGroup = _startingCanvasGroup;
	}

	public void Start()
	{
		Messages_MenuChange.OnCanvasGroupChanged?.Invoke(_currentCanvasGroup);
	}

	protected void Update()
	{
		_currentCanvasGroup.alpha = Mathf.Lerp(_currentCanvasGroup.alpha, 1, _fadeInSpeed * Time.deltaTime);

		if (_previousCanvasGroup != null)
		{
			_previousCanvasGroup.alpha = Mathf.Lerp(_previousCanvasGroup.alpha, 0, _fadeOutSpeed * Time.deltaTime);
		}

	}

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

		Messages_MenuChange.OnCanvasGroupChanged?.Invoke(canvasGroup);
	}

	public void PreviousFade()
	{
		FadeTransition(_previousCanvasGroup);
	}

	/*IEnumerator Fade(CanvasGroup canvasGroup, float targetValue)
	{
		float currentTime = 0f;

		while (currentTime < _fadeTime)
		{
			currentTime += Time.deltaTime;

			yield return null;
		}
	}*/
}
