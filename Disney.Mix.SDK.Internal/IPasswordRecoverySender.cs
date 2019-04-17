// IPasswordRecoverySender
using Disney.Mix.SDK;
using System;

public interface IPasswordRecoverySender
{
	void Send(string lookupValue, string languageCode, Action<ISendPasswordRecoveryResult> callback);
}
