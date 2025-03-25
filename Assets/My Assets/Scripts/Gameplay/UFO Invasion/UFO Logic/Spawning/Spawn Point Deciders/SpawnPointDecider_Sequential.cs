using System.Collections.Generic;
using UnityEngine;

public class SpawnPointDecider_Sequential : SpawnPointDecider_Base
{
	#region Fields
	private int _index = 0;
	#endregion

	#region Override Methods
	public override Transform DecideSpawnPoint(List<Transform> spawnPoints)
	{
		var nextSpawn = spawnPoints[_index];

		_index = (_index + 1) % spawnPoints.Count;

		return nextSpawn;
	}
	#endregion
}