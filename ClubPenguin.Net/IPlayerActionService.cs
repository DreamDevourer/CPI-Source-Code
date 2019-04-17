// IPlayerActionService
using ClubPenguin.Net;
using ClubPenguin.Net.Client.Event;

public interface IPlayerActionService : INetworkService
{
	void LocomotionAction(LocomotionActionEvent action, bool droppable = false);
}
