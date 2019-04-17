// InitIOSHapticFeedbackAction
using ClubPenguin;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using Disney.Native.iOS;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
public class InitIOSHapticFeedbackAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		iOSHapticFeedback instance = Service.Get<GameObject>().AddComponent<iOSHapticFeedback>();
		Service.Set(instance);
		yield break;
	}
}
