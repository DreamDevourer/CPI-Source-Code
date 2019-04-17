// PlayerCardData
using Disney.Kelowna.Common.DataModel;
using System;

[Serializable]
public class PlayerCardData : BaseData
{
	public bool Enabled = true;

	public bool IsPlayerCardShowing;

	protected override void notifyWillBeDestroyed()
	{
	}
}
