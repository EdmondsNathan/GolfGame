using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_LoadScene : MonoBehaviour
{
	[SerializeField] private string _sceneName = "SampleScene";

	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			SceneManager.LoadScene(_sceneName);
		}
	}
}
