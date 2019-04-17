// DecorationRenderDataContentKey
using ClubPenguin.DecorationInventory;
using Disney.Kelowna.Common;
using System;

[Serializable]
public class DecorationRenderDataContentKey : TypedAssetContentKey<DecorationRenderData>
{
	public DecorationRenderDataContentKey(string key)
		: base(key)
	{
	}
}
