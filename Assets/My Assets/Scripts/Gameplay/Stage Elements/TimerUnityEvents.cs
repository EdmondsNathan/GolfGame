using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerUnityEvents : MonoBehaviour
{
	#region Fields
	[SerializeField] private List<UnityEvent> _onTimerElapsed;

	[SerializeField] private float _timer = 1f;

	private ResetableValue<float> _resetableCurrentTimer;

	private int _currentEventIndex = 0;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_resetableCurrentTimer = new ResetableValue<float>(0);

		_resetableCurrentTimer.Subscribe();
	}

	protected void Update()
	{
		_resetableCurrentTimer.Value += Time.deltaTime;

		if (_resetableCurrentTimer.Value < _timer)
		{
			return;
		}

		_resetableCurrentTimer.Value = 0;

		_onTimerElapsed[_currentEventIndex]?.Invoke();

		_currentEventIndex = (_currentEventIndex + 1) % _onTimerElapsed.Count;
	}

	protected void OnDestroy()
	{
		_resetableCurrentTimer.Unsubscribe();
	}
	#endregion
}
