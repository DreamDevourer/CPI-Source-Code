// InitModerationNotificationServiceAction
using ClubPenguin;
using ClubPenguin.UI;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
public class InitModerationNotificationServiceAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		Service.Get<GameObject>().AddComponent<ModerationNotificationService>();
		yield break;
	}
}
