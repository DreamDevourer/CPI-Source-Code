// InitConfiguratorAction
using ClubPenguin;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InitCoreServicesAction))]
public class InitConfiguratorAction : InitActionComponent
{
	public TextAsset ApplicationConfig;

	public override bool HasSecondPass => false;

	public override bool HasCompletedPass => false;

	public override IEnumerator PerformFirstPass()
	{
		Configurator configurator = new Configurator();
		configurator.Init(isUnitTest: false);
		Service.Set(configurator);
		LogConfigurator.Setup(configurator);
		yield break;
	}
}
