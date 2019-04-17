// InitApplicationServiceAction
using ClubPenguin;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using Tweaker.Core;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
public class InitApplicationServiceAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	[Invokable("Content.ForceRequireUpgrade")]
	private static void ForceRequireUpgrade()
	{
		Service.Get<ApplicationService>().RequiresUpdate = true;
	}

	public override IEnumerator PerformFirstPass()
	{
		GameObject gameObject = Service.Get<GameObject>();
		ApplicationService instance = gameObject.AddComponent<ApplicationService>();
		Service.Set(instance);
		yield break;
	}
}
