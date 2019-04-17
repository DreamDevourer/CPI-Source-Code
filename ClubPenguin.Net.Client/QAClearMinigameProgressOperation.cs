// QAClearMinigameProgressOperation
using ClubPenguin.Net.Client;
using ClubPenguin.Net.Client.Mappers;
using hg.ApiWebKit.core.attributes;

[HttpPath("cp-api-base-uri", "/minigame/v1/qa/progress")]
[HttpBasicAuthorization("cp-api-username", "cp-api-password")]
[HttpDELETE]
public class QAClearMinigameProgressOperation : CPAPIHttpOperation
{
	protected override void PerformOfflineAction(OfflineDatabase offlineDatabase, IOfflineDefinitionLoader offlineDefinitions)
	{
	}
}
