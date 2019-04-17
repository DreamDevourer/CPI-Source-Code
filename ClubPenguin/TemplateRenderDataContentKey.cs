// TemplateRenderDataContentKey
using ClubPenguin;
using Disney.Kelowna.Common;
using System;

[Serializable]
public class TemplateRenderDataContentKey : TypedAssetContentKey<TemplateRenderData>
{
	public TemplateRenderDataContentKey(string key)
		: base(key)
	{
	}
}
