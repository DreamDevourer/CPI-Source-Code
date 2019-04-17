// GetOtherPlayerDatasOperation
using ClubPenguin.Net.Client;
using ClubPenguin.Net.Client.Mappers;
using ClubPenguin.Net.Domain;
using hg.ApiWebKit.core.attributes;
using hg.ApiWebKit.mappers;
using System.Collections.Generic;

[HttpPOST]
[HttpAccept("application/json")]
[HttpBasicAuthorization("cp-api-username", "cp-api-password")]
public abstract class GetOtherPlayerDatasOperation : CPAPIHttpOperation
{
	[HttpResponseJsonBody]
	public List<OtherPlayerData> ResponseBody;

	public GetOtherPlayerDatasOperation()
	{
	}

	protected override void PerformOfflineAction(OfflineDatabase offlineDatabase, IOfflineDefinitionLoader offlineDefinitions)
	{
		ResponseBody = new List<OtherPlayerData>();
	}
}
