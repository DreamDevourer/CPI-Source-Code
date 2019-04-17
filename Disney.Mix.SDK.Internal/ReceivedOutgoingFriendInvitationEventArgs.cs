// ReceivedOutgoingFriendInvitationEventArgs
using Disney.Mix.SDK;

internal class ReceivedOutgoingFriendInvitationEventArgs : AbstractReceivedOutgoingFriendInvitationEventArgs
{
	public ReceivedOutgoingFriendInvitationEventArgs(IOutgoingFriendInvitation invitation)
	{
		base.Invitation = invitation;
	}
}
