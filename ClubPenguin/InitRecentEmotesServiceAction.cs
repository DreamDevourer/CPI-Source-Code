// InitRecentEmotesServiceAction
using ClubPenguin;
using ClubPenguin.Chat;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitGameDataAction))]
[RequireComponent(typeof(InitCoreServicesAction))]
public class InitRecentEmotesServiceAction : InitActionComponent
{
	public int RecentEmotesMaxCount;

	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		RecentEmotesService recentEmotesService = new RecentEmotesService();
		recentEmotesService.RecentEmotesMaxCount = RecentEmotesMaxCount;
		Service.Set(recentEmotesService);
		yield break;
	}
}
