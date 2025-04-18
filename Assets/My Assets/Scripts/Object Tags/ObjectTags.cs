using System.Collections.Generic;
using UnityEngine;

public enum Tag
{
	IgnoreTeleporters,
	Goal,
	Ability,
	DestroyProjectiles,
	IgnoreKillboxes,
	Abductable,
	GolfBall
}

public class ObjectTags : MonoBehaviour
{
	#region Fields
	[SerializeField] private List<Tag> _tags = new();
	#endregion

	#region Properties
	public List<Tag> Tags
	{
		get
		{
			return _tags;
		}
	}
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		ObjectTagManager.AddObject(this);
	}

	protected void OnDisable()
	{
		ObjectTagManager.RemoveObject(this);
	}
	#endregion
}
