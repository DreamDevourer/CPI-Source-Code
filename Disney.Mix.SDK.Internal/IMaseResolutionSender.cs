// IMaseResolutionSender
using Disney.Mix.SDK;
using System;

public interface IMaseResolutionSender
{
	void Send(string lookupValue, string languageCode, Action<ISendMultipleAccountsResolutionResult> callback);
}
