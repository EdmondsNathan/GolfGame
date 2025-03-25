using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPointDecider_Base : MonoBehaviour
{
	#region Abstract methods
	public abstract Transform DecideSpawnPoint(List<Transform> spawnPoints);
	#endregion
}