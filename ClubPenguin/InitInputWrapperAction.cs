// InitInputWrapperAction
using ClubPenguin;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
public class InitInputWrapperAction : InitActionComponent
{
	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		GameObject gameObject = new GameObject("InputWrapper");
		gameObject.transform.SetParent(Service.Get<GameObject>().transform);
		InputWrapper instance = gameObject.AddComponent<InputWrapper>();
		Service.Set(instance);
		yield break;
	}
}
