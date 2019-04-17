// InitAllAccessServiceAction
using ClubPenguin;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
public class InitAllAccessServiceAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		AllAccessService instance = new AllAccessService();
		Service.Set(instance);
		yield break;
	}
}
