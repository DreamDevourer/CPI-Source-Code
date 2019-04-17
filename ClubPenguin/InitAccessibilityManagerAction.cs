// InitAccessibilityManagerAction
using ClubPenguin;
using DevonLocalization.Core;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using Disney.Native;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitLocalizerSetupAction))]
[RequireComponent(typeof(InitCoreServicesAction))]
public class InitAccessibilityManagerAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		MonoSingleton<NativeAccessibilityManager>.Instance.Init(Service.Get<Localizer>());
		GameObject gameObject = new GameObject("AccessibilityManager");
		gameObject.transform.SetParent(Service.Get<GameObject>().transform);
		gameObject.AddComponent<NativeAccessibility>();
		gameObject.AddComponent<AccessibilityManager>();
		yield break;
	}
}
