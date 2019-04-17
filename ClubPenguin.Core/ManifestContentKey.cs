// ManifestContentKey
using ClubPenguin.Core;
using Disney.Kelowna.Common;
using System;

[Serializable]
public class ManifestContentKey : TypedAssetContentKey<Manifest>
{
	public ManifestContentKey()
	{
	}

	public ManifestContentKey(string key)
		: base(key)
	{
	}
}
