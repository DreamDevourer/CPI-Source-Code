// PushNotificationSettings
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.MixDomain;
using System;

public static class PushNotificationSettings
{
	public static void EnableAllPushNotifications(AbstractLogger logger, IDatabase database, IMixWebCallFactory mixWebCallFactory, string token, string serviceType, string provisionId, string swid, Action<IEnableAllPushNotificationsResult> callback)
	{
		string tokenType = GetTokenType(serviceType);
		Enable(logger, database, mixWebCallFactory, token, tokenType, provisionId, enableVisible: true, swid, delegate
		{
			callback(new EnableAllPushNotificationsResult(success: true));
		}, delegate
		{
			callback(new EnableAllPushNotificationsResult(success: false));
		});
	}

	public static void EnableInvisiblePushNotifications(AbstractLogger logger, IDatabase database, IMixWebCallFactory mixWebCallFactory, string token, string serviceType, string provisionId, string swid, Action<IEnableInvisiblePushNotificationsResult> callback)
	{
		string tokenType = GetTokenType(serviceType);
		Enable(logger, database, mixWebCallFactory, token, tokenType, provisionId, enableVisible: false, swid, delegate
		{
			callback(new EnableInvisiblePushNotificationsResult(success: true));
		}, delegate
		{
			callback(new EnableInvisiblePushNotificationsResult(success: false));
		});
	}

	public static void DisableAllPushNotifications(AbstractLogger logger, IDatabase database, IMixWebCallFactory mixWebCallFactory, string swid, Action<IDisableAllPushNotificationsResult> callback)
	{
		try
		{
			SessionDocument sessionDocument = database.GetSessionDocument(swid);
			if (sessionDocument.PushNotificationToken == null)
			{
				callback(new DisableAllPushNotificationsResult(success: false));
			}
			else
			{
				BaseUserRequest request = new BaseUserRequest();
				IWebCall<BaseUserRequest, BaseResponse> webCall = mixWebCallFactory.PushNotificationsSettingDeletePost(request);
				webCall.OnResponse += delegate
				{
					try
					{
						database.UpdateSessionDocument(swid, delegate(SessionDocument d)
						{
							d.PushNotificationToken = null;
							d.PushNotificationTokenType = null;
							d.VisiblePushNotificationsEnabled = false;
						});
						callback(new DisableAllPushNotificationsResult(success: true));
					}
					catch (Exception arg2)
					{
						logger.Critical("Unhandled exception: " + arg2);
						callback(new DisableAllPushNotificationsResult(success: false));
					}
				};
				webCall.OnError += delegate
				{
					callback(new DisableAllPushNotificationsResult(success: false));
				};
				webCall.Execute();
			}
		}
		catch (Exception arg)
		{
			logger.Critical("Unhandled exception: " + arg);
			callback(new DisableAllPushNotificationsResult(success: false));
		}
	}

	public static void DisableVisiblePushNotifications(AbstractLogger logger, IDatabase database, IMixWebCallFactory mixWebCallFactory, string swid, Action<IDisableVisiblePushNotificationsResult> callback)
	{
		SessionDocument sessionDocument = database.GetSessionDocument(swid);
		if (sessionDocument.PushNotificationToken == null)
		{
			callback(new DisableVisiblePushNotificationsResult(success: false));
		}
		else
		{
			Enable(logger, database, mixWebCallFactory, sessionDocument.PushNotificationToken, sessionDocument.PushNotificationTokenType, sessionDocument.ProvisionId, enableVisible: false, swid, delegate
			{
				callback(new DisableVisiblePushNotificationsResult(success: true));
			}, delegate
			{
				callback(new DisableVisiblePushNotificationsResult(success: false));
			});
		}
	}

	private static void Enable(AbstractLogger logger, IDatabase database, IMixWebCallFactory mixWebCallFactory, string token, string tokenType, string provisionId, bool enableVisible, string swid, Action successCallback, Action failureCallback)
	{
		try
		{
			TogglePushNotificationRequest togglePushNotificationRequest = new TogglePushNotificationRequest();
			togglePushNotificationRequest.PushToken = new PushToken
			{
				Token = token,
				TokenType = tokenType
			};
			togglePushNotificationRequest.State = (enableVisible ? "ALL" : "ONLY_SILENT");
			togglePushNotificationRequest.IosProvisioningId = provisionId;
			TogglePushNotificationRequest request = togglePushNotificationRequest;
			IWebCall<TogglePushNotificationRequest, BaseResponse> webCall = mixWebCallFactory.PushNotificationsSettingPost(request);
			webCall.OnResponse += delegate
			{
				try
				{
					database.UpdateSessionDocument(swid, delegate(SessionDocument sessionDoc)
					{
						sessionDoc.PushNotificationToken = token;
						sessionDoc.PushNotificationTokenType = tokenType;
						sessionDoc.VisiblePushNotificationsEnabled = enableVisible;
						sessionDoc.ProvisionId = provisionId;
					});
					successCallback();
				}
				catch (Exception arg2)
				{
					logger.Critical("Unhandled exception: " + arg2);
					failureCallback();
				}
			};
			webCall.OnError += delegate
			{
				failureCallback();
			};
			webCall.Execute();
		}
		catch (Exception arg)
		{
			logger.Critical("Unhandled exception: " + arg);
			failureCallback();
		}
	}

	private static string GetTokenType(string serviceType)
	{
		switch (serviceType)
		{
		case "Apple":
		case "APNS":
			return "APNS";
		case "Google":
		case "GCM":
			return "GCM";
		default:
			throw new ArgumentException("Unsupported push notification service: " + serviceType);
		}
	}
}
