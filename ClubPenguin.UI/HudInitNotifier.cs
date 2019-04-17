// HudInitNotifier
using ClubPenguin.UI;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

public class HudInitNotifier : MonoBehaviour
{
	private IEnumerator Start()
	{
		yield return null;
		Service.Get<EventDispatcher>().DispatchEvent(default(HudEvents.HudInitComplete));
	}
}
