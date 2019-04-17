// IInternalOfflineLastSessionResult
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public interface IInternalOfflineLastSessionResult : IOfflineLastSessionResult
{
	IInternalSession InternalSession
	{
		get;
	}
}
