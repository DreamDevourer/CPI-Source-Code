// ClearFishingGameQuestPrizeAction
using ClubPenguin.Adventure;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Quest")]
public class ClearFishingGameQuestPrizeAction : FsmStateAction
{
	public override void OnEnter()
	{
		Service.Get<QuestService>().CurrentFishingPrize = "";
		Finish();
	}
}
