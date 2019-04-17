// InitDiagnosticsAction
using ClubPenguin;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
public class InitDiagnosticsAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		? typeFromHandle2 = typeof(MemoryMonitorManager);
		Type typeFromHandle = typeof(MemoryMonitorWindowsManager);
		MemoryMonitorManager instance = Service.Get<GameObject>().AddComponent(typeFromHandle) as MemoryMonitorManager;
		Service.Set(instance);
		Performance performance = new Performance();
		performance.AutomaticMemorySampling = false;
		Service.Set(performance);
		yield break;
	}
}
