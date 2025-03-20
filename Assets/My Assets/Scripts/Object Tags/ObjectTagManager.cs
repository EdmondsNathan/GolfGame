using System.Collections.Generic;
using UnityEngine;

public static class ObjectTagManager
{
	#region Fields
	private static List<ObjectTags> _taggedObjects = new();
	#endregion

	#region Public methods
	public static void AddObject(ObjectTags objectTags)
	{
		_taggedObjects.Add(objectTags);
	}

	public static void RemoveObject(ObjectTags objectTags)
	{
		_taggedObjects.Remove(objectTags);
	}

	public static bool TryFindFirstObjectWithTag(Tag tag, out GameObject go)
	{
		foreach (ObjectTags objectTags in _taggedObjects)
		{
			if (objectTags.ContainsTag(tag))
			{
				go = objectTags.gameObject;

				return true;
			}
		}

		go = null;

		return false;
	}

	public static bool TryFindFirstObjectWithTag(Tag tag, out Transform t)
	{
		if (TryFindFirstObjectWithTag(tag, out GameObject go))
		{
			t = go.transform;

			return true;
		}

		t = null;

		return false;
	}

	public static List<GameObject> FindAllObjectsWithTag(Tag tag)
	{
		List<GameObject> objects = new();

		foreach (ObjectTags objectTags in _taggedObjects)
		{
			if (objectTags.ContainsTag(tag))
			{
				objects.Add(objectTags.gameObject);
			}
		}

		return objects;
	}

	public static bool ContainsTag(this Component component, Tag tag)
	{
		ObjectTags objectTags = component.GetComponent<ObjectTags>();

		if (objectTags == null)
		{
			return false;
		}

		return objectTags.ContainsTag(tag);
	}
	#endregion

	#region Private methods
	private static bool ContainsTag(this ObjectTags objectTags, Tag tag)
	{
		return objectTags.Tags.Contains(tag);
	}
	#endregion
}