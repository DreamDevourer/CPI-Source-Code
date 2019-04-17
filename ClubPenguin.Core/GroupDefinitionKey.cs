// GroupDefinitionKey
using ClubPenguin.Core;
using Disney.Kelowna.Common;
using System;

[Serializable]
public class GroupDefinitionKey : TypedAssetContentKey<GroupDefinition>
{
	public GroupDefinitionKey(string key)
		: base(key)
	{
	}
}
