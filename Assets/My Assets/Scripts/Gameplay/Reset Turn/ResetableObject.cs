using System;
using UnityEngine;

public class ResetableObject : MonoBehaviour
{
	#region Private enums
	private enum ResetBehaviours
	{
		Disable,
		Destroy,
		Nothing
	}
	#endregion

	#region Fields
	[Tooltip("What to do if the object isn't in the resetable manager's List")]
	[SerializeField] private ResetBehaviours _resetBehaviourIfCreatedThisTurn = ResetBehaviours.Nothing;

	private Vector3 _lastPosition = new();

	private Quaternion _lastRotation = new();

	private Vector3 _lastScale = new();

	private Rigidbody2D _rigidbody;

	private Vector2 _lastLinearVelocity = new();

	private float _lastAngularVelocity;

	private bool _lastEnabled;
	#endregion

	#region Properties
	public Vector3 LastPosition
	{
		get
		{
			return _lastPosition;
		}
		set
		{
			_lastPosition = value;
		}
	}

	public Quaternion LastRotation
	{
		get
		{
			return _lastRotation;
		}
		set
		{
			_lastRotation = value;
		}
	}

	public Vector3 LastScale
	{
		get
		{
			return _lastScale;
		}
		set
		{
			_lastScale = value;
		}
	}

	public Rigidbody2D Body
	{
		get
		{
			return _rigidbody;
		}
		set
		{
			_rigidbody = value;
		}
	}

	public Vector2 LastLinearVelocity
	{
		get
		{
			return _lastLinearVelocity;
		}
		set
		{
			_lastLinearVelocity = value;
		}
	}

	public float LastAngularVelocity
	{
		get
		{
			return _lastAngularVelocity;
		}
		set
		{
			_lastAngularVelocity = value;
		}
	}

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

		Messages_Reset.OnTurnReset += OnTurnReset;
	}
	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_Reset.OnTurnReset -= OnTurnReset;
	}

	protected void Start()
	{
		//ResetableManager.Instance.AddResetable(this);
	}

	protected void OnDestroy()
	{
		//Makes sure a new singleton isn't instantiated when unloading the scene
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
		if (newState != GameState.StartTurn)
		{
			return;
		}

		if (ResetableManager.Instance.ContainsResetable(this) == true)
		{
			return;
		}

		ResetableManager.Instance.AddResetable(this);
	}

	private void OnTurnReset(bool countTurn)
	{
		if (ResetableManager.Instance.ContainsResetable(this) == true)
		{
			return;
		}

		switch (_resetBehaviourIfCreatedThisTurn)
		{
			case ResetBehaviours.Disable:
				gameObject.SetActive(_lastEnabled);
				break;
			case ResetBehaviours.Destroy:
				Destroy(gameObject);
				break;
			case ResetBehaviours.Nothing:
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}
	#endregion
}
