// IOfflineRoomRunner
using ClubPenguin.Net.Client.Event;

public interface IOfflineRoomRunner
{
	string RoomName
	{
		get;
	}

	void Start();

	void End();

	void HandleInteraction(LocomotionActionEvent action);
}
