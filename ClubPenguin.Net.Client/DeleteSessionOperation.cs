// DeleteSessionOperation
using ClubPenguin.Net.Client;
using ClubPenguin.Net.Client.Mappers;
using hg.ApiWebKit.core.attributes;

[HttpDELETE]
[HttpPath("cp-api-base-uri", "/game/v1/session/{$sessionId}")]
[HttpBasicAuthorization("cp-api-username", "cp-api-password")]
public class DeleteSessionOperation : CPAPIHttpOperation
{
	[HttpUriSegment("sessionId")]
	public long SessionId;

	public DeleteSessionOperation(long sessionId)
	{
		SessionId = sessionId;
	}

	protected override void PerformOfflineAction(OfflineDatabase offlineDatabase, IOfflineDefinitionLoader offlineDefinitions)
	{
	}
}
