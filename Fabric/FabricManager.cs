// FabricManager
using Fabric;
using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Fabric/FabricManager")]
public class FabricManager : MonoBehaviour
{
	public enum OnApplicationPauseBehavior
	{
		IgnoreNone,
		IgnorePauseTrue,
		IgnorePauseFalse,
		IgnoreAll
	}

	public delegate void SpringBoardHandler();

	private static FabricManager _instance = null;

	private List<Fabric.Component> _components = new List<Fabric.Component>();

	private List<GroupComponent> _groupComponents = new List<GroupComponent>();

	private List<GroupComponentProxy> _groupComponentProxies = new List<GroupComponentProxy>();

	private List<GroupComponentProxy> _groupComponentProxiesToDestroy = new List<GroupComponentProxy>();

	private Dictionary<string, AudioComponent> _audioComponents = new Dictionary<string, AudioComponent>();

	private Dictionary<string, Fabric.Component> _globalComponentTable = new Dictionary<string, Fabric.Component>();

	[NonSerialized]
	public CustomAudioClipLoader _customAudioClipLoader;

	[NonSerialized]
	public ICustomRTPParameter _customRTPParameter;

	[HideInInspector]
	[SerializeField]
	public bool _dontDestroyOnLoad = true;

	[SerializeField]
	[HideInInspector]
	public int _audioSourcePool;

	[HideInInspector]
	[SerializeField]
	public float _audioSourcePoolFadeInTime;

	[HideInInspector]
	[SerializeField]
	public float _audioSourcePoolFadeOutTime;

	private Context _updateContext = new Context();

	[SerializeField]
	[HideInInspector]
	public bool _showAllInstances;

	[SerializeField]
	[HideInInspector]
	public bool _enableVirtualization;

	[NonSerialized]
	[HideInInspector]
	public int _totalNumberOfGameObjectsUsed;

	[NonSerialized]
	[HideInInspector]
	public uint _totalMemoryUsed;

	private static List<GameObject> _previewObjects = new List<GameObject>();

	[NonSerialized]
	[HideInInspector]
	public CodeProfiler profiler = new CodeProfiler();

	[SerializeField]
	[HideInInspector]
	public bool enableTimelineAssetLoader;

	[HideInInspector]
	[SerializeField]
	public bool _createEventListeners;

	[SerializeField]
	[HideInInspector]
	public bool _useFullPathForEventListeners;

	[SerializeField]
	[HideInInspector]
	public double _transitionThreshold = 0.5;

	[HideInInspector]
	[SerializeField]
	public double _volumeThreshold;

	[SerializeField]
	[HideInInspector]
	public AudioBusManager _audioBusManager = new AudioBusManager();

	[HideInInspector]
	[SerializeField]
	public CustomCurvesManager _customCurvesManager = new CustomCurvesManager();

	[SerializeField]
	[HideInInspector]
	public bool _enableDebugLog;

	[HideInInspector]
	[SerializeField]
	public bool _bakeComponentInstances;

	[HideInInspector]
	[SerializeField]
	public bool _allowExternalGroupComponents = true;

	[HideInInspector]
	[SerializeField]
	public Vector3 _forceAxisVector = default(Vector3);

	[HideInInspector]
	[SerializeField]
	private List<LanguageProperties> _languages = new List<LanguageProperties>();

	[HideInInspector]
	[SerializeField]
	private int _activeLanguage = -1;

	[HideInInspector]
	[SerializeField]
	public int _defaultLanguage = -1;

	[SerializeField]
	[HideInInspector]
	private SampleManager _sampleManager = new SampleManager();

	[SerializeField]
	[HideInInspector]
	public List<MusicTimeSittings> _musicTimeSignatures = new List<MusicTimeSittings>();

	[NonSerialized]
	[HideInInspector]
	internal List<MusicTimeSittings> _componentMusicTimeSettings = new List<MusicTimeSittings>();

	[HideInInspector]
	[SerializeField]
	public string _fabricEditorPath = "Assets/Fabric/Editor";

