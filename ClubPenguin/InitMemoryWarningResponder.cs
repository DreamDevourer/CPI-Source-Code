// InitMemoryWarningResponder
using ClubPenguin;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitEnvironmentManagerAction))]
[RequireComponent(typeof(InitCoreServicesAction))]
public class InitMemoryWarningResponder : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		MemoryWarningResponder memoryWarningResponder = new MemoryWarningResponder();
		memoryWarningResponder.Init();
		Service.Set(memoryWarningResponder);
		yield break;
	}
}
