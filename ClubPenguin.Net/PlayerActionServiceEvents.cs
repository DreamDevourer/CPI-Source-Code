// PlayerActionServiceEvents
using ClubPenguin.Net.Client.Event;

public static class PlayerActionServiceEvents
{
	public struct LocomotionActionReceived
	{
		public readonly long SessionId;

		public readonly LocomotionActionEvent Action;

		public LocomotionActionReceived(long sessionId, LocomotionActionEvent action)
		{
			SessionId = sessionId;
			Action = action;
		}
	}
}
