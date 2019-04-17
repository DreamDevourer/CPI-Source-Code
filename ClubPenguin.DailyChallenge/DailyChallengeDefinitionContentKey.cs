// DailyChallengeDefinitionContentKey
using ClubPenguin.DailyChallenge;
using Disney.Kelowna.Common;
using System;

[Serializable]
public class DailyChallengeDefinitionContentKey : TypedAssetContentKey<DailyChallengeDefinition>
{
	public DailyChallengeDefinitionContentKey(string key)
		: base(key)
	{
	}
}
