using UnityEngine;

public class UFO_HealthBarSize : MonoBehaviour
{
	#region Fields
	[SerializeField] private UFO_Health _healthObject;

	[SerializeField] private float _drainSpeed;

	private RectTransform _rectTransform;

	private float _maxWidth;

	private float _maxHealth;

	private Vector2 _size = new();

	private float _targetSize;
	#endregion

	#region Unity methods
	protected void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();

		_size = _rectTransform.sizeDelta;

		_targetSize = _size.x;

		_maxWidth = _size.x;

		_maxHealth = _healthObject.MaxHealth;
	}

	protected void OnEnable()
	{
		_healthObject.OnHealthChanged += OnHealthChanged;
	}

	protected void OnDisable()
	{
		_healthObject.OnHealthChanged -= OnHealthChanged;
	}

	protected void Update()
	{
		SetSize(Mathf.Lerp(_size.x, _targetSize, Time.unscaledDeltaTime * _drainSpeed));
	}
	#endregion

	#region Event listener methods
	private void OnHealthChanged(float health)
	{
		float _oldTargetSize = _targetSize;

		_targetSize = health / _maxHealth * _maxWidth;

		if (Mathf.Abs(_size.x - _oldTargetSize) > 0.1f)
		{
			_size.x = _targetSize;
		}
	}

	private void SetSize(float size)
	{
		_size.x = size;

		_rectTransform.sizeDelta = _size;
	}
	#endregion
}
