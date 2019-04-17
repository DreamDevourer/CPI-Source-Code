// InitFeatureToggleAction
using ClubPenguin;
using ClubPenguin.FeatureToggle;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
[RequireComponent(typeof(InitTweakerAction))]
[RequireComponent(typeof(InitGameDataAction))]
public class InitFeatureToggleAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		Service.Set(new FeatureToggleService());
		yield break;
	}
}
