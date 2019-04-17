// InitDecorationInventoryServiceAction
using ClubPenguin;
using ClubPenguin.DecorationInventory;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitGameDataAction))]
[RequireComponent(typeof(InitCoreServicesAction))]
[RequireComponent(typeof(InitDataModelAction))]
public class InitDecorationInventoryServiceAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		Service.Set(new DecorationInventoryService());
		yield break;
	}
}
