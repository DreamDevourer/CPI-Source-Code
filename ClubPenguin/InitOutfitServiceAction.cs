// InitOutfitServiceAction
using ClubPenguin;
using ClubPenguin.Avatar;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using Foundation.Unity;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitFibreServiceAction))]
[RequireComponent(typeof(InitCoreServicesAction))]
public class InitOutfitServiceAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		FibreService fibreService = Service.Get<FibreService>();
		OutfitService instance = new OutfitService(fibreService);
		Service.Set(instance);
		yield break;
	}
}
