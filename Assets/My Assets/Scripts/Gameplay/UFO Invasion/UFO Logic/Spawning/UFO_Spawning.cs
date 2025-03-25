using System.Collections.Generic;
using UnityEngine;

public class UFO_Spawning : MonoBehaviour
{
	#region Fields
	private List<Transform> _spawnPoints = new();

	[SerializeField] private GameObject _ufoPrefab;

	[SerializeField] private SpawnPointDecider_Base _spawnPointDecider;

	[SerializeField] private float _spawnHeightVariance;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_spawnPoints.AddRange(GetComponentsInChildren<Transform>());

		_spawnPoints.Remove(transform);
	}

	protected void OnEnable()
	{
		Messages_SpawnUFO.OnSpawnUFO += SpawnUFO;
	}

	protected void OnDisable()
	{
		Messages_SpawnUFO.OnSpawnUFO -= SpawnUFO;
	}
	#endregion

	#region Event listener methods
	private void SpawnUFO()
	{
		Instantiate(_ufoPrefab, _spawnPointDecider.DecideSpawnPoint(_spawnPoints).position + Vector3.up * Random.Range(-1 * _spawnHeightVariance, _spawnHeightVariance), Quaternion.identity);
	}
	#endregion
}
