using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Obsolete]
public class Projection : MonoBehaviour
{
	#region Fields
	[SerializeField] private LineRenderer _line;
	[SerializeField] private int _maxPhysicsFrameIterations = 100;
	[SerializeField] private Transform _obstaclesParent;

	[SerializeField] private int _simulateFrequency;

	[SerializeField] private int _maxBounces = 1;

	[SerializeField] private int _bounceGraceFrames = 5;

	[SerializeField] private bool _clearLineOnShot = true;

	private int _currentFrequency;

	private int _lastBounceFrame;

	private int _bounceCount;

	private Scene _simulationScene;
	private PhysicsScene2D _physicsScene;
	private readonly Dictionary<Transform, Transform> _spawnedObjects = new();

	private List<ISimulationFixedUpdate> _simulators = new();

	private float _aimAngle;

	private float _chargeAmount;

	private GameObject _ghostBall;

	private BounceCounter _bounceCounter;
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		Messages_AimChanged.OnAimChanged += OnAimChanged;

		Messages_ChargeShot.OnChargeChanged += OnChargeChanged;

		Messages_GameStateChanged.OnStateEnter += OnStateEnter;
	}

	protected void OnDisable()
	{
		Messages_AimChanged.OnAimChanged -= OnAimChanged;

		Messages_ChargeShot.OnChargeChanged -= OnChargeChanged;

		Messages_GameStateChanged.OnStateEnter -= OnStateEnter;
	}

	private void Start()
	{
		CreatePhysicsScene();

		_currentFrequency = _simulateFrequency;
	}
	#endregion

	#region Event listener methods
	private void OnAimChanged(float aimAngle)
	{
		_aimAngle = aimAngle;
	}

	private void OnChargeChanged(float chargeAmount)
	{
		_chargeAmount = chargeAmount;

		_currentFrequency++;

		if (_currentFrequency >= _simulateFrequency)
		{
			SimulateTrajectory();

			_currentFrequency = 0;
		}
	}

	private void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.ShootBall)
		{
			SimulateTrajectory();

			if (_clearLineOnShot == true)
			{
				ClearLine();
			}
		}
		else if (newState == GameState.AimShot)
		{
			ClearLine();
		}
	}
	#endregion

	#region Public methods
	public void ClearLine()
	{
		_line.positionCount = 0;
	}

	public void SimulateTrajectory()
	{
		foreach (var item in _spawnedObjects)
		{
			item.Value.SetPositionAndRotation(item.Key.position, item.Key.rotation);
		}

		_ghostBall.GetComponent<Rigidbody2D>().position = GetGolfBall.Transform_GolfBall.position;
		_ghostBall.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
		_ghostBall.GetComponent<Rigidbody2D>().angularVelocity = 0;
		_bounceCounter.BounceCount = 0;
		_bounceCount = 0;
		_lastBounceFrame = 0;
		// _ghostBall.transform.SetPositionAndRotation(GetGolfBall.Transform_GolfBall.position, GetGolfBall.Transform_GolfBall.rotation);
		/* _ghostBall = Instantiate(GetGolfBall.GameObject_GolfBall, GetGolfBall.Transform_GolfBall.position, Quaternion.identity);
		SceneManager.MoveGameObjectToScene(_ghostBall.gameObject, _simulationScene); */

		float aimRad = _aimAngle * Mathf.Deg2Rad;

		Vector2 aimVector = new(Mathf.Cos(aimRad), Mathf.Sin(aimRad));

		// Debug.Log(_chargeAmount * aimVector);

		_ghostBall.GetComponent<Rigidbody2D>().AddForce(_chargeAmount * aimVector, ForceMode2D.Impulse);

		_line.positionCount = _maxPhysicsFrameIterations;

		for (var i = 0; i < _maxPhysicsFrameIterations; i++)
		{
			_physicsScene.Simulate(Time.fixedDeltaTime);

			foreach (ISimulationFixedUpdate sim in _simulators)
			{
				sim.FixedUpdate_Simulation();
			}

			// Debug.Log(i + " " + _ghostBall.GetComponent<Rigidbody2D>().position);

			_line.SetPosition(i, _ghostBall.GetComponent<Rigidbody2D>().position);

			if (_bounceCount != _bounceCounter.BounceCount)
			{
				if (i - _lastBounceFrame <= _bounceGraceFrames)
				{
					_bounceCounter.BounceCount = _bounceCount;
				}
				else
				{
					_bounceCount = _bounceCounter.BounceCount;

					_lastBounceFrame = i;
				}
			}

			if (_bounceCount > _maxBounces)
			{
				_line.positionCount = i;

				break;
			}
		}

		// Destroy(_ghostBall.gameObject);
	}
	#endregion

	#region Private methods
	private void CreatePhysicsScene()
	{
		_simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics2D));
		_physicsScene = _simulationScene.GetPhysicsScene2D();

		foreach (Transform obj in _obstaclesParent)
		{
			var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
			ghostObj.GetComponent<Renderer>().enabled = false;
			SceneManager.MoveGameObjectToScene(ghostObj, _simulationScene);
			if (!ghostObj.isStatic) _spawnedObjects.Add(obj, ghostObj.transform);

			foreach (ISimulationFixedUpdate sim in ghostObj.GetComponents<ISimulationFixedUpdate>())
			{
				_simulators.Add(sim);
			}
		}

		_ghostBall = Instantiate(GetGolfBall.GameObject_GolfBall, GetGolfBall.Transform_GolfBall.position, Quaternion.identity);
		_ghostBall.GetComponent<Renderer>().enabled = false;
		_bounceCounter = _ghostBall.AddComponent<BounceCounter>();
		SceneManager.MoveGameObjectToScene(_ghostBall, _simulationScene);
	}

	#endregion
}