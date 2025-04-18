using System.Collections.Generic;
using UnityEngine;

public class Rotate_FixedUpdate : MonoBehaviour
{
	#region Fields
	[SerializeField] private List<GameState> _activeStates;

	[SerializeField] private Vector3 _rotationAmount;

	[SerializeField] private Space _space = Space.World;
	#endregion

	#region Unity methods
	protected void FixedUpdate()
	{
		if (_activeStates.Contains(GameManager.CurrentState))
		{
			transform.Rotate(_rotationAmount * Time.fixedDeltaTime, _space);
		}
	}
	#endregion
}
