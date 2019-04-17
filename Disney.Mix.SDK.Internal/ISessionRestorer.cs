// ISessionRestorer
using Disney.Mix.SDK;
using System;

public interface ISessionRestorer
{
	void RestoreLastSession(Action<IRestoreLastSessionResult> callback);
}
