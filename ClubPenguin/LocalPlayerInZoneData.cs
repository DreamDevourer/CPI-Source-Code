// LocalPlayerInZoneData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;

[Serializable]
public class LocalPlayerInZoneData : BaseData
{
	protected override Type monoBehaviourType => typeof(LocalPlayerInZoneDataDataMonoBehaviour);

	public event Action<LocalPlayerInZoneData> LocalPlayerLeftZone;

	protected override void notifyWillBeDestroyed()
	{
		if (this.LocalPlayerLeftZone != null)
		{
			this.LocalPlayerLeftZone(this);
		}
		this.LocalPlayerLeftZone = null;
	}
}
