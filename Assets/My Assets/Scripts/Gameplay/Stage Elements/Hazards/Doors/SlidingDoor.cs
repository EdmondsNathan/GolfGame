using UnityEngine;
using UnityEngine.Events;

public class SlidingDoor : MonoBehaviour
{
	#region Fields
	[SerializeField] private Transform _openPosition, _closedPosition;

	[SerializeField] private bool _isOpen = false;

	[SerializeField] private float _speed = 1;

	[SerializeField] private UnityEvent _onDoorOpened, _onDoorClosed;

	private ResetableValue<bool> _resetableIsOpen, _resetableHasFinishedMoving;

	private Transform _target;
	#endregion

	#region Properties
	public bool IsOpen
	{
		get => _resetableIsOpen.Value;
	}
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_resetableIsOpen = new ResetableValue<bool>(_isOpen);
		_resetableIsOpen.Subscribe();

		_resetableHasFinishedMoving = new ResetableValue<bool>(true);
		_resetableHasFinishedMoving.Subscribe();
	}

	protected void FixedUpdate()
	{
		_target = _resetableIsOpen.Value ? _openPosition : _closedPosition;
		transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.fixedDeltaTime);

		if (_resetableHasFinishedMoving.Value == true)
		{
			return;
		}

		if (transform.position != _target.position)
		{
			return;
		}

		if (_resetableIsOpen.Value == true)
		{
			_onDoorOpened?.Invoke();
		}
		else
		{
			_onDoorClosed?.Invoke();
		}

		_resetableHasFinishedMoving.Value = true;
	}

	protected void OnDestroy()
	{
		_resetableIsOpen.Unsubscribe();

		_resetableHasFinishedMoving.Unsubscribe();
	}
	#endregion

	#region Public methods
	public void ToggleDoor()
	{
		_resetableIsOpen.Value = !_resetableIsOpen.Value;

		_resetableHasFinishedMoving.Value = false;

		_target = _resetableIsOpen.Value ? _openPosition : _closedPosition;
	}

	public void SetDoor(bool state)
	{
		if (state == _resetableIsOpen.Value)
		{
			return;
		}

		_resetableIsOpen.Value = state;

		_resetableHasFinishedMoving.Value = false;

		_target = _resetableIsOpen.Value ? _openPosition : _closedPosition;
	}
	#endregion
}
