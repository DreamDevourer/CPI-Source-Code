// SendFriendInvitationAlreadyFriendsResult
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class SendFriendInvitationAlreadyFriendsResult : SendFriendInvitationResult, ISendFriendInvitationAlreadyFriendsResult
{
	public SendFriendInvitationAlreadyFriendsResult(bool success, IOutgoingFriendInvitation invitation)
		: base(success, invitation)
	{
	}
}
