// IJoinRoomByNameErrorHandler
using ClubPenguin.Net;

public interface IJoinRoomByNameErrorHandler : IJoinRoomErrorHandler, IBaseNetworkErrorHandler
{
	void onNoRoomsFound();
}
