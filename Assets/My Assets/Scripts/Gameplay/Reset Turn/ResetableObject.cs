using UnityEngine;

public class ResetableObject : MonoBehaviour
{
	private Vector3 _lastPosition = new();

	private Quaternion _lastRotation = new();

	private Vector3 _lastScale = new();

	private Vector2 _lastLinearVelocity = new();

	private float _lastAngularVelocity;

	private Rigidbody2D _rigidbody;

	private bool _lastEnabled;

	public bool LastEnabled
	{
		get
		{
			return _lastEnabled;
		}
		set
		{
			_lastEnabled = value;
		}
	}

	protected void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		ResetableManager.Instance.AddResetable(this);
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	protected void OnDestroy()
	{
		ResetableManager.Instance.RemoveResetable(this);
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.AimShot)
		{
			_lastPosition = transform.position;

			_lastRotation = transform.rotation;

			_lastScale = transform.localScale;

			if (_rigidbody != null)
			{
				_lastLinearVelocity = _rigidbody.linearVelocity;

				_lastAngularVelocity = _rigidbody.angularVelocity;
			}
		}
	}

	public void Reset()
	{
		transform.position = _lastPosition;

		transform.rotation = _lastRotation;

		transform.localScale = _lastScale;

		if (_rigidbody != null)
		{
			_rigidbody.linearVelocity = _lastLinearVelocity;

			_rigidbody.angularVelocity = _lastAngularVelocity;
		}
	}
}
