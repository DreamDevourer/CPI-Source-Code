// DRewardPopupScreenCustom
using Disney.Kelowna.Common;

public class DRewardPopupScreenCustom : DRewardPopupScreen
{
	public PrefabContentKey ScreenKey;

	public DRewardPopupScreenCustom(PrefabContentKey screenKey)
	{
		ScreenKey = screenKey;
		ScreenType = RewardScreenPopupType.custom;
	}
}
