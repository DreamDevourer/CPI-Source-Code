// InitLocalizerContentTokens
using ClubPenguin;
using DevonLocalization.Core;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitLocalizerSetupAction))]
[RequireComponent(typeof(InitCoreServicesAction))]
[RequireComponent(typeof(InitContentSystemAction))]
public class InitLocalizerContentTokens : InitActionComponent
{
	private bool tokensLoaded;

	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		AppTokensFilePath tokensFilePath = new AppTokensFilePath(Localizer.DEFAULT_TOKEN_LOCATION, Platform.global);
		Service.Get<Localizer>().LoadTokensFromContentSystem(tokensFilePath, onTokensLoaded);
		while (!tokensLoaded)
		{
			yield return null;
		}
	}

	private void onTokensLoaded(bool tokensUpdated)
	{
		tokensLoaded = true;
	}
}
