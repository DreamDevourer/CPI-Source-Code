// InitTutorialServiceAction
using ClubPenguin;
using ClubPenguin.Tutorial;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
[RequireComponent(typeof(InitGameDataAction))]
[RequireComponent(typeof(InitDataModelAction))]
public class InitTutorialServiceAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		Service.Set(new TutorialManager());
		yield break;
	}
}
