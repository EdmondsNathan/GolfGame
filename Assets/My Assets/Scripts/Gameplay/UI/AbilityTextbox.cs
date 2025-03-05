using System;
using TMPro;
using UnityEngine;

public class AbilityTextbox : MonoBehaviour
{
	#region Fields
	[SerializeField] private TMP_Text _textbox;
	#endregion

	#region Unity methods
	private void Start()
	{
		ObjectTagManager.TryFindFirstObjectWithTag(Tag.Ability, out GameObject ability);

		_textbox.text = ability.GetComponent<ObjectName>().Name;
	}
	#endregion
}
