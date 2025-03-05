using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButtonNavigationOnStart : MonoBehaviour
{
	#region Fields
	private List<Button> buttons = new();
	#endregion

	#region Unity methods
	protected void Start()
	{
		// iterate through all the active children of the transform and add the button component to the list
		foreach (Transform child in transform)
		{
			if (child.gameObject.activeSelf)
			{
				Button button = child.GetComponent<Button>();
				if (button != null)
				{
					buttons.Add(button);
				}
			}
		}

		// set the navigation of the buttons
		for (int i = 0; i < buttons.Count; i++)
		{
			Navigation navigator = buttons[i].navigation;

			navigator.mode = Navigation.Mode.Explicit;

			if (i == 0)
			{
				navigator.selectOnDown = buttons[1];

				navigator.selectOnUp = buttons[buttons.Count - 1];
			}
			else if (i == buttons.Count - 1)
			{
				navigator.selectOnDown = buttons[0];

				navigator.selectOnUp = buttons[buttons.Count - 2];
			}
			else
			{
				navigator.selectOnDown = buttons[i + 1];

				navigator.selectOnUp = buttons[i - 1];
			}

			buttons[i].navigation = navigator;
		}
	}
	#endregion
}
