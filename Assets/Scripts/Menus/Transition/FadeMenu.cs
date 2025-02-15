using System.Collections;
using UnityEngine;

public class FadeMenu : MonoBehaviour
{
	[SerializeField] CanvasGroup _startingCanvasGroup;

	[SerializeField] private float _fadeInSpeed, _fadeOutSpeed;

	private CanvasGroup _previousCanvasGroup, _currentCanvasGroup;

	//float _targetAlpha;

	public void Awake()
	{
		_currentCanvasGroup = _startingCanvasGroup;
	}

	protected void Update()
	{
		//_canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, _targetAlpha, _speed * Time.deltaTime);

		_currentCanvasGroup.alpha = Mathf.Lerp(_currentCanvasGroup.alpha, 1, _fadeInSpeed * Time.deltaTime);

		if (_previousCanvasGroup != null)
		{
			_previousCanvasGroup.alpha = Mathf.Lerp(_previousCanvasGroup.alpha, 0, _fadeOutSpeed * Time.deltaTime);
		}

	}

	/*public void Fade(bool fadeIn)
	{
		if (fadeIn == true)
		{
			_targetAlpha = 1;
		}
		else
		{
			_targetAlpha = 0;
		}
	}*/

	public void FadeTransition(CanvasGroup canvasGroup)
	{
		//StartCoroutine(Fade(canvasGroup, 1));

		//StartCoroutine(Fade(_previousCanvasGroup, 0));

		_previousCanvasGroup = _currentCanvasGroup;

		_currentCanvasGroup = canvasGroup;

		_previousCanvasGroup.blocksRaycasts = false;

		_currentCanvasGroup.blocksRaycasts = true;
	}

	/*public void FadeIn(CanvasGroup canvasGroup)
	{
		StartCoroutine(Fade(canvasGroup, 1));

		_currentCanvasGroup = canvasGroup;
	}

	public void FadeOut(CanvasGroup canvasGroup)
	{
		StartCoroutine(Fade(canvasGroup, 0));

		_previousCanvasGroup = canvasGroup;
	}*/

	public void PreviousFade()
	{
		//StartCoroutine(Fade(_previousCanvasGroup, 1));

		//StartCoroutine(Fade(_currentCanvasGroup, 0));

		FadeTransition(_previousCanvasGroup);

		/*CanvasGroup previousCanvasGroup = _currentCanvasGroup;

		_currentCanvasGroup = _previousCanvasGroup;

		_previousCanvasGroup = previousCanvasGroup;*/
	}

	/*IEnumerator Fade(CanvasGroup canvasGroup, float targetValue)
	{
		while (canvasGroup.alpha != targetValue)
		{
			canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetValue, _speed * Time.deltaTime);

			yield return null;
		}
	}*/
}
