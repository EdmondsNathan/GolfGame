using UnityEngine;

public class BounceCounter : MonoBehaviour
{
	private int _bounceCount = 0;

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

	protected void OnCollisionEnter2D(Collision2D collision)
	{
		BounceCount++;
	}
}
