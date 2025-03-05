using System.Collections.Generic;
using UnityEngine;

public enum Tag
{
	IgnoreTeleporters,
	Goal,
	Ability
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

	#region Public methods
	public bool ContainsTag(Tag tag)
	{
		return _tags.Contains(tag);
	}
	#endregion
}
