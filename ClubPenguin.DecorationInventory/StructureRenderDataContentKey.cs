// StructureRenderDataContentKey
using ClubPenguin.DecorationInventory;
using Disney.Kelowna.Common;
using System;

[Serializable]
public class StructureRenderDataContentKey : TypedAssetContentKey<StructureRenderData>
{
	public StructureRenderDataContentKey(string key)
		: base(key)
	{
	}
}
