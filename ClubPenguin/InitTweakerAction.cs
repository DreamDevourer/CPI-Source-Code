// InitTweakerAction
using ClubPenguin;
using ClubPenguin.Core;
using ClubPenguin.Net;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System;
using System.Collections;
using System.Collections.Generic;
using Tweaker;
using Tweaker.AssemblyScanner;
using Tweaker.Core;
using Tweaker.UI;
using UnityEngine;

[RequireComponent(typeof(InitContentSchedulerServiceAction))]
[RequireComponent(typeof(InitConditionalConfigurationAction))]
[RequireComponent(typeof(InitCoreServicesAction))]
[RequireComponent(typeof(InitGameDataAction))]
[RequireComponent(typeof(InitNetworkControllerAction))]
public class InitTweakerAction : InitActionComponent
{
	public TweakerConsoleController TweakerController;

	public ScheduledEventDateDefinition TweakerAvailableDate;

	public float CornerSizes = 0.1f;

	private static CacheableType<bool> enableTweaker = new CacheableType<bool>("tweaker.enabled", defaultValue: true);

	private Tweaker.Tweaker tweaker;

	private Scanner scanner;

	private TweakerSerializer serializer;

	private bool showTweakerClicked = false;

	public override bool HasCompletedPass => false;

	public override bool HasSecondPass => true;

	[Invokable("Tweaker.Disable", Description = "WARNING this will prevent Tweaker from starting up on the next boot.  To re-enable tweaker hit the button during boot and restart the app once more.")]
	public static void DisableTweaker()
	{
		enableTweaker.SetValue(value: false);
	}

	public override IEnumerator PerformFirstPass()
	{
		if (!enableTweaker.Value || Service.Get<ContentSchedulerService>().IsBeforeScheduleEventDates(TweakerAvailableDate))
		{
			yield break;
		}
		LogManager.Set(new TweakerLogManager());
		tweaker = new Tweaker.Tweaker();
		scanner = new Scanner();
		ScanOptions scanOptions = new ScanOptions
		{
			Assemblies = 
			{
				NameRegex = string.Join("|", ClientInfo.Instance.GameAssemblyNames)
			}
		};
		TweakerOptions tweakerOptions = new TweakerOptions
		{
			Flags = (TweakerOptionFlags.ScanForInvokables | TweakerOptionFlags.ScanForTweakables | TweakerOptionFlags.ScanForWatchables | TweakerOptionFlags.DoNotAutoScan)
		};
		tweaker.Init(tweakerOptions, scanner);
		serializer = new TweakerSerializer(scanner);
		TweakablesClassList tweakablesClassList = Content.LoadImmediate<TweakablesClassList>("TweakableClassList");
		for (int i = 0; i < tweakablesClassList.AssemblyList.Count; i++)
		{
			if (tweakablesClassList.AssemblyList[i] != null)
			{
				Type type = Type.GetType(tweakablesClassList.AssemblyList[i]);
				if (type != null)
				{
					tweaker.Scanner.ScanType(type);
				}
			}
		}
		Service.Set(TweakerController);
		TweakerController.Init(tweaker, serializer);
		TweakerController.gameObject.SetActive(value: false);
		yield return new WaitForSeconds(1.5f);
	}

	public override IEnumerator PerformSecondPass()
	{
		if (enableTweaker.Value && !Service.Get<ContentSchedulerService>().IsBeforeScheduleEventDates(TweakerAvailableDate))
		{
			HashSet<object> scannedInstances = new HashSet<object>();
			foreach (object allService in Service.AllServices)
			{
				if (!scannedInstances.Contains(allService))
				{
					scannedInstances.Add(allService);
					scanner.ScanInstance(allService);
				}
			}
			scanner.ScanInstance(Service.Get<INetworkServicesManager>().RewardService);
			scanner.ScanInstance(Service.Get<INetworkServicesManager>().InventoryService);
			scanner.ScanInstance(Service.Get<INetworkServicesManager>().MinigameService);
			scanner.ScanInstance(Service.Get<INetworkServicesManager>().IAPService);
			scanner.ScanInstance(Service.Get<INetworkServicesManager>().TutorialService);
			scanner.ScanInstance(Service.Get<INetworkServicesManager>().BreadcrumbService);
			yield return checkShowTweaker();
			base.enabled = false;
		}
	}

	private IEnumerator checkShowTweaker()
	{
		if (showTweakerClicked)
		{
			TweakerController.gameObject.SetActive(value: true);
			while (TweakerController.isActiveAndEnabled)
			{
				yield return null;
			}
		}
	}
}
