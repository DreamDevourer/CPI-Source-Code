// GetOtherPlayerDataBySessionIdOperation
using ClubPenguin.Net.Client.Operations;
using hg.ApiWebKit.core.attributes;

[HttpPath("cp-api-base-uri", "/player/v1/session/{$sessionId}")]
public class GetOtherPlayerDataBySessionIdOperation : GetOtherPlayerDataOperation
{
	[HttpUriSegment("sessionId")]
	public long SessionId;

	public GetOtherPlayerDataBySessionIdOperation(long sessionId)
	{
		SessionId = sessionId;
	}
}
