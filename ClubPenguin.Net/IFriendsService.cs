// IFriendsService
using ClubPenguin.Net;
using Disney.Mix.SDK;

public interface IFriendsService : INetworkService
{
	void SetLocalUser(ILocalUser localUser);

	void ClearLocalUser(ILocalUser localUser);

	void AddMixFriendEventsListener(IFriendEvents mixFriendEvents);

	void FindUser(string displayName, ILocalUser localUser);

	void SendFriendInvitation(IUnidentifiedUser searchedUser, ILocalUser localUser);

	void AcceptFriendInvitation(IIncomingFriendInvitation incomingFriendInvitation, ILocalUser localUser);

	void RejectFriendInvitation(IIncomingFriendInvitation incomingFriendInvitation, ILocalUser localUser);

	void Unfriend(IFriend friend, ILocalUser localUser);

	void GetFriendLocationInRoom(string swid);
}
