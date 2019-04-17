// INonRegisteredTransactorUpgradeSender
using Disney.Mix.SDK;
using System;

public interface INonRegisteredTransactorUpgradeSender
{
	void Send(string lookupValue, string languageCode, Action<ISendNonRegisteredTransactorUpgradeResult> callback);
}
