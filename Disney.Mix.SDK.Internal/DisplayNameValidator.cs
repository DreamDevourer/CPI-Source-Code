// DisplayNameValidator
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using Disney.Mix.SDK.Internal.MixDomain;
using System;
using System.Collections.Generic;
using System.Linq;

public static class DisplayNameValidator
{
	public static void ValidateDisplayName(AbstractLogger logger, IGuestControllerClient guestControllerClient, IMixWebCallFactory mixWebCallFactory, string displayName, Action<IValidateDisplayNameResult> callback)
	{
		try
		{
			ModerateTextRequest moderateTextRequest = new ModerateTextRequest();
			moderateTextRequest.ModerationPolicy = "DisplayName";
			moderateTextRequest.Text = displayName;
			ModerateTextRequest request = moderateTextRequest;
			IWebCall<ModerateTextRequest, ModerateTextResponse> webCall = mixWebCallFactory.ModerationTextPut(request);
			webCall.OnResponse += delegate(object sender, WebCallEventArgs<ModerateTextResponse> e)
			{
				ModerateTextResponse response = e.Response;
				if (ValidateModerateTextResponse(response))
				{
					if (response.Moderated.Value)
					{
						callback(new ValidateDisplayNameFailedModerationResult(success: false));
					}
					else
					{
						CheckForValidation(guestControllerClient, displayName, callback);
					}
				}
				else
				{
					logger.Critical("Failed to validate moderate display name response!");
					callback(new ValidateDisplayNameResult(success: false));
				}
			};
			webCall.OnError += delegate
			{
				callback(new ValidateDisplayNameResult(success: false));
			};
			webCall.Execute();
		}
		catch (Exception arg)
		{
			logger.Critical("Unhandled exception: " + arg);
			callback(new ValidateDisplayNameExistsResult(success: false));
		}
	}

	public static void ValidateDisplayNames(AbstractLogger logger, IMixWebCallFactory mixWebCallFactory, IEnumerable<string> displayNames, Action<IValidateDisplayNamesResult> callback)
	{
		try
		{
			List<string> list = new List<string>();
			list.AddRange(displayNames);
			ValidateDisplayNamesRequest validateRequest = new ValidateDisplayNamesRequest
			{
				DisplayNames = list
			};
			IWebCall<ValidateDisplayNamesRequest, ValidateDisplayNamesResponse> webCall = mixWebCallFactory.DisplaynameValidatePost(validateRequest);
			webCall.OnResponse += delegate(object sender, WebCallEventArgs<ValidateDisplayNamesResponse> e)
			{
				ValidateDisplayNamesResponse response = e.Response;
				if (response.DisplayNames != null)
				{
					callback(new ValidateDisplayNamesResult(success: true, response.DisplayNames));
				}
				else
				{
					string str = string.Join(",", validateRequest.DisplayNames.ToArray());
					logger.Critical("Failed to validate display names " + str);
					callback(new ValidateDisplayNamesResult(success: false, Enumerable.Empty<string>()));
				}
			};
			webCall.OnError += delegate
			{
				callback(new ValidateDisplayNamesResult(success: false, Enumerable.Empty<string>()));
			};
			webCall.Execute();
		}
		catch (Exception arg)
		{
			logger.Critical("Unhandled exception: " + arg);
			callback(new ValidateDisplayNamesResult(success: false, Enumerable.Empty<string>()));
		}
	}

	public static void ValidateDisplayNameV2(AbstractLogger logger, IMixWebCallFactory mixWebCallFactory, string displayName, Action<IValidateDisplayNameResult> callback)
	{
		try
		{
			ValidateDisplayNameRequest validateDisplayNameRequest = new ValidateDisplayNameRequest();
			validateDisplayNameRequest.DisplayName = displayName;
			ValidateDisplayNameRequest request = validateDisplayNameRequest;
			IWebCall<ValidateDisplayNameRequest, ValidateDisplayNameResponse> webCall = mixWebCallFactory.DisplaynameValidateV2Post(request);
			webCall.OnResponse += delegate(object sender, WebCallEventArgs<ValidateDisplayNameResponse> e)
			{
				ValidateDisplayNameResponse response = e.Response;
				if (response.DisplayNameStatus == "VALID")
				{
					callback(new ValidateDisplayNameResult(success: true));
				}
				else if (response.DisplayNameStatus == "IN_USE")
				{
					callback(new ValidateDisplayNameExistsResult(success: false, response.DisplayNames));
				}
				else
				{
					callback(new ValidateDisplayNameFailedModerationResult(success: false));
				}
			};
			webCall.OnError += delegate
			{
				callback(new ValidateDisplayNameFailedModerationResult(success: false));
			};
			webCall.Execute();
		}
		catch (Exception arg)
		{
			logger.Critical("Unhandled exception: " + arg);
			callback(new ValidateDisplayNameFailedModerationResult(success: false));
		}
	}

	private static bool ValidateModerateTextResponse(ModerateTextResponse response)
	{
		return response.Moderated.HasValue && response.Text != null;
	}

	private static void CheckForValidation(IGuestControllerClient guestControllerClient, string displayName, Action<IValidateDisplayNameResult> callback)
	{
		ValidateRequest validateRequest = new ValidateRequest();
		validateRequest.displayName = displayName;
		ValidateRequest request = validateRequest;
		guestControllerClient.Validate(request, delegate(GuestControllerResult<ValidateResponse> r)
		{
			if (!r.Success)
			{
				callback(new ValidateDisplayNameResult(success: false));
			}
			else
			{
				ValidateResponse response = r.Response;
				if (response.error == null)
				{
					callback(new ValidateDisplayNameResult(success: true));
				}
				else
				{
					callback(new ValidateDisplayNameExistsResult(success: false));
				}
			}
		});
	}
}
