// FriendInvitationAcceptedEventArgs
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

internal class FriendInvitationAcceptedEventArgs : AbstractFriendInvitationAcceptedEventArgs
{
	public FriendInvitationAcceptedEventArgs(bool trustAccepted, IInternalFriend friend)
	{
		base.TrustAccepted = trustAccepted;
		base.Friend = friend;
	}
}
