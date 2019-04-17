// TubeInventoryScreenController
using ClubPenguin.Core;
using ClubPenguin.Tubes;
using ClubPenguin.UI;
using UnityEngine;

public class TubeInventoryScreenController : AbstractProgressionLockedItems<TubeDefinition>
{
	protected override void createItem(TubeDefinition itemDefinition, GameObject item, ItemGroup.LockedState lockedState)
	{
		item.GetComponent<TubeInventoryButton>().SetTubeDefinition(itemDefinition);
	}

	protected override TubeDefinition[] getRewards(RewardDefinition rewardDefinition)
	{
		return AbstractStaticGameDataRewardDefinition<TubeDefinition>.ToDefinitionArray(rewardDefinition.GetDefinitions<TubeRewardDefinition>());
	}
}
