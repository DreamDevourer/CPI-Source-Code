// DecorationInventoryLoader
using ClubPenguin.Core;
using ClubPenguin.DecorationInventory;
using ClubPenguin.Net;
using Disney.MobileNetwork;
using UnityEngine;

public class DecorationInventoryLoader : MonoBehaviour
{
	private CPDataEntityCollection dataEntityCollection;

	private void Awake()
	{
		dataEntityCollection = Service.Get<CPDataEntityCollection>();
		if (!dataEntityCollection.HasComponent<DecorationInventoryData>(dataEntityCollection.LocalPlayerHandle))
		{
			Service.Get<INetworkServicesManager>().IglooService.GetDecorations();
		}
		Object.Destroy(this);
	}

	private void OnDestroy()
	{
	}
}
