// IglooListingData
using ClubPenguin;
using ClubPenguin.Net.Domain;
using Disney.Kelowna.Common;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class IglooListingData : BaseData
{
	[SerializeField]
	private RoomPopulationScale roomPopulationScale;

	private DateTime timeUpdated;

	public DateTime TimeUpdated => timeUpdated;

	public RoomPopulationScale RoomPopulation
	{
		get
		{
			return roomPopulationScale;
		}
		set
		{
			timeUpdated = DateTime.Now;
			roomPopulationScale = value;
			this.IglooListingDataUpdated.InvokeSafe(this);
		}
	}

	protected override Type monoBehaviourType => typeof(IglooListingDataMonoBehaviour);

	public event Action<IglooListingData> IglooListingDataUpdated;

	protected override void notifyWillBeDestroyed()
	{
		this.IglooListingDataUpdated = null;
	}
}
