// SceneLayoutSyncService
using ClubPenguin.Core;
using ClubPenguin.Net;
using ClubPenguin.Net.Domain.Decoration;
using ClubPenguin.Net.Domain.Scene;
using ClubPenguin.SceneLayoutSync;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System;
using System.Collections.Generic;
using System.Linq;

public class SceneLayoutSyncService
{
	public delegate ExtraLayoutInfo ExtraLayoutInfoLoader();

	private class IIglooUpdateLayoutErrorHandlerWrapper : IIglooUpdateLayoutErrorHandler
	{
		private IIglooUpdateLayoutErrorHandler errorHandler;

		private EventHandlerDelegate<IglooServiceEvents.IglooLayoutUpdated> successHandler;

		public IIglooUpdateLayoutErrorHandlerWrapper(EventHandlerDelegate<IglooServiceEvents.IglooLayoutUpdated> successHandler, IIglooUpdateLayoutErrorHandler errorHandler)
		{
			this.successHandler = successHandler;
			this.errorHandler = errorHandler;
		}

		public void OnUpdateLayoutError()
		{
			Service.Get<EventDispatcher>().RemoveListener(successHandler);
			errorHandler.OnUpdateLayoutError();
		}
	}

	private List<ExtraLayoutInfoLoader> extraLayoutInfoLoaders = new List<ExtraLayoutInfoLoader>();

	private Timer saveIglooLayoutChangesTimer;

	private Dictionary<SceneLayoutData, bool> sceneLayoutDataModified = new Dictionary<SceneLayoutData, bool>();

	public SceneLayoutSyncService(float syncPeriodSeconds)
	{
		System.Action callback = delegate
		{
			saveIglooLayoutChanges();
		};
		saveIglooLayoutChangesTimer = new Timer(syncPeriodSeconds, repeat: true, callback);
		CoroutineRunner.StartPersistent(saveIglooLayoutChangesTimer.Start(), this, "saveIglooLayoutChangesTimer");
	}

	public void AddExtraLayoutInfoLoader(ExtraLayoutInfoLoader loader)
	{
		extraLayoutInfoLoaders.Add(loader);
	}

	public void RemoveExtraLayoutInfoLoader(ExtraLayoutInfoLoader loader)
	{
		extraLayoutInfoLoaders.Remove(loader);
	}

	public void StartSyncingSceneLayoutData(SceneLayoutData sceneLayoutData)
	{
		if (!sceneLayoutDataModified.ContainsKey(sceneLayoutData))
		{
			sceneLayoutDataModified[sceneLayoutData] = false;
			sceneLayoutData.SceneLayoutDataUpdated += onSceneLayoutDataUpdated;
		}
	}

	public void StopSyncingSceneLayoutData(SceneLayoutData sceneLayoutData, System.Action onSyncStopped, IIglooUpdateLayoutErrorHandler errorHandler = null)
	{
		if (!sceneLayoutDataModified.ContainsKey(sceneLayoutData))
		{
			onSyncStopped.InvokeSafe();
			return;
		}
		saveIglooLayoutChanges(onSyncStopped, errorHandler);
		sceneLayoutData.SceneLayoutDataUpdated -= onSceneLayoutDataUpdated;
		sceneLayoutDataModified.Remove(sceneLayoutData);
	}

	private void onSceneLayoutDataUpdated(SceneLayoutData sceneLayoutData)
	{
		sceneLayoutDataModified[sceneLayoutData] = true;
	}

	private void saveIglooLayoutChanges(System.Action onSyncStopped = null, IIglooUpdateLayoutErrorHandler errorHandler = null)
	{
		bool flag = false;
		foreach (SceneLayoutData item in sceneLayoutDataModified.Keys.ToList())
		{
			if (sceneLayoutDataModified[item])
			{
				MutableSceneLayout mutableSceneLayout = new MutableSceneLayout();
				ConvertToMutableSceneLayout(mutableSceneLayout, item);
				foreach (ExtraLayoutInfoLoader extraLayoutInfoLoader in extraLayoutInfoLoaders)
				{
					ExtraLayoutInfo extraLayoutInfo = extraLayoutInfoLoader();
					mutableSceneLayout.extraInfo[extraLayoutInfo.Key] = extraLayoutInfo.Value;
				}
				EventHandlerDelegate<IglooServiceEvents.IglooLayoutUpdated> successHandler = null;
				successHandler = delegate
				{
					Service.Get<EventDispatcher>().RemoveListener(successHandler);
					onSyncStopped.InvokeSafe();
					return false;
				};
				Service.Get<EventDispatcher>().AddListener(successHandler);
				IIglooUpdateLayoutErrorHandlerWrapper errorHandler2 = new IIglooUpdateLayoutErrorHandlerWrapper(successHandler, errorHandler);
				Service.Get<INetworkServicesManager>().IglooService.UpdateIglooLayout(item.LayoutId, mutableSceneLayout, errorHandler2);
				sceneLayoutDataModified[item] = false;
				flag = true;
			}
		}
		if (!flag)
		{
			onSyncStopped.InvokeSafe();
		}
	}

	public static void ConvertToMutableSceneLayout(MutableSceneLayout mutableSceneLayout, SceneLayoutData sceneLayoutData)
	{
		mutableSceneLayout.zoneId = sceneLayoutData.LotZoneName;
		mutableSceneLayout.lightingId = sceneLayoutData.LightingId;
		mutableSceneLayout.musicId = sceneLayoutData.MusicTrackId;
		mutableSceneLayout.extraInfo = sceneLayoutData.ExtraInfo;
		mutableSceneLayout.decorationsLayout = new List<DecorationLayout>();
		foreach (DecorationLayoutData item2 in sceneLayoutData.GetLayoutEnumerator())
		{
			DecorationLayoutData current = item2;
			DecorationLayout item = default(DecorationLayout);
			ref DecorationLayout.Id id = ref item.id;
			DecorationLayoutData.ID id2 = current.Id;
			id.name = id2.Name;
			ref DecorationLayout.Id id3 = ref item.id;
			id2 = current.Id;
			id3.parent = id2.ParentPath;
			item.type = ((current.Type != 0) ? DecorationType.Structure : DecorationType.Decoration);
			item.definitionId = current.DefinitionId;
			item.position = current.Position;
			item.rotation = Quaternion.FromUnityQuaternion(current.Rotation);
			item.scale = current.UniformScale;
			item.customProperties = current.CustomProperties;
			mutableSceneLayout.decorationsLayout.Add(item);
		}
	}
}
