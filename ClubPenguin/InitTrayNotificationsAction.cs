// InitTrayNotificationsAction
using ClubPenguin;
using ClubPenguin.UI;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitGuiAction))]
[RequireComponent(typeof(InitCoreServicesAction))]
public class InitTrayNotificationsAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		TrayNotificationManager trayNotificationManager = new TrayNotificationManager();
		Service.Set(trayNotificationManager);
		RectTransform rectTransform = Service.Get<Canvas>().transform.Find("NotificationContainer") as RectTransform;
		if (rectTransform != null)
		{
			trayNotificationManager.SetParentRectTransform(rectTransform);
		}
		else
		{
			Log.LogError(this, "Could not find notification container in service canvas");
		}
		yield break;
	}
}
