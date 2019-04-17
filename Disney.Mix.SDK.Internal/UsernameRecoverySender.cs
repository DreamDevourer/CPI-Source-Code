// UsernameRecoverySender
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System;

public class UsernameRecoverySender : Disney.Mix.SDK.Internal.IUsernameRecoverySender
{
	private readonly AbstractLogger logger;

	private readonly IGuestControllerClient guestControllerClient;

	public UsernameRecoverySender(AbstractLogger logger, IGuestControllerClient guestControllerClient)
	{
		this.logger = logger;
		this.guestControllerClient = guestControllerClient;
	}

	public void Send(string lookupValue, string languageCode, Action<ISendUsernameRecoveryResult> callback)
	{
		try
		{
			RecoverRequest recoverRequest = new RecoverRequest();
			recoverRequest.lookupValue = lookupValue;
			RecoverRequest request = recoverRequest;
			guestControllerClient.RecoverUsername(request, languageCode, delegate(GuestControllerResult<NotificationResponse> r)
			{
				if (!r.Success)
				{
					callback(new SendUsernameRecoveryResult(success: false));
				}
				else
				{
					ISendUsernameRecoveryResult recoverUsernameResult = GuestControllerErrorParser.GetRecoverUsernameResult(r.Response.error);
					if (recoverUsernameResult != null)
					{
						callback(recoverUsernameResult);
					}
					else
					{
						callback(new SendUsernameRecoveryResult(r.Response.data != null));
					}
				}
			});
		}
		catch (Exception arg)
		{
			logger.Critical("Unhandled exception: " + arg);
			callback(new SendUsernameRecoveryResult(success: false));
		}
	}
}
