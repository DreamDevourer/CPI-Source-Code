// IJoinRoomErrorHandler
using ClubPenguin.Net;

public interface IJoinRoomErrorHandler : IBaseNetworkErrorHandler
{
	void onRoomFull();

	void onNoServerFound();

	void onRoomJoinError();
}
