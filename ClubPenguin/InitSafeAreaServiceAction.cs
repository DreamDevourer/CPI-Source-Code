// InitSafeAreaServiceAction
using ClubPenguin;
using ClubPenguin.Configuration;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
[RequireComponent(typeof(InitConditionalConfigurationAction))]
public class InitSafeAreaServiceAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		int[] value = Service.Get<ConditionalConfiguration>().GetProperty<int[]>("Screen.SafeAreaOffset.property").Value;
		RectOffset safeAreaOffset = new RectOffset(value[0], value[1], value[2], value[3]);
		Service.Set(new SafeAreaService(safeAreaOffset));
		yield break;
	}
}
