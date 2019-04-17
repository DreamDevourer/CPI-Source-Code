// IncomingFriendInvitation
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class IncomingFriendInvitation : AbstractFriendInvitation, IInternalIncomingFriendInvitation, IIncomingFriendInvitation
{
	private readonly IInternalUnidentifiedUser inviter;

	private readonly IInternalLocalUser invitee;

	public IUnidentifiedUser Inviter => inviter;

	public ILocalUser Invitee => invitee;

	public IInternalUnidentifiedUser InternalInviter => inviter;

	public IInternalLocalUser InternalInvitee => invitee;

	public IncomingFriendInvitation(IInternalUnidentifiedUser inviter, IInternalLocalUser invitee, bool requestTrust)
		: base(requestTrust)
	{
		this.inviter = inviter;
		this.invitee = invitee;
	}
}
