using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TeleporterLineRenderer : MonoBehaviour
{
	#region Fields
	[SerializeField] private Transform _portal1, _portal2;

	[SerializeField] private float _zDepth;

	private LineRenderer lineRenderer;
	#endregion

	#region Unity methods
	private void Awake()
	{
		lineRenderer = GetComponent<LineRenderer>();

		Vector3[] positions = { _portal1.position, _portal2.position };

		positions[0].z = _zDepth;

		positions[1].z = _zDepth;

		lineRenderer.SetPositions(positions);
	}
	#endregion
}
