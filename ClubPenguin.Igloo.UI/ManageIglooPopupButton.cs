// ManageIglooPopupButton
using ClubPenguin.Igloo;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;

public class ManageIglooPopupButton : MonoBehaviour
{
	public void OnButtonClick()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(IglooUIEvents.OpenManageIglooPopup));
	}
}
