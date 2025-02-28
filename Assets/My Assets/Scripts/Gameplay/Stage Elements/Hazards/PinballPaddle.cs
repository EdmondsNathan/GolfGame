using UnityEngine;

public class PinballPaddle : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _cooldown = 1;

	[SerializeField] private float _torqueAmount = 5;

	private float _currentTimer = 0;

	private bool _activated = false;

	private Rigidbody2D _rigidbody;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	protected void Update()
	{
		if (_activated == false)
		{
			return;
		}

		_currentTimer += Time.deltaTime;

		if (_currentTimer >= _cooldown)
		{
			_rigidbody.AddTorque(-1 * _torqueAmount, ForceMode2D.Impulse);

			_activated = false;

			_currentTimer = 0;
		}
	}

	protected void OnCollisionStay2D(Collision2D collision)
	{
		if (_activated == true)
		{
			return;
		}
		_rigidbody.AddTorque(_torqueAmount, ForceMode2D.Impulse);

		_activated = true;
	}
	#endregion
}
