// ProfileUpdater
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.GuestControllerDomain;
using System;
using System.Collections.Generic;
using System.Linq;

public static class ProfileUpdater
{
	private const string UpdateProfileKeyFirstName = "firstName";

	private const string UpdateProfileKeyLastName = "lastName";

	private const string UpdateProfileKeyEmail = "email";

	private const string UpdateProfileKeyParentEmail = "parentEmail";

	private const string UpdateProfileKeyDateOfBirth = "dateOfBirth";

	public static void UpdateProfile(AbstractLogger logger, IGuestControllerClient guestControllerClient, IDatabase database, string swid, IEpochTime epochTime, IInternalRegistrationProfile profile, string firstName, string lastName, string displayName, string email, string parentEmail, DateTime? dateOfBirth, IEnumerable<KeyValuePair<IMarketingItem, bool>> marketingAgreements, IEnumerable<ILegalDocument> acceptedLegalDocuments, Action<IUpdateProfileResult> callback)
	{
		try
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(firstName))
			{
				dictionary.Add("firstName", firstName);
			}
			if (!string.IsNullOrEmpty(lastName))
			{
				dictionary.Add("lastName", lastName);
			}
			if (!string.IsNullOrEmpty(email))
			{
				dictionary.Add("email", email);
			}
			if (!string.IsNullOrEmpty(parentEmail))
			{
				dictionary.Add("parentEmail", parentEmail);
			}
			if (dateOfBirth.HasValue)
			{
				string value = dateOfBirth.Value.ToString("yyyy-MM-dd");
				dictionary.Add("dateOfBirth", value);
			}
			List<Disney.Mix.SDK.Internal.GuestControllerDomain.MarketingItem> marketing = marketingAgreements?.Select((KeyValuePair<IMarketingItem, bool> pair) => new Disney.Mix.SDK.Internal.GuestControllerDomain.MarketingItem
			{
				code = pair.Key.Id,
				subscribed = pair.Value
			}).ToList();
			List<string> legalAssertions = acceptedLegalDocuments?.Select((ILegalDocument doc) => doc.Id).ToList();
			SessionDocument sessionDocument = database.GetSessionDocument(swid);
			guestControllerClient.UpdateProfile(new UpdateProfileRequest
			{
				etag = sessionDocument.GuestControllerEtag,
				profile = dictionary,
				marketing = marketing,
				displayName = new RegisterDisplayName
				{
					proposedDisplayName = displayName
				},
				legalAssertions = legalAssertions
			}, delegate(GuestControllerResult<ProfileResponse> r)
			{
				HandleUpdateProfileResult(logger, database, swid, epochTime, r, profile, callback);
			});
		}
		catch (Exception arg)
		{
			logger.Critical("Unhandled exception: " + arg);
			callback(new UpdateProfileResult(success: false, null));
		}
	}

	private static void HandleUpdateProfileResult(AbstractLogger logger, IDatabase database, string swid, IEpochTime epochTime, GuestControllerResult<ProfileResponse> result, IInternalRegistrationProfile profile, Action<IUpdateProfileResult> callback)
	{
		try
		{
			if (!result.Success)
			{
				callback(new UpdateProfileResult(success: false, null));
			}
			else
			{
				IList<IInvalidProfileItemError> registerProfileItemErrors = GuestControllerErrorParser.GetRegisterProfileItemErrors(result.Response.error);
				if (result.Response.data == null)
				{
					callback(new UpdateProfileResult(success: false, registerProfileItemErrors));
				}
				else
				{
					ProfileData profileData = result.Response.data;
					if (profileData.displayName != null)
					{
						database.UpdateSessionDocument(swid, delegate(SessionDocument doc)
						{
							doc.DisplayNameText = profileData.displayName.displayName;
							doc.ProposedDisplayName = profileData.displayName.proposedDisplayName;
							doc.ProposedDisplayNameStatus = profileData.displayName.proposedStatus;
							doc.FirstName = profileData.profile.firstName;
							doc.AccountStatus = profileData.profile.status;
							doc.LastProfileRefreshTime = epochTime.Seconds;
						});
					}
					profile.Update(profileData.profile, profileData.displayName, profileData.marketing);
					callback(new UpdateProfileResult(success: true, registerProfileItemErrors));
				}
			}
		}
		catch (Exception arg)
		{
			logger.Critical("Unhandled exception: " + arg);
			callback(new UpdateProfileResult(success: false, null));
		}
	}
}
