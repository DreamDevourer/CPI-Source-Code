// IMixSessionStarter
using Disney.Mix.SDK.Internal;
using System;

public interface IMixSessionStarter
{
	void Start(string swid, string guestControllerAccessToken, Action<MixSessionStartResult> successCallback, Action failureCallback);
}
