// InputButtonContentKey
using ClubPenguin.UI;
using Disney.Kelowna.Common;
using System;

[Serializable]
public class InputButtonContentKey : TypedAssetContentKey<InputButtonDefinition>
{
	public InputButtonContentKey(string key)
		: base(key)
	{
	}
}
