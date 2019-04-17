// IAssetLoader
using Disney.Mix.SDK.Internal;
using System;

public interface IAssetLoader
{
	void Load(string url, Action<LoadAssetResult> callback);
}
