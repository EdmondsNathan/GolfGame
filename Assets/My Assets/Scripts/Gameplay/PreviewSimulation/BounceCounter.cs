using UnityEngine;

public class BounceCounter : MonoBehaviour
{
	#region Fields
	private int _bounceCount = 0;
	#endregion

	#region Properties
	public int BounceCount
	{
		get
		{
			return _bounceCount;
		}
		set
		{
			_bounceCount = value;
		}
	}
	#endregion Properties

	#region Unity methods
	protected void OnCollisionEnter2D(Collision2D collision)
	{
		BounceCount++;
	}
	#endregion
}
