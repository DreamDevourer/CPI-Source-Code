// DRewardPopupScreenQuests
using ClubPenguin.Adventure;

public class DRewardPopupScreenQuests : DRewardPopupScreen
{
	public QuestDefinition[] quests;

	public DRewardPopupScreenQuests()
	{
		ScreenType = RewardScreenPopupType.quests;
	}
}
