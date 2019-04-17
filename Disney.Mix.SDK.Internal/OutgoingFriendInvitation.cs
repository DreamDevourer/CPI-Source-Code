// OutgoingFriendInvitation
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class OutgoingFriendInvitation : AbstractFriendInvitation, IInternalOutgoingFriendInvitation, IOutgoingFriendInvitation
{
	private readonly IInternalLocalUser inviter;

	private readonly IInternalUnidentifiedUser invitee;

	public ILocalUser Inviter => inviter;

	public IUnidentifiedUser Invitee => invitee;

	public IInternalLocalUser InternalInviter => inviter;

	public IInternalUnidentifiedUser InternalInvitee => invitee;

	public OutgoingFriendInvitation(IInternalLocalUser inviter, IInternalUnidentifiedUser invitee, bool requestTrust)
		: base(requestTrust)
	{
		this.inviter = inviter;
		this.invitee = invitee;
	}
}
