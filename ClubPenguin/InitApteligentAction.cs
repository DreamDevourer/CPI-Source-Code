// InitApteligentAction
using ClubPenguin;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitContentSchedulerServiceAction))]
[RequireComponent(typeof(InitCoreServicesAction))]
public class InitApteligentAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		GameObject gameObject = Service.Get<GameObject>();
		Crittercism crittercism = gameObject.GetComponent<Crittercism>();
		if (crittercism == null)
		{
			crittercism = gameObject.AddComponent<Crittercism>();
		}
		Service.Set(crittercism);
		if (new DateTime(2018, 12, 21, 0, 0, 0).Date < DateTime.Now.Date || Service.Get<GameSettings>().OfflineMode)
		{
			crittercism.Init(postShudown: true, new NullErrorLogger());
			yield break;
		}
		StandaloneErrorLogger errorLogger = new StandaloneErrorLogger();
		crittercism.Init(postShudown: false, errorLogger);
	}
}