	[SerializeField]
	[HideInInspector]
	public VRAudioManager _VRAudioManager = new VRAudioManager();

	[HideInInspector]
	[SerializeField]
	public AudioSourcePool _audioSourcePoolManager;

	[NonSerialized]
	[HideInInspector]
	public static bool _componentPreviewerUpdateIsActive = false;

	[HideInInspector]
	[SerializeField]
	public OnApplicationPauseBehavior _onApplicationPauseBehavior;

	private bool _isInitialised;

	protected static SpringBoardHandler SpringBoardEventInvoker;

	[HideInInspector]
	public AudioListener _audioListener
	{
		get;
		set;
	}

	public AudioSourcePool AudioSourcePoolManager
	{
		get
		{
			return _audioSourcePoolManager;
		}
		set
		{
			_audioSourcePoolManager = value;
		}
	}

	public static bool IsSpringBoardEventInvokerSet => SpringBoardEventInvoker != null;

	public static FabricManager Instance
	{
		get
		{
			if (_instance == null)
			{
				GameObject[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
				for (int i = 0; i < array.Length; i++)
				{
					_instance = array[i].GetComponent<FabricManager>();
					if (_instance != null)
					{
						return _instance;
					}
				}
			}
			return _instance;
		}
		set
		{
			_instance = value;
		}
	}

	public static event SpringBoardHandler _onSpringBoard
	{
		add
		{
			SpringBoardEventInvoker = (SpringBoardHandler)Delegate.Combine(SpringBoardEventInvoker, value);
		}
		remove
		{
			if (SpringBoardEventInvoker != null)
			{
				SpringBoardEventInvoker = (SpringBoardHandler)Delegate.Remove(SpringBoardEventInvoker, value);
			}
		}
	}

	internal void RegisterComponentMusicTimeSettings(Fabric.Component component, MusicTimeSittings musicTimeSettings)
	{
		_componentMusicTimeSettings.Add(musicTimeSettings);
	}

	internal void UnregisterComponentMusicTimeSettings(Fabric.Component component, MusicTimeSittings musicTimeSettings)
	{
		_componentMusicTimeSettings.Remove(musicTimeSettings);
	}

	public static bool IsInitialised()
	{
		if (!(_instance != null))
		{
			return false;
		}
		return true;
	}

	public void OnDisable()
	{
		CleanUpPreviewGameObjects();
	}

	public void OnDestroy()
	{
		_instance = null;
	}

	private void OnApplicationPause(bool pause)
	{
		if (Application.isEditor && _onApplicationPauseBehavior != OnApplicationPauseBehavior.IgnoreAll && (_onApplicationPauseBehavior != OnApplicationPauseBehavior.IgnorePauseFalse || pause) && (_onApplicationPauseBehavior != OnApplicationPauseBehavior.IgnorePauseTrue || !pause))
		{
			UpdateFabricPauseState(GetComponents(), pause);
		}
	}

	private void UpdateFabricPauseState(Fabric.Component[] components, bool pause)
	{
		if (components == null)
		{
			return;
		}
		int i = 0;
		for (int num = components.Length; i < num; i++)
		{
			Fabric.Component component = components[i];
			if (component != null)
			{
				UpdateFabricPauseState(component.GetChildComponents(), pause);
				AudioComponent audioComponent = component as AudioComponent;
				if (audioComponent != null)
				{
					audioComponent.Pause(pause);
				}
			}
		}
	}

	public void Awake()
	{
		if (_isInitialised)
		{
			return;
		}
		_instance = this;
		if (_VRAudioManager.HasVRSolutions())
		{
			FabricAudioListener fabricAudioListener = (FabricAudioListener)UnityEngine.Object.FindObjectOfType(typeof(FabricAudioListener));
			if (fabricAudioListener != null)
			{
				GameObject audioListener = _VRAudioManager.GetAudioListener();
				if (audioListener != null)
				{
					audioListener.transform.parent = fabricAudioListener.gameObject.transform;
				}
			}
			if (_audioSourcePool == 0)
			{
				_audioSourcePool = 100;
			}
		}
		if (_audioSourcePool > 0)
		{
			if (_audioSourcePoolManager == null)
			{
				_audioSourcePoolManager = base.gameObject.GetComponentInChildren<AudioSourcePool>();
				if (_audioSourcePoolManager == null)
				{
					_audioSourcePoolManager = AudioSourcePool.Create();
				}
				_audioSourcePoolManager.Initialise(_audioSourcePool, _audioSourcePoolFadeInTime, _audioSourcePoolFadeOutTime);
			}
			if (_audioSourcePoolManager != null)
			{
				_audioSourcePoolManager.Refresh();
			}
		}
		InitialiseComponents();
		RefreshComponents();
		if (_dontDestroyOnLoad)
		{
			if (Application.isPlaying)
			{
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
			DebugLog.Print("FabricManager initialised (DontDestroyOnLoad flag enabled)");
		}
		else
		{
			DebugLog.Print("FabricManager initialised (DontDestroyOnLoad flag disabled)");
		}
		if (Application.isEditor)
		{
			CodeProfiler.enabled = true;
			FabricManager[] array = UnityEngine.Object.FindObjectsOfType(typeof(FabricManager)) as FabricManager[];
			if (array.Length > 1)
			{
				DebugLog.Print("More than two FabricManager instances available!!!", DebugLevel.Error);
			}
		}
		for (int i = 0; i < _musicTimeSignatures.Count; i++)
		{
			_musicTimeSignatures[i].Init();
		}
		_isInitialised = true;
	}

	private void Start()
	{
		_audioListener = (AudioListener)UnityEngine.Object.FindObjectOfType(typeof(AudioListener));
		VolumeMeter component = base.gameObject.GetComponent<VolumeMeter>();
		if (component != null)
		{
			component.CollectAudioComponents();
		}
	}

	public void OnEnable()
	{
		if (Application.isEditor && !Application.isPlaying)
		{
			_isInitialised = false;
			Awake();
			Start();
		}
	}

	public static void UpdateHierarchy(Fabric.Component component = null)
	{
		GameObject gameObject = null;
		List<Fabric.Component> list = null;
		if (component == null && Instance != null)
		{
			gameObject = Instance.gameObject;
			list = Instance._components;
		}
		else if (component != null)
		{
			gameObject = component.gameObject;
			list = component.Components;
		}
		if (gameObject == null || list == null)
		{
			return;
		}
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			Fabric.Component component2 = gameObject.transform.GetChild(i).GetComponent<Fabric.Component>();
			if (!(component2 != null) || component2.IsInstance)
			{
				continue;
			}
			GroupComponent groupComponent = component2 as GroupComponent;
			if (groupComponent != null && groupComponent._isRegisteredWithMainHierarchy)
			{
				groupComponent.UnregisterWithMainHierarchy();
			}
			bool flag = false;
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j] == component2)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(component2);
				if (component != null)
				{
					component.UpdateComponentsArray();
				}
				if (component2.ParentComponent != null)
				{
					component2.ParentComponent.Initialise(component, isComponentInstance: false);
				}
				else
				{
					component2.Initialise(component, isComponentInstance: false);
				}
				Instance.RefreshComponents();
			}
			else
			{
				UpdateHierarchy(component2);
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			bool flag2 = false;
			for (int l = 0; l < gameObject.transform.childCount; l++)
			{
				Fabric.Component component3 = gameObject.transform.GetChild(l).GetComponent<Fabric.Component>();
				GroupComponentProxy component4 = gameObject.transform.GetChild(l).GetComponent<GroupComponentProxy>();
				if (component3 == list[k] || (component4 != null && component4._groupComponent == list[k]))
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				Fabric.Component component5 = list[k];
				GroupComponent groupComponent2 = component5 as GroupComponent;
				list.Remove(component5);
				if (component != null)
				{
					component.UpdateComponentsArray();
				}
				if (component5.ParentComponent != null)
				{
					component5.ParentComponent.Initialise(component, isComponentInstance: false);
				}
				if (groupComponent2 != null)
				{
					groupComponent2.RegisterWithMainHierarchy();
				}
				Instance.RefreshComponents();
			}
		}
	}

	public void Update()
	{
		profiler.Begin();
		FabricTimer.Update();
		EventManager.Instance.UpdateInternal();
		for (int i = 0; i < _components.Count; i++)
		{
			_updateContext.Reset();
			Fabric.Component component = _components[i];
			if (component.IsComponentActive())
			{
				component.UpdateInternal(ref _updateContext);
			}
		}
		UpdateMusicTimeSettings();
		UpdateGroupComponentProxies(ref _updateContext);
		if (AudioSourcePoolManager != null)
		{
			AudioSourcePoolManager.Update();
		}
		profiler.End();
	}

	public void UpdateMusicTimeSettings()
	{
		for (int i = 0; i < _musicTimeSignatures.Count; i++)
		{
			_musicTimeSignatures[i].Update();
		}
		for (int j = 0; j < _componentMusicTimeSettings.Count; j++)
		{
			_componentMusicTimeSettings[j].Update();
		}
	}

	public MusicTimeSittings GetMusicSettingByName(string name)
	{
		for (int i = 0; i < _musicTimeSignatures.Count; i++)
		{
			if (_musicTimeSignatures[i]._name == name)
			{
				return _musicTimeSignatures[i];
			}
		}
		return null;
	}

	public MusicTimeSittings GetMusicSettingByIndex(int index)
	{
		index--;
		if (index < 0 || index >= _musicTimeSignatures.Count)
		{
			return null;
		}
		return _musicTimeSignatures[index];
	}

	public void RegisterMusicSyncNotifications(string name, MusicTimeSittings.OnBarHandler onBarCallback, MusicTimeSittings.OnBeatHandler onBeatCallback)
	{
		MusicTimeSittings musicSettingByName = GetMusicSettingByName(name);
		if (musicSettingByName != null)
		{
			musicSettingByName._onBeatDetected += onBeatCallback;
			musicSettingByName._onBarDetected += onBarCallback;
		}
	}

	public void Stop(float fadeOut = 0f)
	{
		DebugLog.Print("Stop all components");
		for (int i = 0; i < _components.Count; i++)
		{
			Fabric.Component component = _components[i];
			component.Stop(stopInstances: true, forceStop: true, ignoreFade: true, 0f);
		}
	}

	public void Pause(bool pause)
	{
		DebugLog.Print("Pause all components");
		for (int i = 0; i < _components.Count; i++)
		{
			Fabric.Component component = _components[i];
			component.Pause(pause);
		}
	}

	public void FadeInComponent(string destinationComponent, float targetMS, float curve)
	{
		if (_globalComponentTable.ContainsKey(destinationComponent))
		{
			Fabric.Component component = _globalComponentTable[destinationComponent];
			component.FadeIn(targetMS, curve);
		}
	}

	public void FadeOutComponent(string destinationComponent, float targetMS, float curve)
	{
		if (_globalComponentTable.ContainsKey(destinationComponent))
		{
			Fabric.Component component = _globalComponentTable[destinationComponent];
			component.FadeOut(targetMS, curve);
		}
	}

	public void LoadAsset(string prefabName, string destinationComponent)
	{
		if (_globalComponentTable.ContainsKey(destinationComponent))
		{
			Fabric.Component component = _globalComponentTable[destinationComponent];
			UnityEngine.Object @object = Resources.Load(prefabName);
			if (@object != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
				gameObject.name = gameObject.name.Replace("(Clone)", "");
				string key = destinationComponent + "_" + gameObject.name;
				if (_globalComponentTable.ContainsKey(key))
				{
					UnityEngine.Object.Destroy(gameObject);
					return;
				}
				gameObject.transform.parent = component.transform;
				Fabric.Component component2 = gameObject.GetComponent<Fabric.Component>();
				if (component2 != null)
				{
					component2.Initialise(component, isComponentInstance: false);
					component.AddComponent(component2);
					AddChildComponentsToGlobalTable(component2, destinationComponent);
				}
				VolumeMeter component3 = component.GetComponent<VolumeMeter>();
				if (component3 != null)
				{
					component3.CollectAudioComponents();
				}
				DebugLog.Print("Asset [" + prefabName + "] loaded succesfuly");
			}
			else
			{
				DebugLog.Print("Asset [" + prefabName + "] name not found", DebugLevel.Error);
			}
		}
		else
		{
			DebugLog.Print("Target Component [" + destinationComponent + "] not found", DebugLevel.Error);
		}
	}

	public void LoadAsset(GameObject component, string destinationComponent)
	{
		if (_globalComponentTable.ContainsKey(destinationComponent))
		{
			Fabric.Component component2 = _globalComponentTable[destinationComponent];
			if (component != null)
			{
				component.name = component.name.Replace("(Clone)", "");
				string key = destinationComponent + "_" + component.name;
				if (_globalComponentTable.ContainsKey(key))
				{
					UnityEngine.Object.DestroyImmediate(component);
					return;
				}
				component.transform.parent = component2.transform;
				Fabric.Component component3 = component.GetComponent<Fabric.Component>();
				if (component3 != null)
				{
					component3.Initialise(component2, isComponentInstance: false);
					component2.AddComponent(component3);
					AddChildComponentsToGlobalTable(component3, destinationComponent);
					VolumeMeter component4 = component2.GetComponent<VolumeMeter>();
					if (component4 != null)
					{
						component4.CollectAudioComponents();
					}
				}
				DebugLog.Print("Asset [" + component.name + "] loaded succesfuly");
			}
			else
			{
				DebugLog.Print("Asset [" + component.name + "] name not found", DebugLevel.Error);
			}
		}
		else
		{
			DebugLog.Print("Target Component [" + destinationComponent + "] not found", DebugLevel.Error);
		}
	}

	public bool RegisterGroupComponent(GroupComponent groupComponent, string targetGroupComponentPath, bool createProxy = true)
	{
		if (!_allowExternalGroupComponents)
		{
			DebugLog.Print("External GroupComponent registration is disabled");
			return false;
		}
		bool result = false;
		Fabric.Component componentByName = GetComponentByName(targetGroupComponentPath);
		if (groupComponent != null)
		{
			groupComponent.Initialise(componentByName, isComponentInstance: false);
			if (componentByName != null)
			{
				componentByName.AddComponent(groupComponent);
			}
			else
			{
				_components.Add(groupComponent);
			}
			if (createProxy)
			{
				GameObject gameObject = new GameObject();
				gameObject.hideFlags = HideFlags.DontSave;
				GroupComponentProxy groupComponentProxy = gameObject.AddComponent<GroupComponentProxy>();
				groupComponentProxy._groupComponent = groupComponent;
				groupComponentProxy.name = groupComponent.name + "_Proxy";
				if (componentByName != null)
				{
					groupComponentProxy.transform.parent = componentByName.transform;
				}
				else
				{
					groupComponentProxy.transform.parent = base.gameObject.transform;
				}
				_groupComponentProxies.Add(groupComponentProxy);
			}
			else if (componentByName != null)
			{
				groupComponent.transform.parent = componentByName.transform;
			}
			else
			{
				groupComponent.transform.parent = base.gameObject.transform;
			}
			if (componentByName != null)
			{
				VolumeMeter component = componentByName.GetComponent<VolumeMeter>();
				if (component != null)
				{
					component.CollectAudioComponents();
				}
			}
			DebugLog.Print("GroupComponent [" + groupComponent.name + "] registred succesfuly");
			result = true;
		}
		else
		{
			DebugLog.Print("GroupComponent [" + groupComponent.name + "] failed to register", DebugLevel.Error);
		}
		return result;
	}

	public bool UnregisterGroupComponent(GroupComponent groupComponent, bool ignoreFadeOut = true)
	{
		if (!_allowExternalGroupComponents)
		{
			DebugLog.Print("External GroupComponent registration is disabled");
			return false;
		}
		bool result = true;
		if (groupComponent != null)
		{
			if (!ignoreFadeOut)
			{
				for (int i = 0; i < _groupComponentProxies.Count; i++)
				{
					GroupComponentProxy groupComponentProxy = _groupComponentProxies[i];
					if (groupComponentProxy._groupComponent == groupComponent)
					{
						groupComponent.Stop();
						GameObject gameObject = new GameObject();
						groupComponentProxy._groupComponent = gameObject.AddComponent<GroupComponent>();
						groupComponentProxy._groupComponent.transform.parent = groupComponentProxy.transform;
						groupComponentProxy._groupComponent.name = groupComponent.name;
						groupComponentProxy._groupComponent.CopyPropertiesFrom(groupComponent);
						if (groupComponent.ParentComponent != null)
						{
							groupComponent.ParentComponent.RemoveComponent(groupComponent);
							groupComponent.ParentComponent.AddComponent(groupComponentProxy._groupComponent);
						}
						else
						{
							_components.Remove(groupComponent);
							_components.Remove(groupComponentProxy._groupComponent);
						}
						Fabric.Component[] childComponents = groupComponent.GetChildComponents();
						for (int j = 0; j < childComponents.Length; j++)
						{
							groupComponentProxy._groupComponent.AddComponent(childComponents[j]);
							childComponents[j].transform.parent = groupComponentProxy._groupComponent.transform;
							childComponents[j].ParentComponent = groupComponentProxy._groupComponent;
						}
						_groupComponentProxies.Remove(groupComponentProxy);
						_groupComponentProxiesToDestroy.Add(groupComponentProxy);
						groupComponentProxy._groupComponent.SetComponentActive(groupComponent.IsComponentActive());
						DebugLog.Print("GroupComponent [" + groupComponent.name + "] scheduled to be unregistered");
					}
				}
			}
			else
			{
				if (groupComponent.ParentComponent != null)
				{
					groupComponent.ParentComponent.RemoveComponent(groupComponent);
				}
				else
				{
					_components.Remove(groupComponent);
				}
				for (int k = 0; k < _groupComponentProxies.Count; k++)
				{
					GroupComponentProxy groupComponentProxy2 = _groupComponentProxies[k];
					if (groupComponentProxy2 != null && groupComponentProxy2._groupComponent == groupComponent)
					{
						_groupComponentProxies.Remove(groupComponentProxy2);
						UnityEngine.Object.DestroyImmediate(groupComponentProxy2.gameObject);
						break;
					}
				}
				DebugLog.Print("GroupComponent [" + groupComponent.name + "] unregistered succesfuly");
			}
			result = false;
		}
		else
		{
			DebugLog.Print("GroupComponent [" + groupComponent.name + "] failed to unregistred", DebugLevel.Error);
		}
		return result;
	}

	private void UpdateGroupComponentProxies(ref Context updateContext)
	{
		for (int i = 0; i < _groupComponentProxiesToDestroy.Count; i++)
		{
			GroupComponentProxy groupComponentProxy = _groupComponentProxiesToDestroy[i];
			if (!groupComponentProxy._groupComponent.IsComponentActive())
			{
				if (groupComponentProxy._groupComponent.ParentComponent != null)
				{
					groupComponentProxy._groupComponent.ParentComponent.RemoveComponent(groupComponentProxy._groupComponent);
				}
				else
				{
					_components.Remove(groupComponentProxy._groupComponent);
				}
				_groupComponentProxiesToDestroy.Remove(groupComponentProxy);
				UnityEngine.Object.DestroyObject(groupComponentProxy.gameObject);
			}
		}
	}

	public void UnloadAsset(string componentName, bool ignoreUnloadUnusedAssets = false)
	{
		if (_globalComponentTable.ContainsKey(componentName))
		{
			Fabric.Component component = _globalComponentTable[componentName];
			if (component != null)
			{
				_components.Remove(component);
				if (component.ParentComponent != null)
				{
					component.ParentComponent.RemoveComponent(component);
				}
				RemoveChildComponentsFromGlobalTable(component, componentName);
				component.Destroy();
				UnityEngine.Object.Destroy(component.gameObject);
				if (!ignoreUnloadUnusedAssets)
				{
					Resources.UnloadUnusedAssets();
				}
				DebugLog.Print("Assets [" + componentName + "] unloaded succesfuly");
			}
			else
			{
				DebugLog.Print("Assets [" + componentName + "] failed to unload", DebugLevel.Error);
			}
		}
		else
		{
			DebugLog.Print("Target Component [" + componentName + "] not found", DebugLevel.Error);
		}
	}

	public void RegisterCustomTimer(ICustomTimer customTimer)
	{
		FabricTimer.customTimer = customTimer;
	}

	private void AddChildComponentsToGlobalTable(Fabric.Component component, string path)
	{
		if (!(component == null))
		{
			string text = path + "_" + component.name;
			if (!_globalComponentTable.ContainsKey(text))
			{
				_globalComponentTable.Add(text, component);
			}
			AudioComponent audioComponent = component as AudioComponent;
			if (audioComponent != null && !_audioComponents.ContainsKey(text))
			{
				_audioComponents.Add(text, audioComponent);
			}
			Fabric.Component[] childComponents = component.GetChildComponents();
			for (int i = 0; i < childComponents.Length; i++)
			{
				AddChildComponentsToGlobalTable(childComponents[i], text);
			}
		}
	}

	private void RemoveChildComponentsFromGlobalTable(Fabric.Component component, string path)
	{
		if (!(component == null))
		{
			if (_globalComponentTable.ContainsKey(path))
			{
				_globalComponentTable.Remove(path);
			}
			AudioComponent x = component as AudioComponent;
			if (x != null && _audioComponents.ContainsKey(path))
			{
				_audioComponents.Remove(path);
			}
			Fabric.Component[] childComponents = component.GetChildComponents();
			for (int i = 0; i < childComponents.Length; i++)
			{
				string path2 = path + "_" + childComponents[i].name;
				RemoveChildComponentsFromGlobalTable(childComponents[i], path2);
			}
		}
	}

	private void InitialiseComponents()
	{
		int childCount = base.transform.childCount;
		_components.Clear();
		for (int i = 0; i < childCount; i++)
		{
			Fabric.Component component = base.transform.GetChild(i).GetComponent<Fabric.Component>();
			if (component != null)
			{
				component.Initialise(null, isComponentInstance: false);
				_components.Add(component);
			}
		}
	}

	internal void RefreshComponents()
	{
		_globalComponentTable.Clear();
		Fabric.Component[] components = GetComponents();
		base.gameObject.name = base.gameObject.name.Replace("(Clone)", "");
		for (int i = 0; i < components.Length; i++)
		{
			AddChildComponentsToGlobalTable(components[i], base.gameObject.name);
		}
	}

	internal void RemoveComponent(Fabric.Component component)
	{
		_components.Remove(component);
	}

	public void BakeComponentInstances()
	{
		int childCount = base.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Fabric.Component component = base.transform.GetChild(i).GetComponent<Fabric.Component>();
			if (component != null)
			{
				component.BakeComponentInstances();
			}
		}
	}

	public void CleanBakedComponentInstances()
	{
		int childCount = base.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Fabric.Component component = base.transform.GetChild(i).GetComponent<Fabric.Component>();
			if (component != null)
			{
				component.CleanBakedComponentInstances();
			}
		}
	}

	public Fabric.Component[] GetComponents()
	{
		List<Fabric.Component> list = new List<Fabric.Component>();
		int childCount = base.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Fabric.Component component = base.transform.GetChild(i).GetComponent<Fabric.Component>();
			if ((bool)component)
			{
				list.Add(component);
			}
		}
		return list.ToArray();
	}

	public Fabric.Component GetComponentByName(string destinationComponent)
	{
		if (destinationComponent != null && _globalComponentTable.ContainsKey(destinationComponent))
		{
			return _globalComponentTable[destinationComponent];
		}
		return null;
	}

	public Fabric.Component[] GetComponentsByName(string destinationComponent, GameObject parentGameObject)
	{
		if (_globalComponentTable.ContainsKey(destinationComponent))
		{
			Fabric.Component component = _globalComponentTable[destinationComponent];
			if (component != null)
			{
				List<ComponentInstance> list = component.FindInstances(parentGameObject, createIfNoneFound: false);
				if (list != null && list.Count > 0)
				{
					Fabric.Component[] array = new Fabric.Component[list.Count];
					for (int i = 0; i < list.Count; i++)
					{
						array[i] = list[i]._instance;
					}
					return array;
				}
			}
		}
		return null;
	}

	public void SetAudioComponentClip(string componentName, AudioClip audioClip, GameObject parentGameObject = null)
	{
		if (!(audioClip == null) && _audioComponents.ContainsKey(componentName))
		{
			AudioComponent audioComponent = _audioComponents[componentName];
			audioComponent.SetAudioClip(audioClip, parentGameObject);
		}
	}

	public void SetAudioComponentClip(string componentName, string resourceName, GameObject parentGameObject = null)
	{
		if (_audioComponents.ContainsKey(componentName))
		{
			AudioComponent audioComponent = _audioComponents[componentName];
			audioComponent.SetAudioClip(Resources.Load(resourceName) as AudioClip, parentGameObject);
		}
	}

	public void SetLanguageByName(string language)
	{
		int num = 0;
		while (true)
		{
			if (num < _languages.Count)
			{
				if (_languages[num]._name == language)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		_activeLanguage = num;
	}

	public void SetLanguageByIndex(int languageIndex)
	{
		_activeLanguage = languageIndex;
	}

	public string GetLanguageName()
	{
		if (_activeLanguage < 0)
		{
			return "Uknown Language";
		}
		return _languages[_activeLanguage]._name;
	}

	public int GetLanguageIndex()
	{
		return _activeLanguage;
	}

	public void AddLanguage(string name)
	{
		LanguageProperties languageProperties = new LanguageProperties();
		languageProperties._name = name;
		_languages.Add(languageProperties);
	}

	public void RemoveLanguage(LanguageProperties language)
	{
		_languages.Remove(language);
	}

	public int GetNumLanguages()
	{
		return _languages.Count;
	}

	public string[] GetLanguageNames()
	{
		string[] array = new string[_languages.Count];
		for (int i = 0; i < _languages.Count; i++)
		{
			array[i] = _languages[i]._name;
		}
		return array;
	}

	public LanguageProperties GetLanguagePropertiesByName(string language)
	{
		for (int i = 0; i < _languages.Count; i++)
		{
			if (_languages[i]._name == language)
			{
				return _languages[i];
			}
		}
		return null;
	}

	public LanguageProperties GetLanguagePropertiesByIndex(int index)
	{
		if (index < 0 || index >= _languages.Count)
		{
			return null;
		}
		return _languages[index];
	}

	internal static void AddPreviewGameObject(GameObject gameObject)
	{
		gameObject.hideFlags = HideFlags.HideAndDontSave;
		_previewObjects.Add(gameObject);
	}

	public static void CleanUpPreviewGameObjects()
	{
		for (int i = 0; i < _previewObjects.Count; i++)
		{
			GameObject gameObject = _previewObjects[i];
			if (gameObject != null)
			{
				UnityEngine.Object.DestroyImmediate(gameObject);
			}
		}
		_previewObjects.Clear();
	}
}
