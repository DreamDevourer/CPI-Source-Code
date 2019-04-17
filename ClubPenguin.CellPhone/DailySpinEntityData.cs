// DailySpinEntityData
using ClubPenguin;
using ClubPenguin.CellPhone;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class DailySpinEntityData : ScopedData
{
	[SerializeField]
	public long TimeOfLastSpinInMilliseconds;

	[SerializeField]
	public int CurrentChestId;

	[SerializeField]
	public int NumPunchesOnCurrentChest;

	[SerializeField]
	public int NumChestsReceivedOfCurrentChestId;

	protected override Type monoBehaviourType => typeof(DailySpinEntityDataMonoBehaviour);

	protected override string scopeID => CPDataScopes.Session.ToString();

	protected override void notifyWillBeDestroyed()
	{
	}
}
