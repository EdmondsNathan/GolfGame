/// <summary>
/// Make sure to call Subscribe() and Unsubscribe(), generally in Awake() and OnDestroy()
/// </summary>
/// <typeparam name="T"></typeparam>
public class ResetableValue<T>
{
	#region Fields
	private T _value;

	private T _resetValue;
	#endregion

	#region Properties
	public T Value
	{
		get => _value;
		set => _value = value;
	}

	public T ResetValue
	{
		get => _resetValue;
		set => _resetValue = value;
	}
	#endregion

	#region Constructors
	public ResetableValue() { }

	public ResetableValue(T value, T resetValue) : this()
	{
		Value = value;

		_resetValue = resetValue;
	}

	public ResetableValue(T value) : this(value, value) { }
	#endregion

	#region Event listener methods
	private void OnTurnReset(bool countTurn)
	{
		Value = _resetValue;
	}

	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.AimShot)
		{
			return;
		}
		_resetValue = Value;
	}
	#endregion

	#region Public methods
	public void Subscribe()
	{
		Messages_Reset.OnTurnReset += OnTurnReset;
		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	public void Unsubscribe()
	{
		Messages_Reset.OnTurnReset -= OnTurnReset;

		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}
	#endregion
}