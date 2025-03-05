/*
 * Code taken from https://discussions.unity.com/t/expand-collapse-all-components-in-a-gameobject-refresh-issue/692006/18
 * From user OleksandrMartysh
 * */


using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using Object = UnityEngine.Object;

public static class MyEditorHotkeys
{
	// Hot key: ALT + W
	[MenuItem("Tools/Inspector/Collapse All &w")]
	public static void InspectorCollapseAll()
	{
		if (Selection.objects == null)
			return;

		foreach (Object obj in Selection.objects)
		{
			if (obj is GameObject go)
			{
				Component[] components = go.GetComponents<Component>();
				foreach (Component component in components)
				{
					InternalEditorUtility.SetIsInspectorExpanded(component, false);

					// Fix for renders and materials.
					if (component is Renderer)
					{
						Material[] mats = ((Renderer)component).sharedMaterials;
						for (int i = 0; i < mats.Length; ++i)
						{
							InternalEditorUtility.SetIsInspectorExpanded(mats[i], false);
						}
					}
				}
				ActiveEditorTracker.sharedTracker.ForceRebuild();
			}
		}
	}

	// Hot key: ALT + Q
	[MenuItem("Tools/Inspector/Expand All &q")]
	public static void InspectorExpandAll()
	{
		if (Selection.objects == null)
			return;

		foreach (Object obj in Selection.objects)
		{
			if (obj is GameObject go)
			{
				// GameObject gameObject = (command.context as Component).gameObject;
				Component[] components = go.GetComponents<Component>();
				foreach (Component component in components)
				{
					InternalEditorUtility.SetIsInspectorExpanded(component, true);

					//// Uncomment those lines to also expand materials.
					//// Fix for renders and materials.
					//if (component is Renderer) {
					//    Material[] mats = ((Renderer)component).sharedMaterials;
					//    for (int i = 0; i < mats.Length; ++i) {
					//        InternalEditorUtility.SetIsInspectorExpanded(mats[i], true);
					//    }
					//}
				}
				ActiveEditorTracker.sharedTracker.ForceRebuild();
			}
		}
	}
}