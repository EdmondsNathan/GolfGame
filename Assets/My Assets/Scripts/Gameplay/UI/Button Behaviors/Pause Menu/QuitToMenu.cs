using UnityEngine;

public class QuitToMenu : MonoBehaviour
{
	#region Public methods
	public void Quit()
	{
		SceneLoader.Instance.LoadScene(SceneLoader.Instance.DefaultScene);
	}
	#endregion
}