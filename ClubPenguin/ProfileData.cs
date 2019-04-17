// ProfileData
using ClubPenguin;
using ClubPenguin.Net.Domain;
using Disney.Kelowna.Common.DataModel;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ProfileData : BaseData
{
	[SerializeField]
	private bool isOnline;

	[SerializeField]
	private bool isFTUEComplete;

	[SerializeField]
	private Dictionary<string, long> mascotXP;

	[SerializeField]
	private ZoneId zoneId;

	public bool IsOnline
	{
		get
		{
			return isOnline;
		}
		set
		{
			isOnline = value;
			dispatchUpdatedAction();
		}
	}

	public int PenguinAgeInDays
	{
		get;
		set;
	}

	public bool IsFirstTimePlayer
	{
		get;
		set;
	}

	public bool IsMigratedPlayer
	{
		get;
		set;
	}

	public bool HasPublicIgloo => ZoneId != null && !ZoneId.isEmpty();

	public bool IsFTUEComplete
	{
		get
		{
			return isFTUEComplete;
		}
		set
		{
			isFTUEComplete = value;
			dispatchUpdatedAction();
		}
	}

	public Dictionary<string, long> MascotXP
	{
		get
		{
			return mascotXP;
		}
		set
		{
			mascotXP = value;
			dispatchUpdatedAction();
		}
	}

	public ZoneId ZoneId
	{
		get
		{
			return zoneId;
		}
		set
		{
			zoneId = value;
			dispatchUpdatedAction();
		}
	}

	protected override Type monoBehaviourType => typeof(ProfileDataMonoBehaviour);

	public event Action<ProfileData> ProfileDataUpdated;

	private void dispatchUpdatedAction()
	{
		if (this.ProfileDataUpdated != null)
		{
			this.ProfileDataUpdated(this);
		}
	}

	public override string ToString()
	{
		return $"profileData: \n \t PenguinAge: {PenguinAgeInDays},  \n \t IsFirstTimePlayer: {IsFirstTimePlayer}, \n \t IsFTUEComplete: {IsFTUEComplete}, \n \t IsMigratedPlayer: {IsMigratedPlayer}, \n \t ZoneId: {ZoneId}";
	}

	protected override void notifyWillBeDestroyed()
	{
		this.ProfileDataUpdated = null;
	}
}
