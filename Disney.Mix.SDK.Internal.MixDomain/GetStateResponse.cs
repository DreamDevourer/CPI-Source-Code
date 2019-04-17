// GetStateResponse
using Disney.Mix.SDK.Internal.MixDomain;
using System.Collections.Generic;

public class GetStateResponse : BaseResponse
{
	public List<User> Users;

	public List<Friendship> Friendships;

	public List<FriendshipInvitation> FriendshipInvitations;

	public List<Alert> Alerts;

	public List<int?> PollIntervals;

	public List<int?> PokeIntervals;

	public long? Timestamp;

	public long? NotificationSequenceCounter;

	public int? NotificationSequenceThreshold;

	public int? NotificationIntervalsJitter;
}
