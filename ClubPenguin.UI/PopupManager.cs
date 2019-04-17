// PopupManager
using ClubPenguin;
using ClubPenguin.Core;
using ClubPenguin.UI;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class PopupManager : BasePopupManager
{
	private void Awake()
	{
		eventChannel = new EventChannel(Service.Get<EventDispatcher>());
		eventChannel.AddListener<PopupEvents.ShowPopup>(onShowPopup);
		ClubPenguin.SceneRefs.SetPopupManager(this);
		ClubPenguin.Core.SceneRefs.Set(this);
		Service.Get<EventDispatcher>().DispatchEvent(default(PopupEvents.PopupManagerReady));
	}

	private bool onShowPopup(PopupEvents.ShowPopup evt)
	{
		showPopup(evt.Popup, evt.DestroyPopupOnBackPressed, evt.ScaleToFit);
		return false;
	}
}
