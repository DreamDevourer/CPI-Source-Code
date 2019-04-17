// SwappableNetworkServicesManager
using ClubPenguin.Net;
using Disney.Kelowna.Common;
using System;

internal class SwappableNetworkServicesManager : INetworkServicesManager
{
	public INetworkServicesManager NetworkServicesManager
	{
		get;
		set;
	}

	public IWorldService WorldService => NetworkServicesManager.WorldService;

	public IPlayerStateService PlayerStateService => NetworkServicesManager.PlayerStateService;

	public IChatService ChatService => NetworkServicesManager.ChatService;

	public IPlayerActionService PlayerActionService => NetworkServicesManager.PlayerActionService;

	public IInventoryService InventoryService => NetworkServicesManager.InventoryService;

	public IBreadcrumbService BreadcrumbService => NetworkServicesManager.BreadcrumbService;

	public ITutorialService TutorialService => NetworkServicesManager.TutorialService;

	public ISavedOutfitService SavedOutfitService => NetworkServicesManager.SavedOutfitService;

	public IIglooService IglooService => NetworkServicesManager.IglooService;

	public IPrototypeService PrototypeService => NetworkServicesManager.PrototypeService;

	public IFriendsService FriendsService => NetworkServicesManager.FriendsService;

	public IQuestService QuestService => NetworkServicesManager.QuestService;

	public long GameTimeMilliseconds => NetworkServicesManager.GameTimeMilliseconds;

	public IConsumableService ConsumableService => NetworkServicesManager.ConsumableService;

	public IRewardService RewardService => NetworkServicesManager.RewardService;

	public ITaskService TaskService => NetworkServicesManager.TaskService;

	public IMinigameService MinigameService => NetworkServicesManager.MinigameService;

	public IIAPService IAPService => NetworkServicesManager.IAPService;

	public IModerationService ModerationService => NetworkServicesManager.ModerationService;

	public IDisneyStoreService DisneyStoreService => NetworkServicesManager.DisneyStoreService;

	public INewsfeedService NewsfeedService => NetworkServicesManager.NewsfeedService;

	public ICatalogService CatalogService => NetworkServicesManager.CatalogService;

	public IPartyGameService PartyGameService => NetworkServicesManager.PartyGameService;

	public IScheduledEventService ScheduledEventService => NetworkServicesManager.ScheduledEventService;

	public IDiagnosticsService DiagnosticsService => NetworkServicesManager.DiagnosticsService;

	public ICaptchaService CaptchaService => NetworkServicesManager.CaptchaService;

	public DateTime ServerDateTime => NetworkServicesManager.ServerDateTime;

	public RollingStatistics GameServerLatency => NetworkServicesManager.GameServerLatency;

	public RollingStatistics WebServiceLatency => NetworkServicesManager.WebServiceLatency;

	public int ServerUserCount => NetworkServicesManager.ServerUserCount;

	public bool IsGameServerConnected()
	{
		return false;
	}

	public void Configure(NetworkServicesConfig networkServicesConfig)
	{
		NetworkServicesManager.Configure(networkServicesConfig);
	}

	public void Reset()
	{
	}
}
