// ISessionLogin
using Disney.Mix.SDK;
using System;

public interface ISessionLogin
{
	void Login(string username, string password, Action<ILoginResult> callback);
}
