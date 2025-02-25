using UnityEditor.Presets;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Grapple Joint")]
public class SO_GrappleJoint : ScriptableObject
{
	#region Fields
	[SerializeField] private Preset _jointPreset;
	#endregion

	#region Public methods
	public DistanceJoint2D AddJoint(GameObject owner)
	{
		/*Joint2D newJoint = _jointType switch
		{
			Joints.Distance => owner.AddComponent<DistanceJoint2D>(),
			Joints.Spring => owner.AddComponent<SpringJoint2D>(),
			_ => throw new System.NotImplementedException()
		};*/

		DistanceJoint2D newJoint = owner.AddComponent<DistanceJoint2D>();

		_jointPreset.ApplyTo(newJoint);

		return newJoint;
	}
	#endregion
}