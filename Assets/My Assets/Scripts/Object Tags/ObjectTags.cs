using System.Collections.Generic;
using UnityEngine;

public enum Tag
{
	IgnoreTeleporters
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

	public bool ContainsTag(Tag tag)
	{
		return _tags.Contains(tag);
	}
}
