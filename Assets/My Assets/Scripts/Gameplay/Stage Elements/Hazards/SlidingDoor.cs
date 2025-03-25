using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
	#region Fields
	[SerializeField] private Transform _openPosition, _closedPosition;

	[SerializeField] private bool _isOpen = false;

	[SerializeField] private float _speed = 1;

	private Transform _target;
	#endregion

	#region Unity methods
	protected void FixedUpdate()
	{
		_target = _isOpen ? _openPosition : _closedPosition;

		transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.fixedDeltaTime);
	}
	#endregion

	#region Public methods
	public void ToggleDoor()
	{
		_isOpen = !_isOpen;
	}

	public void SetDoor(bool state)
	{
		_isOpen = state;
	}
	#endregion
}
