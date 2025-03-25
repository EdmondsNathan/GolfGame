using UnityEngine;

public class AirlockToggle : MonoBehaviour
{
	#region Fields
	[SerializeField] private SlidingDoor _door1, _door2;
	#endregion

	#region Public methods
	public void ToggleAirlock()
	{
		var targetDoor = _door1.IsOpen ? _door1 : _door2;

		targetDoor.SetDoor(false);
	}
	#endregion
}
