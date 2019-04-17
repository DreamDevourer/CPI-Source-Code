// CollectibleRewardDefinition
using ClubPenguin.Collectibles;
using ClubPenguin.Core;
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class CollectibleRewardDefinition : AbstractStaticGameDataRewardDefinition<CollectibleDefinition>
{
	public CollectibleDefinition Collectible;

	public int Amount;

	public override IRewardable Reward => new CollectibleReward(Collectible.CollectibleType, Amount);

	protected override CollectibleDefinition getField()
	{
		return Collectible;
	}
}
