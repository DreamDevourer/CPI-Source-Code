// IWwwCallFactory
using Disney.Mix.SDK.Internal;
using System;
using System.Collections.Generic;

public interface IWwwCallFactory
{
	IWwwCall Create(Uri uri, HttpMethod method, byte[] body, Dictionary<string, string> headers, long latencyWwwCallTimeout, long maxWwwCallTimeout);
}
