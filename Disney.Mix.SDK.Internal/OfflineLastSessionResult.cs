// OfflineLastSessionResult
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;

public class OfflineLastSessionResult : IInternalOfflineLastSessionResult, IOfflineLastSessionResult
{
	public bool Success
	{
		get;
		private set;
	}

	public ISession Session => InternalSession;

	public IInternalSession InternalSession
	{
		get;
		private set;
	}

	public OfflineLastSessionResult(bool success, IInternalSession session)
	{
		Success = success;
		InternalSession = session;
	}
}
