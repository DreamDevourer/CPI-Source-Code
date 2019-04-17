// InitConditionalConfigurationAction
using ClubPenguin;
using ClubPenguin.Configuration;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
[RequireComponent(typeof(InitGameDataAction))]
public class InitConditionalConfigurationAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		ConditionalConfiguration instance = new ConditionalConfiguration(Service.Get<GameData>().Get<ConditionalDefinition[]>());
		Service.Set(instance);
		yield break;
	}
}
