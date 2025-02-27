using UnityEngine;

public class ResetableObject : MonoBehaviour
{
	#region Fields
	private Vector3 _lastPosition = new();

	private Quaternion _lastRotation = new();

	private Vector3 _lastScale = new();

	private Vector2 _lastLinearVelocity = new();

	private float _lastAngularVelocity;

	private Rigidbody2D _rigidbody;

	private bool _lastEnabled;
	#endregion

	#region Properties
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
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	protected void Start()
	{
		ResetableManager.Instance.AddResetable(this);
	}

	protected void OnDestroy()
	{
		if (ResetableManager.IsInstanceNull() == true)
		{
			return;
		}

		ResetableManager.Instance.RemoveResetable(this);
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.AimShot)
		{
			return;
		}

		_lastPosition = transform.position;

		_lastRotation = transform.rotation;

		_lastScale = transform.localScale;

		if (_rigidbody != null)
		{
			_lastLinearVelocity = _rigidbody.linearVelocity;

			_lastAngularVelocity = _rigidbody.angularVelocity;
		}
	}
	#endregion

	#region Public methods
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
	#endregion
}
