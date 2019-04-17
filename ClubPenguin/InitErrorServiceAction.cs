// InitErrorServiceAction
using ClubPenguin;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitGameStateControllerAction))]
[RequireComponent(typeof(InitCoreServicesAction))]
[RequireComponent(typeof(InitZoneTransitionServiceAction))]
public class InitErrorServiceAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		Service.Set(new ErrorService());
		yield break;
	}
}
