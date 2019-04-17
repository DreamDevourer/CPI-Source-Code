// ScavengerHuntHiderProp
using ClubPenguin.Game.PartyGames;
using ClubPenguin.Props;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;

[RequireComponent(typeof(PropAccessory))]
[RequireComponent(typeof(Prop))]
public class ScavengerHuntHiderProp : MonoBehaviour
{
	public GameObject MarbleProp;

	private PropAccessory propAccessory;

	private EventDispatcher eventDispatcher;

	private EventChannel eventChannel;

	private void Awake()
	{
		propAccessory = GetComponent<PropAccessory>();
		eventDispatcher = Service.Get<EventDispatcher>();
		eventChannel = new EventChannel(eventDispatcher);
		eventChannel.AddListener<ScavengerHuntEvents.ShowHiderClockProp>(onShowHiderClockProp);
	}

	private void OnDestroy()
	{
		eventChannel.RemoveAllListeners();
	}

	private bool onShowHiderClockProp(ScavengerHuntEvents.ShowHiderClockProp e)
	{
		MarbleProp.SetActive(value: false);
		eventChannel.RemoveAllListeners();
		if (propAccessory.PropAccessoryGO != null)
		{
			propAccessory.PropAccessoryGO.SetActive(value: true);
		}
		return false;
	}
}
