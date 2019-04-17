// AwayFromWorld
using ClubPenguin;
using ClubPenguin.Net;
using Disney.MobileNetwork;
using UnityEngine;

public class AwayFromWorld : MonoBehaviour
{
	public AwayFromKeyboardStateType AwayType = AwayFromKeyboardStateType.AwayFromWorld;

	public void Start()
	{
		if (Service.IsSet<INetworkServicesManager>())
		{
			Service.Get<INetworkServicesManager>().PlayerStateService.SetAwayFromKeyboard((int)AwayType);
		}
	}

	public void OnDestroy()
	{
		if (Service.IsSet<INetworkServicesManager>())
		{
			Service.Get<INetworkServicesManager>().PlayerStateService.SetAwayFromKeyboard(0);
		}
	}
}
