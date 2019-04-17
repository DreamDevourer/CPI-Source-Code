// DRewardPopup
using ClubPenguin.Net.Domain;
using ClubPenguin.Rewards;
using Disney.Kelowna.Common;
using System.Collections.Generic;

public class DRewardPopup
{
	public enum RewardPopupType
	{
		questComplete,
		levelUp,
		generic,
		replay
	}

	public RewardPopupType PopupType;

	public Reward RewardData;

	public string MascotName;

	public int XP;

	public string SplashTitleToken;

	public string SourceID;

	public bool ShowXpAndCoinsUI;

	public string RewardPopupPrefabOverride;

	public List<PrefabContentKey> CustomScreenKeys;

	public override string ToString()
	{
		return $"[DRewardPopup] Type: {PopupType} RewardData: {RewardData} Mascot: {MascotName} XP: {XP} SplashTitleToken: {SplashTitleToken} ShowXpAndCoinsUI: {ShowXpAndCoinsUI} RewardPopupPrefabOverride: {RewardPopupPrefabOverride}";
	}
}
