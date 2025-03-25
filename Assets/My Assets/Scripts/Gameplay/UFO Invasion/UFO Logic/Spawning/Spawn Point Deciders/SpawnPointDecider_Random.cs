using System.Collections.Generic;
using UnityEngine;

public class SpawnPointDecider_Random : SpawnPointDecider_Base
{
	#region Override Methods
	public override Transform DecideSpawnPoint(List<Transform> spawnPoints)
	{
		return spawnPoints[Random.Range(0, spawnPoints.Count)];
	}
	#endregion
}