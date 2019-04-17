// ClearCurrentLayoutButton
using ClubPenguin.Igloo;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;

public class ClearCurrentLayoutButton : MonoBehaviour
{
	public void Click()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(IglooUIEvents.ClearCurrentLayout));
	}
}
