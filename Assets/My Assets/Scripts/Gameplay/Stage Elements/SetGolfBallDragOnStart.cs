using UnityEngine;

public class SetGolfBallDragOnStart : SingletonMonoBehaviour<SetGolfBallDragOnStart>
{
	#region Enums
	private enum DragSettings
	{
		Set,
		Multiply
	}
	#endregion

	#region Fields
	[SerializeField] private DragSettings _dragSetting = DragSettings.Multiply;

	[SerializeField] private float _drag = 1f;

	private float _defaultDrag;
	#endregion

	#region Unity methods
	protected void Start()
	{
		_defaultDrag = GetGolfBall.Rigidbody_GolfBall.linearDamping;

		switch (_dragSetting)
		{
			case DragSettings.Set:
				SetDrag(_drag);
				break;
			case DragSettings.Multiply:
				MultiplyDrag(_drag);
				break;
			default:
				break;
		}
	}
	#endregion

	#region Public methods
	public void SetDrag(float drag)
	{
		GetGolfBall.Rigidbody_GolfBall.linearDamping = drag;
	}

	public void MultiplyDrag(float drag)
	{
		SetDrag(GetGolfBall.Rigidbody_GolfBall.linearDamping * drag);
	}

	public void ResetDrag()
	{
		GetGolfBall.Rigidbody_GolfBall.linearDamping = _defaultDrag;
	}
	#endregion
}
