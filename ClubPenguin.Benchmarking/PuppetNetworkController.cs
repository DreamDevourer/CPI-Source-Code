// PuppetNetworkController
using ClubPenguin;
using UnityEngine;

internal class PuppetNetworkController : NetworkController
{
	public PuppetNetworkController(MonoBehaviour ctx)
		: base(ctx, offlineMode: false)
	{
	}
}
