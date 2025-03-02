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

	public static bool TryFindFirstObjectWithTag(Tag tag, out GameObject gameObject)
	{
		foreach (ObjectTags objectTags in _taggedObjects)
		{
			if (objectTags.ContainsTag(tag))
			{
				gameObject = objectTags.gameObject;

				return true;
			}
		}

		gameObject = null;

		return false;
	}

	public static bool TryFindFirstObjectWithTag(Tag tag, out Transform t)
	{
		GameObject go;

		if (TryFindFirstObjectWithTag(tag, out go))
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
	#endregion
}