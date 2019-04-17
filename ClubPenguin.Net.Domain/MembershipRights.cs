// MembershipRights
using System;

[Serializable]
public struct MembershipRights
{
	public string swid;

	public bool member;

	public bool recurring;

	public long recurDate;

	public long expireDate;
}
