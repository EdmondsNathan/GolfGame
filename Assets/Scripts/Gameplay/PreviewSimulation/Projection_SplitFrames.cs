using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projection_SplitFrames : MonoBehaviour
{
	[SerializeField] private LineRenderer _line;
	[SerializeField] private int _maxPhysicsFrameIterations = 100;
	[SerializeField] private Transform _obstaclesParent;

	[SerializeField] private int _maxSimulationsPerFrame;

	private int _currentFrame = 0;

	private Scene _simulationScene;
	private PhysicsScene2D _physicsScene;
	private readonly Dictionary<Transform, Transform> _spawnedObjects = new();

	private List<ISimulationFixedUpdate> _simulators = new();

	private float _aimAngle;

	private float _chargeAmount;

	private GameObject _ghostBall;

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
	}

	public void OnAimChanged(float aimAngle)
	{
		_aimAngle = aimAngle;
	}

	public void OnChargeChanged(float chargeAmount)
	{
		_chargeAmount = chargeAmount;

		SimulateTrajectory();
	}

	public void OnStateEnter(GameState oldState, GameState newState)
	{
		if (newState == GameState.ShootBall)
		{
			// ClearLine();

			_currentFrame = 0;
		}
	}

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
		SceneManager.MoveGameObjectToScene(_ghostBall, _simulationScene);
	}

	public void SimulateTrajectory()
	{
		if (_currentFrame >= _maxPhysicsFrameIterations)
		{
			_currentFrame = 0;
		}

		if (_currentFrame == 0)
		{
			foreach (var item in _spawnedObjects)
			{
				item.Value.SetPositionAndRotation(item.Key.position, item.Key.rotation);
			}

			_ghostBall.GetComponent<Rigidbody2D>().position = GetGolfBall.Transform_GolfBall.position;
			_ghostBall.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
			_ghostBall.GetComponent<Rigidbody2D>().angularVelocity = 0;
			// _ghostBall.transform.SetPositionAndRotation(GetGolfBall.Transform_GolfBall.position, GetGolfBall.Transform_GolfBall.rotation);
			/* _ghostBall = Instantiate(GetGolfBall.GameObject_GolfBall, GetGolfBall.Transform_GolfBall.position, Quaternion.identity);
			SceneManager.MoveGameObjectToScene(_ghostBall.gameObject, _simulationScene); */

			float aimRad = _aimAngle * Mathf.Deg2Rad;

			Vector2 aimVector = new(Mathf.Cos(aimRad), Mathf.Sin(aimRad));

			// Debug.Log(_chargeAmount * aimVector);

			_ghostBall.GetComponent<Rigidbody2D>().AddForce(_chargeAmount * aimVector, ForceMode2D.Impulse);

			_line.positionCount = _maxPhysicsFrameIterations;
		}

		int stopPoint = _currentFrame + _maxSimulationsPerFrame < _maxPhysicsFrameIterations ? _currentFrame + _maxSimulationsPerFrame : _maxPhysicsFrameIterations;

		for (var i = _currentFrame; i < stopPoint; i++)
		{
			Debug.Log(i);
			_physicsScene.Simulate(Time.fixedDeltaTime);

			foreach (ISimulationFixedUpdate sim in _simulators)
			{
				sim.FixedUpdate_Simulation();
			}

			// Debug.Log(i + " " + _ghostBall.GetComponent<Rigidbody2D>().position);

			_line.SetPosition(i, _ghostBall.GetComponent<Rigidbody2D>().position);
		}

		_currentFrame = stopPoint >= _maxPhysicsFrameIterations ? 0 : stopPoint;

		// Destroy(_ghostBall.gameObject);
	}

	public void ClearLine()
	{
		_line.positionCount = 0;
	}
}