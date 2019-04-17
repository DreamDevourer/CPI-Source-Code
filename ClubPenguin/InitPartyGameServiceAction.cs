// InitPartyGameServiceAction
using ClubPenguin;
using ClubPenguin.Game.PartyGames;
using ClubPenguin.PartyGames;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
[RequireComponent(typeof(InitGameDataAction))]
public class InitPartyGameServiceAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		Service.Set(new PartyGameManager(new PartyGameSessionFactory()));
		yield break;
	}
}
