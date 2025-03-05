using UnityEngine;

public class DestroyEmptyObjects : MonoBehaviour
{
	protected void Start()
	{
		foreach (GameObject obj in FindObjectsByType<GameObject>(FindObjectsSortMode.None))
		{
			if (obj.transform.childCount == 0 && obj.GetComponents<Component>().Length == 1)
			{
				Destroy(obj);
			}
		}
	}
}
