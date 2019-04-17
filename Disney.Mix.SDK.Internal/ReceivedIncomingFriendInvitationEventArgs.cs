// ReceivedIncomingFriendInvitationEventArgs
using Disney.Mix.SDK;

internal class ReceivedIncomingFriendInvitationEventArgs : AbstractReceivedIncomingFriendInvitationEventArgs
{
	public ReceivedIncomingFriendInvitationEventArgs(IIncomingFriendInvitation invitation)
	{
		base.Invitation = invitation;
	}
}
