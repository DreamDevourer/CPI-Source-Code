// InitInputServiceAction
using ClubPenguin;
using ClubPenguin.Input;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
[RequireComponent(typeof(InitContentSystemAction))]
[RequireComponent(typeof(InitDataModelServicesAction))]
public class InitInputServiceAction : InitActionComponent
{
	[SerializeField]
	private InputMapPriority inputMapPriority = null;

	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	private void OnValidate()
	{
	}

	public override IEnumerator PerformFirstPass()
	{
		AssetRequest<ControlScheme> controlSchemeAssetRequest = Content.LoadAsync<ControlScheme>("Input/ControlScheme");
		yield return controlSchemeAssetRequest;
		KeyCodeRemapper remapper = new KeyCodeRemapper();
		yield return remapper.Initialize();
		InputService service = Service.Get<GameObject>().AddComponent<InputService>();
		service.Initialize(controlSchemeAssetRequest.Asset, inputMapPriority, remapper);
		Service.Set(service);
	}
}
