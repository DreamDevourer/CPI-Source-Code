// EditActiveIglooButton
using ClubPenguin;
using ClubPenguin.Igloo;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using UnityEngine;

public class EditActiveIglooButton : MonoBehaviour
{
	public PrefabContentKey SplashScreenOverride;

	public void OnButtonClick()
	{
		long layoutId = Service.Get<SceneLayoutDataManager>().GetActiveSceneLayoutData().LayoutId;
		Service.Get<EventDispatcher>().DispatchEvent(new IglooUIEvents.SetStateButtonPressed(SceneStateData.SceneState.Edit, reloadScene: true, SplashScreenOverride, layoutId));
	}
}
