// ScavengerHuntData
using ClubPenguin;
using ClubPenguin.Core;
using ClubPenguin.Game.PartyGames;
using DevonLocalization.Core;
using Disney.Kelowna.Common.DataModel;
using Disney.MobileNetwork;
using UnityEngine;

public class ScavengerHuntData
{
	private Animator localPlayerAnimator;

	private Animator otherPlayerAnimator;

	public ScavengerHunt.ScavengerHuntRoles LocalPlayerRole
	{
		get;
		set;
	}

	public ScavengerHunt.ScavengerHuntRoles OtherPlayerRole
	{
		get;
		set;
	}

	public int GameSessionId
	{
		get;
		private set;
	}

	public long LocalPlayerSessionId
	{
		get;
		private set;
	}

	public long OtherPlayerSessionId
	{
		get;
		private set;
	}

	public int TotalMarbleCount
	{
		get;
		private set;
	}

	public RewardDefinition WinRewardDefinition
	{
		get;
		private set;
	}

	public RewardDefinition LoseRewardDefinition
	{
		get;
		private set;
	}

	public string LocalPlayerName
	{
		get;
		private set;
	}

	public string OtherPlayerName
	{
		get;
		private set;
	}

	public string RoomName
	{
		get;
		private set;
	}

	public Animator LocalPlayerAnimator
	{
		get
		{
			if (localPlayerAnimator == null)
			{
				GameObject localPlayerGameObject = ClubPenguin.SceneRefs.ZoneLocalPlayerManager.LocalPlayerGameObject;
				localPlayerAnimator = localPlayerGameObject.GetComponent<Animator>();
			}
			return localPlayerAnimator;
		}
	}

	public Animator OtherPlayerAnimator
	{
		get
		{
			if (otherPlayerAnimator == null)
			{
				CPDataEntityCollection cPDataEntityCollection = Service.Get<CPDataEntityCollection>();
				DataEntityHandle handle = cPDataEntityCollection.FindEntity<SessionIdData, long>(OtherPlayerSessionId);
				if (cPDataEntityCollection.TryGetComponent(handle, out GameObjectReferenceData component))
				{
					otherPlayerAnimator = component.GameObject.GetComponent<Animator>();
				}
			}
			return otherPlayerAnimator;
		}
	}

	public ScavengerHuntData(int sessionId, long localPlayerSessionId, long otherPlayerSessionId, int totalMarbleCount, RewardDefinition winRewardDefinition, RewardDefinition loseRewardDefinition)
	{
		GameSessionId = sessionId;
		LocalPlayerSessionId = localPlayerSessionId;
		OtherPlayerSessionId = otherPlayerSessionId;
		TotalMarbleCount = totalMarbleCount;
		WinRewardDefinition = winRewardDefinition;
		LoseRewardDefinition = loseRewardDefinition;
		CPDataEntityCollection cPDataEntityCollection = Service.Get<CPDataEntityCollection>();
		DataEntityHandle handle = cPDataEntityCollection.FindEntity<SessionIdData, long>(otherPlayerSessionId);
		DataEntityHandle handle2 = cPDataEntityCollection.FindEntity<SessionIdData, long>(localPlayerSessionId);
		if (cPDataEntityCollection.TryGetComponent(handle2, out DisplayNameData component))
		{
			LocalPlayerName = component.DisplayName;
		}
		if (cPDataEntityCollection.TryGetComponent(handle, out DisplayNameData component2))
		{
			OtherPlayerName = component2.DisplayName;
		}
		if (cPDataEntityCollection.TryGetComponent(handle2, out PresenceData component3))
		{
			string zoneToken = Service.Get<ZoneTransitionService>().GetZone(component3.Room).ZoneToken;
			RoomName = Service.Get<Localizer>().GetTokenTranslation(zoneToken);
		}
		GameObject localPlayerGameObject = ClubPenguin.SceneRefs.ZoneLocalPlayerManager.LocalPlayerGameObject;
		localPlayerAnimator = localPlayerGameObject.GetComponent<Animator>();
		if (cPDataEntityCollection.TryGetComponent(handle, out GameObjectReferenceData component4))
		{
			otherPlayerAnimator = component4.GameObject.GetComponent<Animator>();
		}
	}

	public override string ToString()
	{
		return $"[ScavengerHuntData: GameSessionId={GameSessionId}, LocalPlayerSessionId={LocalPlayerSessionId}, OtherPlayerSessionId={OtherPlayerSessionId}, LocalPlayerName={LocalPlayerName}, OtherPlayerName={OtherPlayerName}, RoomName={RoomName}, LocalPlayerRole={LocalPlayerRole}, WinRewardDefinition={WinRewardDefinition}, LoseRewardDefinition={LoseRewardDefinition}, LocalPlayerAnimator={LocalPlayerAnimator}, OtherPlayerAnimator={OtherPlayerAnimator}]";
	}
}
