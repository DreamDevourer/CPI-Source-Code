// RemotePlayerData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;

[Serializable]
public class RemotePlayerData : ScopedData
{
	protected override string scopeID => CPDataScopes.Zone.ToString();

	protected override Type monoBehaviourType => typeof(RemotePlayerDataMonoBehaviour);

	public event Action<RemotePlayerData> PlayerRemoved;

	protected override void notifyWillBeDestroyed()
	{
		if (this.PlayerRemoved != null)
		{
			this.PlayerRemoved(this);
		}
		this.PlayerRemoved = null;
	}
}
