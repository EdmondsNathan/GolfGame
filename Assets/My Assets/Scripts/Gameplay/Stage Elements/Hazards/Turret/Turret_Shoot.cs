using UnityEngine;

[DefaultExecutionOrder(100)]
[RequireComponent(typeof(Turret_AimTowardsGolfBall))]
public class Turret_Shoot : MonoBehaviour
{
	#region Fields
	[SerializeField] private GameObject _projectilePrefab;

	[SerializeField] private Transform _spawnPoint;

	[SerializeField] private float _fireRate;

	[SerializeField] private float _maxAngleToShoot;

	private Turret_AimTowardsGolfBall _turretAimer;

	private float _fireTimer, _resetTimer;
	#endregion

	#region Unity methods
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
		_turretAimer = GetComponent<Turret_AimTowardsGolfBall>();

		_fireTimer = 1 / _fireRate;
	}

	protected void Update()
	{
		if (Mathf.Abs(Mathf.DeltaAngle(_turretAimer.TargetAngle, _turretAimer.CurrentAngle)) > _maxAngleToShoot)
		{
			return;
		}

		_fireTimer += Time.deltaTime;

		if (_fireTimer < 1 / _fireRate)
		{
			return;
		}

		_fireTimer = 0;

		Instantiate(_projectilePrefab, _spawnPoint.position, _spawnPoint.rotation);
	}
	#endregion

	#region Event listener methods
	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState != GameState.StartTurn)
		{
			return;
		}

		_resetTimer = _fireTimer;
	}

	private void OnTurnReset(bool countTurn)
	{
		_fireTimer = _resetTimer;
	}
	#endregion
}
