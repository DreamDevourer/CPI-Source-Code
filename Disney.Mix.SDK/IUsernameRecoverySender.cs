// IUsernameRecoverySender
using Disney.Mix.SDK;
using System;

public interface IUsernameRecoverySender
{
	void Send(string lookupValue, string languageCode, Action<ISendUsernameRecoveryResult> callback);
}
