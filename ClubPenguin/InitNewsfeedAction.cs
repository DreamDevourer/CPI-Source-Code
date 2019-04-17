// InitNewsfeedAction
using ClubPenguin;
using ClubPenguin.Newsfeed;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitNetworkControllerAction))]
[RequireComponent(typeof(InitDataModelAction))]
[RequireComponent(typeof(InitCoreServicesAction))]
[RequireComponent(typeof(InitLocalizerSetupAction))]
public class InitNewsfeedAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		NewsfeedController instance = Service.Get<GameObject>().AddComponent<NewsfeedController>();
		Service.Set(instance);
		yield break;
	}
}
