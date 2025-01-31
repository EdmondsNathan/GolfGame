using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Card")]
public class SO_Card : ScriptableObject
{
	[SerializeField] public string CardName;

	[SerializeField] public string CardDescription;

	//[SerializeField] public CardAction _cardAction;
}
