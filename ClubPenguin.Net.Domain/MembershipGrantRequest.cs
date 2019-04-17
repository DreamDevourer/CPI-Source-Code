// MembershipGrantRequest
using System;

[Serializable]
public struct MembershipGrantRequest
{
	public bool membershipStatus;

	public int daysOfMembership;

	public MembershipGrantRequest(bool membershipStatus, int daysOfMembership)
	{
		this.membershipStatus = membershipStatus;
		this.daysOfMembership = daysOfMembership;
	}
}
