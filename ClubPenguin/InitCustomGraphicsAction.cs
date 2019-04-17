// InitCustomGraphicsAction
using ClubPenguin;
using ClubPenguin.Analytics;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitConditionalConfigurationAction))]
[RequireComponent(typeof(InitCoreServicesAction))]
public class InitCustomGraphicsAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		CustomGraphicsService customGraphicsService = new CustomGraphicsService();
		customGraphicsService.Init();
		Service.Set(customGraphicsService);
		GameObject gameObject = Service.Get<GameObject>();
		gameObject.AddComponent<WindowResizeService>();
		string tier = Screen.width + "x" + Screen.height;
		Service.Get<ICPSwrveService>().Action("desktop_display_settings", "start_resolution", tier);
		yield break;
	}
}
