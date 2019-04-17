// MembershipRightsRefresh
using System;

[Serializable]
public struct MembershipRightsRefresh
{
	public bool isMember;

	public long expireDate;

	public string vendor;

	public string productId;
}
