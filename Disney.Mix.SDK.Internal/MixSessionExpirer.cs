// MixSessionExpirer
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.MixDomain;
using System;

public static class MixSessionExpirer
{
	public static void Expire(AbstractLogger logger, IMixWebCallFactory mixWebCallFactory, Action<bool> callback)
	{
		try
		{
			BaseUserRequest request = new BaseUserRequest();
			IWebCall<BaseUserRequest, BaseResponse> webCall = mixWebCallFactory.IntegrationTestSupportUserSessionExpirePost(request);
			webCall.OnResponse += delegate
			{
				callback(obj: true);
			};
			webCall.OnError += delegate
			{
				callback(obj: false);
			};
			webCall.Execute();
		}
		catch (Exception arg)
		{
			logger.Critical("Unhandled exception: " + arg);
			callback(obj: false);
		}
	}
}
