using UnityEngine;

public class UFO_TakeDamageWhenGolfBallIsAbducted : MonoBehaviour
{
	#region Fields
	[SerializeField] private UFO_Health _ufoHealth;

	[SerializeField] private UFO_AbductedObject _abductedObject;

	[SerializeField] private float _damagePerSecond;

	private bool _hasAbductedGolfBall = false;
	#endregion

	#region Unity methods
	protected void OnEnable()
	{
		_abductedObject.OnAbducted += OnAbducted;
	}

	protected void OnDisable()
	{
		_abductedObject.OnAbducted -= OnAbducted;
	}

	protected void Update()
	{
		if (_hasAbductedGolfBall == false)
		{
			return;
		}

		_ufoHealth.CurrentHealth -= _damagePerSecond * Time.deltaTime;
	}
	#endregion

	#region Event listener methods
	private void OnAbducted(GameObject abductedObject)
	{
		if (abductedObject == null)
		{
			_hasAbductedGolfBall = false;

			return;
		}

		if (abductedObject.ContainsTag(Tag.GolfBall) == false)
		{
			return;
		}

		_hasAbductedGolfBall = true;
	}
	#endregion
}
