// ModerationService
using ClubPenguin.Net;
using ClubPenguin.Net.Client;

public class ModerationService : BaseNetworkService, IModerationService, INetworkService
{
	protected override void setupListeners()
	{
	}

	public void ReportPlayer(string displayName, string reason)
	{
		APICall<ReportPlayerOperation> aPICall = clubPenguinClient.ModerationApi.ReportPlayer(displayName, reason);
		aPICall.OnError += handleCPResponseError;
		aPICall.Execute();
	}
}
