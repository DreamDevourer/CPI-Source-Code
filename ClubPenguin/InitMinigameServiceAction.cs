// InitMinigameServiceAction
using ClubPenguin;
using ClubPenguin.Core;
using ClubPenguin.Core.StaticGameData;
using ClubPenguin.MiniGames;
using ClubPenguin.MiniGames.Fishing;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
[RequireComponent(typeof(InitContentSystemAction))]
public class InitMinigameServiceAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		ManifestContentKey lootRewardsManifestContentKey = StaticGameDataUtils.GetManifestContentKey(typeof(LootTableRewardDefinition));
		AssetRequest<Manifest> assetRequest = Content.LoadAsync(lootRewardsManifestContentKey);
		yield return assetRequest;
		MinigameService service = new MinigameService(assetRequest.Asset);
		Service.Set(service);
	}
}
