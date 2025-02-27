using UnityEngine;

public class ObjectName : MonoBehaviour
{
	#region Fields
	[SerializeField] private string _name;
	#endregion

	#region Properties
	public string Name
	{
		get
		{
			return _name;
		}
	}
	#endregion
}
