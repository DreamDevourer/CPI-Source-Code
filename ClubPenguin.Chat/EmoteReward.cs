// EmoteReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class EmoteReward : AbstractListReward<string>
{
	public List<string> Emotes => data;

	public override string RewardType => "emotePacks";

	public EmoteReward()
	{
	}

	public EmoteReward(string value)
		: base(value)
	{
	}
}
