// DisplayNameUpdater
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.MixDomain;
using System;

public static class DisplayNameUpdater
{
	public static void UpdateDisplayName(AbstractLogger logger, IMixWebCallFactory mixWebCallFactory, string displayName, Action<IUpdateDisplayNameResult> callback)
	{
		try
		{
			SetDisplayNameRequest setDisplayNameRequest = new SetDisplayNameRequest();
			setDisplayNameRequest.DisplayName = displayName;
			SetDisplayNameRequest request = setDisplayNameRequest;
			IWebCall<SetDisplayNameRequest, SetDisplayNameResponse> webCall = mixWebCallFactory.DisplaynamePut(request);
			webCall.OnResponse += delegate(object sender, WebCallEventArgs<SetDisplayNameResponse> e)
			{
				SetDisplayNameResponse response = e.Response;
				if (ValidateSetDisplayNameResponse(response))
				{
					callback(new UpdateDisplayNameResult(success: true));
				}
				else
				{
					logger.Critical("Failed to validate update display name response!");
					callback(new UpdateDisplayNameResult(success: false));
				}
			};
			webCall.OnError += delegate(object sender, WebCallErrorEventArgs e)
			{
				switch (e.Status)
				{
				case "DISPLAYNAME_MODERATION_FAILED":
					logger.Warning("Failed to update display name due to moderation failure: " + e.Message);
					callback(new UpdateDisplayNameFailedModerationResult(success: false));
					break;
				case "DISPLAYNAME_ASSIGNMENT_FAILED":
					logger.Warning("Failed to update display name due to assignment failure: " + e.Message);
					callback(new UpdateDisplayNameExistsResult(success: false));
					break;
				default:
					callback(new UpdateDisplayNameResult(success: false));
					break;
				}
			};
			webCall.Execute();
		}
		catch (Exception arg)
		{
			logger.Critical("Unhandled exception: " + arg);
			callback(new UpdateDisplayNameResult(success: false));
		}
	}

	private static bool ValidateSetDisplayNameResponse(SetDisplayNameResponse response)
	{
		return response.DisplayName != null;
	}
}
