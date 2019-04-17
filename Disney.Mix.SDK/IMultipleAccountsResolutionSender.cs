// IMultipleAccountsResolutionSender
using Disney.Mix.SDK;
using System;

public interface IMultipleAccountsResolutionSender
{
	void Send(string lookupValue, string languageCode, Action<ISendMultipleAccountsResolutionResult> callback);
}
