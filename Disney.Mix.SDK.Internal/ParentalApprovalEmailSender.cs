// ParentalApprovalEmailSender
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System;

public static class ParentalApprovalEmailSender
{
	public static void SendParentalApprovalEmail(AbstractLogger logger, string languageCode, IGuestControllerClient guestControllerClient, Action<ISendParentalApprovalEmailResult> callback)
	{
		try
		{
			guestControllerClient.SendParentalApprovalEmail(languageCode, delegate(GuestControllerResult<NotificationResponse> r)
			{
				callback(new SendParentalApprovalEmailResult(r.Success && r.Response.data != null));
			});
		}
		catch (Exception arg)
		{
			logger.Critical("Unhandled exception: " + arg);
			callback(new SendParentalApprovalEmailResult(success: false));
		}
	}
}
