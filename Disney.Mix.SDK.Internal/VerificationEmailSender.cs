// VerificationEmailSender
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System;

public static class VerificationEmailSender
{
	public static void SendVerificationEmail(AbstractLogger logger, string languageCode, IGuestControllerClient guestControllerClient, Action<ISendVerificationEmailResult> callback)
	{
		try
		{
			guestControllerClient.SendVerificationEmail(languageCode, delegate(GuestControllerResult<NotificationResponse> r)
			{
				callback(new SendVerificationEmailResult(r.Success && r.Response.error == null && r.Response.data != null));
			});
		}
		catch (Exception arg)
		{
			logger.Critical("Unhandled exception: " + arg);
			callback(new SendVerificationEmailResult(success: false));
		}
	}
}
