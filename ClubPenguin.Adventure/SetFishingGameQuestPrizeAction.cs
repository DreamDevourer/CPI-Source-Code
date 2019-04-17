// SetFishingGameQuestPrizeAction
using ClubPenguin.Adventure;
using ClubPenguin.MiniGames.Fishing;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class SetFishingGameQuestPrizeAction : FsmStateAction
{
	public LootTableRewardDefinition rewardDefinition;

	public override void OnEnter()
	{
		Service.Get<QuestService>().CurrentFishingPrize = rewardDefinition.Id;
		Finish();
	}
}
