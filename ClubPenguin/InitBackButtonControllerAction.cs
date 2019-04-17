// InitBackButtonControllerAction
using ClubPenguin;
using ClubPenguin.UI;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
public class InitBackButtonControllerAction : InitActionComponent
{
	[SerializeField]
	private BackButtonController backButtonController = null;

	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	private void OnValidate()
	{
	}

	public override IEnumerator PerformFirstPass()
	{
		Service.Set(backButtonController);
		backButtonController.gameObject.SetActive(value: true);
		yield return null;
	}
}
