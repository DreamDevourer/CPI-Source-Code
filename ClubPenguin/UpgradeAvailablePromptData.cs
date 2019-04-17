// UpgradeAvailablePromptData
using Disney.Kelowna.Common.DataModel;
using System;

[Serializable]
public class UpgradeAvailablePromptData : BaseData
{
	public bool HasSeenUpgradeAvailablePrompt;

	protected override void notifyWillBeDestroyed()
	{
	}
}
