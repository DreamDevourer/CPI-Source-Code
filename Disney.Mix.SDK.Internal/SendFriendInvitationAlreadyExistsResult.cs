// SendFriendInvitationAlreadyExistsResult
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class SendFriendInvitationAlreadyExistsResult : SendFriendInvitationResult, ISendFriendInvitationAlreadyExistsResult
{
	public SendFriendInvitationAlreadyExistsResult(bool success, IOutgoingFriendInvitation invitation)
		: base(success, invitation)
	{
	}
}
