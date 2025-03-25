using System;
using UnityEngine;

//Shelved: Make _abductedObject a rigidbody2D
public class UFO_AbductedObject : MonoBehaviour
{
	#region Fields
	private ResetableValue<GameObject> _resetableAbductedObject = new();
	#endregion

	#region Events
	public Action<GameObject> OnAbducted;
	#endregion

	#region Properties
	public GameObject AbductedObject
	{
		get => _resetableAbductedObject.Value;
		set => _resetableAbductedObject.Value = value;
	}
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_resetableAbductedObject.Subscribe();

		Messages_Reset.OnTurnReset += OnTurnReset;
	}

	protected void OnEnable()
	{
		OnAbducted += OnObjectAbducted;
	}

	protected void OnDisable()
	{
		OnAbducted -= OnObjectAbducted;
	}

	protected void OnDestroy()
	{
		_resetableAbductedObject.Unsubscribe();

		Messages_Reset.OnTurnReset -= OnTurnReset;
	}
	#endregion

	#region Event listener methods
	private void OnObjectAbducted(GameObject abductedObject)
	{
		AbductedObject = abductedObject;

		if (AbductedObject != null)
		{
			AbductedObject.SetActive(false);
		}

		Messages_OnObjectAbducted.OnObjectAbducted?.Invoke(AbductedObject, gameObject);
	}

	private void OnTurnReset(bool CountTurn)
	{
		OnAbducted?.Invoke(_resetableAbductedObject.ResetValue);
	}
	#endregion
}