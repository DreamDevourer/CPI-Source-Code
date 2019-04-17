// ISessionReuser
using Disney.Mix.SDK;
using System;

public interface ISessionReuser
{
	void Reuse(string swid, string accessToken, string refreshToken, string displayName, string proposedDisplayName, string proposedDisplayNameStatus, string firstName, string etag, string ageBand, string accountStatus, string countryCode, Action<IReuseExistingGuestControllerLoginResult> callback);
}
