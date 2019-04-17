// AccountSystemLifetimeNotifier
using ClubPenguin;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;

public class AccountSystemLifetimeNotifier : MonoBehaviour
{
	private void Start()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(AccountSystemEvents.AccountSystemCreated));
	}

	private void OnDestroy()
	{
		Service.Get<EventDispatcher>().DispatchEvent(default(AccountSystemEvents.AccountSystemDestroyed));
	}
}
