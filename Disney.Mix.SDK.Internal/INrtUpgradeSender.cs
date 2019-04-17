// INrtUpgradeSender
using Disney.Mix.SDK;
using System;

public interface INrtUpgradeSender
{
	void Send(string lookupValue, string languageCode, Action<ISendNonRegisteredTransactorUpgradeResult> callback);
}
