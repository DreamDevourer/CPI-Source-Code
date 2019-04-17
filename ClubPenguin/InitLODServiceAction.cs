// InitLODServiceAction
using ClubPenguin;
using ClubPenguin.LOD;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCustomGraphicsAction))]
public class InitLODServiceAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		LODService instance = new LODService();
		Service.Set(instance);
		yield break;
	}
}
