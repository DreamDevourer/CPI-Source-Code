// MembershipData
using ClubPenguin;
using Disney.Kelowna.Common;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class MembershipData : BaseData
{
	[SerializeField]
	private bool isMember;

	[SerializeField]
	private MembershipType membershipType;

	private long membershipExpireDate;

	public bool IsMember
	{
		get
		{
			return isMember;
		}
		set
		{
			bool flag = isMember;
			isMember = value;
			if (value != flag)
			{
				dispatchUpdatedAction();
			}
		}
	}

	public MembershipType MembershipType
	{
		get
		{
			return membershipType;
		}
		set
		{
			MembershipType membershipType = this.membershipType;
			this.membershipType = value;
			if (value != membershipType)
			{
				dispatchUpdatedAction();
			}
		}
	}

	public long MembershipExpireDate
	{
		get
		{
			return membershipExpireDate;
		}
		set
		{
			membershipExpireDate = value;
		}
	}

	public bool MembershipTrialAvailable
	{
		get;
		set;
	}

	public bool HasHadMembership => MembershipExpireDate > 0;

	public DateTime MembershipExpireDateTime => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(MembershipExpireDate).ToLocalTime();

	protected override Type monoBehaviourType => typeof(MembershipDataMonoBehaviour);

	public event Action<MembershipData> MembershipDataUpdated;

	private void dispatchUpdatedAction()
	{
		if (this.MembershipDataUpdated != null)
		{
			this.MembershipDataUpdated.InvokeSafe(this);
		}
	}

	protected override void notifyWillBeDestroyed()
	{
		this.MembershipDataUpdated = null;
	}

	public override string ToString()
	{
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(MembershipExpireDate).ToLocalTime();
		return $"membershipData: \n \t IsMember {IsMember}, \n \t MembershipExpireDate: {dateTime.ToShortDateString()}, {MembershipExpireDate}";
	}
}
