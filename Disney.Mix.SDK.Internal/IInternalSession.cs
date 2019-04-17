// IInternalSession
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using System;

public interface IInternalSession : ISession, IDisposable
{
	IInternalLocalUser InternalLocalUser
	{
		get;
	}
}
