// ProfileGetter
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System;

public static class ProfileGetter
{
	public static void GetProfile(AbstractLogger logger, IGuestControllerClient guestControllerClient, Action<ProfileData> callback)
	{
		try
		{
			guestControllerClient.GetProfile(delegate(GuestControllerResult<ProfileResponse> r)
			{
				callback(r.Success ? r.Response.data : null);
			});
		}
		catch (Exception arg)
		{
			logger.Critical("Unhandled exception: " + arg);
			callback(null);
		}
	}
}
