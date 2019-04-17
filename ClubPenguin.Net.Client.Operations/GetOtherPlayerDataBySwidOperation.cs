// GetOtherPlayerDataBySwidOperation
using ClubPenguin.Net.Client.Operations;
using hg.ApiWebKit.core.attributes;

[HttpPath("cp-api-base-uri", "/player/v1/id/{$swid}")]
public class GetOtherPlayerDataBySwidOperation : GetOtherPlayerDataOperation
{
	[HttpUriSegment("swid")]
	public string Swid;

	public GetOtherPlayerDataBySwidOperation(string swid)
	{
		Swid = swid;
	}
}
