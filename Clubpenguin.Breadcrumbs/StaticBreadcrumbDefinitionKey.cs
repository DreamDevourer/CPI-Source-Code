// StaticBreadcrumbDefinitionKey
using ClubPenguin.Breadcrumbs;
using ClubPenguin.Core.StaticGameData;
using System;

[Serializable]
public class StaticBreadcrumbDefinitionKey : TypedStaticGameDataKey<StaticBreadcrumbDefinition, string>
{
	public StaticBreadcrumbDefinitionKey(string id)
	{
		Id = id;
	}
}
