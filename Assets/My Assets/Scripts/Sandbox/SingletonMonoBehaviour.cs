using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
	#region Fields
	private static T _instance;
	#endregion

	#region Properties
	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindFirstObjectByType<T>();

				if (_instance == null)
				{
					GameObject singleton = new GameObject(typeof(T).Name);

					_instance = singleton.AddComponent<T>();
				}
			}

			return _instance;
		}
	}
	#endregion

	#region Unity methods
	protected virtual void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this);

			return;
		}

		_instance = (T)this;
	}
	#endregion

	#region Public methods
	public static bool IsInstanceNull()
	{
		return _instance == null;
	}
	#endregion
}
