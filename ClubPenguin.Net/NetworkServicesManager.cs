// NetworkServicesManager
using ClubPenguin.Net;
using ClubPenguin.Net.Client;
using Disney.Kelowna.Common;
using Disney.LaunchPadFramework;
using Disney.Manimal.Common.Util;
using System;
using UnityEngine;

public class NetworkServicesManager : INetworkServicesManager
{
	private ClubPenguinClient clubPenguinClient;

	private MonoBehaviour monoBehaviour;

	private NetworkServicesConfig currentConfig;

	private IWorldService worldService;

	private IPlayerStateService playerStateService;

	private IChatService chatService;

	private IPlayerActionService playerActionService;

	private IInventoryService inventoryService;

	private IBreadcrumbService breadcrumbService;

	private ISavedOutfitService savedOutfitService;

	private IIglooService iglooService;

	private IPrototypeService prototypeService;

	private IFriendsService friendsService;

	private IQuestService questService;

	private IConsumableService consumableService;

	private IRewardService rewardService;

	private ITaskService taskService;

	private IMinigameService minigameService;

	private IIAPService iapService;

	private ITutorialService tutorialService;

	private IModerationService moderationService;

	private IDisneyStoreService disneyStoreService;

	private INewsfeedService newsfeedService;

	private ICatalogService catalogService;

	private IPartyGameService partyGameService;

	private IScheduledEventService scheduledEventService;

	private IDiagnosticsService diagnosticsService;

	private ICaptchaService captchaService;

	private bool offlineMode;

	public IWorldService WorldService => worldService;

	public IPlayerStateService PlayerStateService => playerStateService;

	public IChatService ChatService => chatService;

	public IPlayerActionService PlayerActionService => playerActionService;

	public IInventoryService InventoryService => inventoryService;

	public IBreadcrumbService BreadcrumbService => breadcrumbService;

	public ISavedOutfitService SavedOutfitService => savedOutfitService;

	public IIglooService IglooService => iglooService;

	public IPrototypeService PrototypeService => prototypeService;

	public IFriendsService FriendsService => friendsService;

	public IQuestService QuestService => questService;

	public IConsumableService ConsumableService => consumableService;

	public IRewardService RewardService => rewardService;

	public ITaskService TaskService => taskService;

	public IMinigameService MinigameService => minigameService;

	public IIAPService IAPService => iapService;

	public ITutorialService TutorialService => tutorialService;

	public IModerationService ModerationService => moderationService;

	public IDisneyStoreService DisneyStoreService => disneyStoreService;

	public INewsfeedService NewsfeedService => newsfeedService;

	public ICatalogService CatalogService => catalogService;

	public IPartyGameService PartyGameService => partyGameService;

	public IScheduledEventService ScheduledEventService => scheduledEventService;

	public IDiagnosticsService DiagnosticsService => diagnosticsService;

	public ICaptchaService CaptchaService => captchaService;

	public long GameTimeMilliseconds => clubPenguinClient.GameServer.ServerTime;

	public int ServerUserCount => clubPenguinClient.GameServer.UserCount;

	public DateTime ServerDateTime => GameTimeMilliseconds.MsToDateTime();

	public RollingStatistics GameServerLatency => clubPenguinClient.GameServerLatency;

	public RollingStatistics WebServiceLatency => clubPenguinClient.WebServiceLatency;

	public bool IsGameServerConnected()
	{
		if (clubPenguinClient != null && clubPenguinClient.GameServer != null)
		{
			return clubPenguinClient.GameServer.IsConnected();
		}
		return false;
	}

	public NetworkServicesManager(MonoBehaviour monoBehaviour, NetworkServicesConfig config, bool offlineMode)
	{
		this.monoBehaviour = monoBehaviour;
		this.offlineMode = offlineMode;
		Configure(config);
	}

	public void Configure(NetworkServicesConfig config)
	{
		if (clubPenguinClient != null)
		{
			clubPenguinClient.Destroy();
		}
		clubPenguinClient = new ClubPenguinClient(monoBehaviour, config.CPAPIServicehost, config.CPAPIClientToken, config.ClientApiVersion, config.CPGameServerZone, !offlineMode && config.CPGameServerEncrypted, config.CPGameServerDebug, config.CPLagMonitoring, config.CPGameServerLatencyWindowSize, config.CPWebServiceLatencyWindowSize, config.CPMonitoringServicehost, config.CPWebsiteAPIServicehost, offlineMode);
		currentConfig = config;
		worldService = new WorldService();
		worldService.Initialize(clubPenguinClient);
		playerStateService = new PlayerStateService();
		playerStateService.Initialize(clubPenguinClient);
		chatService = new ChatService();
		chatService.Initialize(clubPenguinClient);
		playerActionService = new PlayerActionService();
		playerActionService.Initialize(clubPenguinClient);
		iglooService = new IglooService();
		iglooService.Initialize(clubPenguinClient);
		inventoryService = new InventoryService();
		inventoryService.Initialize(clubPenguinClient);
		breadcrumbService = new BreadcrumbService();
		breadcrumbService.Initialize(clubPenguinClient);
		savedOutfitService = new SavedOutfitService();
		savedOutfitService.Initialize(clubPenguinClient);
		prototypeService = new PrototypeService();
		prototypeService.Initialize(clubPenguinClient);
		questService = new QuestService();
		questService.Initialize(clubPenguinClient);
		consumableService = new ConsumableService();
		consumableService.Initialize(clubPenguinClient);
		friendsService = new FriendsService();
		friendsService.Initialize(clubPenguinClient);
		rewardService = new RewardService();
		rewardService.Initialize(clubPenguinClient);
		taskService = new TaskNetworkService();
		taskService.Initialize(clubPenguinClient);
		minigameService = new MinigameService();
		minigameService.Initialize(clubPenguinClient);
		iapService = new IAPService();
		iapService.Initialize(clubPenguinClient);
		tutorialService = new TutorialService();
		tutorialService.Initialize(clubPenguinClient);
		moderationService = new ModerationService();
		moderationService.Initialize(clubPenguinClient);
		disneyStoreService = new DisneyStoreService();
		disneyStoreService.Initialize(clubPenguinClient);
		newsfeedService = new NewsfeedService();
		newsfeedService.Initialize(clubPenguinClient);
		catalogService = new CatalogService();
		catalogService.Initialize(clubPenguinClient);
		partyGameService = new PartyGameService();
		partyGameService.Initialize(clubPenguinClient);
		scheduledEventService = new ScheduledEventService();
		scheduledEventService.Initialize(clubPenguinClient);
		diagnosticsService = new DiagnosticsService();
		diagnosticsService.Initialize(clubPenguinClient);
		captchaService = new CaptchaService();
		captchaService.Initialize(clubPenguinClient);
	}

	public void Reset()
	{
		questService.ClearQueue();
		try
		{
			Configure(currentConfig);
		}
		catch
		{
			Log.LogError(this, "Cannot reset network services, configuration missing");
		}
	}
}
