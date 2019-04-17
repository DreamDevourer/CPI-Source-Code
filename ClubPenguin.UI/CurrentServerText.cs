// CurrentServerText
using ClubPenguin;
using ClubPenguin.Core;
using Disney.MobileNetwork;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CurrentServerText : MonoBehaviour
{
	public void Start()
	{
		CPDataEntityCollection cPDataEntityCollection = Service.Get<CPDataEntityCollection>();
		PresenceData component = cPDataEntityCollection.GetComponent<PresenceData>(cPDataEntityCollection.LocalPlayerHandle);
		if (component != null)
		{
			GetComponent<Text>().text = $"{component.World} ";
		}
	}
}
