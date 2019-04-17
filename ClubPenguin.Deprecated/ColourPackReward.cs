// ColourPackReward
using ClubPenguin.Net.Domain;
using System;

[Serializable]
public class ColourPackReward : AbstractListReward<string>
{
	public override string RewardType => "colourPacks";

	public ColourPackReward()
	{
	}

	public ColourPackReward(string value)
		: base(value)
	{
	}
}
