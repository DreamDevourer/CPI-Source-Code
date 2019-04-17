// DecorationDefinitionContentKey
using ClubPenguin.DCE;
using Disney.Kelowna.Common;
using System;

[Serializable]
public class DecorationDefinitionContentKey : TypedAssetContentKey<DecorationDefinition>
{
	public DecorationDefinitionContentKey()
	{
	}

	public DecorationDefinitionContentKey(string key)
		: base(key)
	{
	}

	public DecorationDefinitionContentKey(AssetContentKey key, params string[] args)
		: base(key, args)
	{
	}
}
