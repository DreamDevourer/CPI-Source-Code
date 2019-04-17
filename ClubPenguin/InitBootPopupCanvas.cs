// InitBootPopupCanvas
using ClubPenguin;
using ClubPenguin.UI;
using Disney.LaunchPadFramework;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
public class InitBootPopupCanvas : InitActionComponent
{
	public PopupManager PopupCanvas;

	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		yield break;
	}
}
