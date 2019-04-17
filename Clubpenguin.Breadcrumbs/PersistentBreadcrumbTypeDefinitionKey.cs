// PersistentBreadcrumbTypeDefinitionKey
using ClubPenguin.Breadcrumbs;
using ClubPenguin.Core.StaticGameData;
using System;

[Serializable]
public class PersistentBreadcrumbTypeDefinitionKey : TypedStaticGameDataKey<PersistentBreadcrumbTypeDefinition, int>
{
	public PersistentBreadcrumbTypeDefinitionKey(int type)
	{
		Id = type;
	}
}
