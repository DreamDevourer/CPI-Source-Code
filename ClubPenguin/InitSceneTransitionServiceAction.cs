// InitSceneTransitionServiceAction
using ClubPenguin;
using ClubPenguin.Core;
using ClubPenguin.Core.StaticGameData;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitContentSystemAction))]
[RequireComponent(typeof(InitCoreServicesAction))]
[RequireComponent(typeof(InitGuiAction))]
public class InitSceneTransitionServiceAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		GameObject go = Service.Get<GameObject>();
		SceneTransitionService service = go.AddComponent<SceneTransitionService>();
		ManifestContentKey sceneDefinitionManifestContentKey = StaticGameDataUtils.GetManifestContentKey(typeof(SceneDefinition));
		AssetRequest<Manifest> assetRequest = Content.LoadAsync(sceneDefinitionManifestContentKey);
		yield return assetRequest;
		if (assetRequest != null)
		{
			service.SetScenesFromManifest(assetRequest.Asset);
		}
		Service.Set(service);
	}
}
