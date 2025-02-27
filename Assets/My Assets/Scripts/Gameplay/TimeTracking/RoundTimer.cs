using UnityEngine;

public class RoundTimer : MonoBehaviour
{
	#region Fields
	private static RoundTimer _instance;

	private float _startingRealTime = -1f;

	private float _startingGameTime = -1f;
	#endregion

	#region Properties
	public static RoundTimer Instance
	{
		get
		{
			return _instance;
		}
	}

	public float RealTime
	{
		get
		{
			if (_startingRealTime < 0)
			{
				return 0;
			}

			return Time.unscaledTime - _startingRealTime;
		}
	}

	public float GameTime
	{
		get
		{
			if (_startingGameTime < 0)
			{
				return 0;
			}

			return Time.time - _startingGameTime;
		}
	}

	#endregion

	#region Unity methods
	protected void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
		}
	}

	protected void OnEnable()
	{
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;

		Messages_AimAbility.OnAimAbility += OnAimAbility;
	}

	protected void OnDisable()
	{
		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;

		Messages_AimAbility.OnAimAbility -= OnAimAbility;
	}

	protected void Start()
	{

	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.ChargeShot)
		{
			return;
		}

		if (_startingRealTime > 0)
		{
			return;
		}

		SetTimers();
	}

	private void OnAimAbility(Vector2 aimVector)
	{
		if (_startingRealTime > 0)
		{
			return;
		}

		SetTimers();
	}
	#endregion

	#region Private methods
	private void SetTimers()
	{
		_startingRealTime = Time.unscaledTime;

		_startingGameTime = Time.time;
	}
	#endregion
}