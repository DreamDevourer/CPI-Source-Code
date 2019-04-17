// MusicTrackReward
using ClubPenguin.Net.Domain;
using System;
using System.Collections.Generic;

[Serializable]
public class MusicTrackReward : AbstractListReward<int>
{
	public List<int> MusicTracks => data;

	public override string RewardType => "musicTracks";

	public MusicTrackReward()
	{
	}

	public MusicTrackReward(int value)
		: base(value)
	{
	}
}
