// ClaimedRewardIdsData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;
using System.Collections.Generic;

[Serializable]
public class ClaimedRewardIdsData : ScopedData
{
	private List<int> rewardIds;

	public List<int> RewardIds
	{
		get
		{
			if (rewardIds == null)
			{
				rewardIds = new List<int>();
			}
			return rewardIds;
		}
		internal set
		{
			if (value != null)
			{
				rewardIds = new List<int>(value);
			}
			else
			{
				rewardIds = new List<int>();
			}
		}
	}

	protected override string scopeID => CPDataScopes.Session.ToString();

	protected override Type monoBehaviourType => typeof(ClaimedRewardIdsDataMonoBehaviour);

	protected override void notifyWillBeDestroyed()
	{
	}
}
