// OfflineRegistrationProfile
using ClubPenguin.Mix;
using ClubPenguin.Net.Client;
using ClubPenguin.Net.Offline;
using Disney.Mix.SDK;
using System;
using System.Collections.Generic;

internal class OfflineRegistrationProfile : IRegistrationProfile
{
	private RegistrationProfile data;

	public AccountStatus AccountStatus => AccountStatus.Active;

	public bool AgeBandAssumed
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public string AgeBandKey
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public string CountryCode
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public DateTime? DateOfBirth
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public string DisplayName
	{
		get
		{
			return data.displayName;
		}
		set
		{
			data.displayName = value;
		}
	}

	public DateTime? DisplayNameModeratedStatusDate
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public DisplayNameProposedStatus DisplayNameProposedStatus => DisplayNameProposedStatus.Accepted;

	public string Email => null;

	public bool EmailVerified
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public string FirstName
	{
		get
		{
			return data.firstName;
		}
		set
		{
			data.firstName = value;
		}
	}

	public bool IsAdultVerified
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public string LanguagePreference
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public string LastName
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public DateTime LastRefreshTime
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public IEnumerable<KeyValuePair<string, bool>> MarketingItems
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public string MiddleName
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public string ParentEmail
	{
		get
		{
			return data.parentEmail;
		}
		set
		{
			data.parentEmail = value;
		}
	}

	public bool ParentEmailVerified
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public string ProposedDisplayName => data.displayName;

	public string Username
	{
		get
		{
			return data.userName;
		}
		set
		{
			data.userName = value;
		}
	}

	public string Password
	{
		set
		{
			data.password = value;
		}
	}

	public string Id => data.Id();

	private OfflineRegistrationProfile()
	{
	}

	public static OfflineRegistrationProfile Load(string username)
	{
		OfflineRegistrationProfile offlineRegistrationProfile = new OfflineRegistrationProfile();
		offlineRegistrationProfile.data = RegistrationProfile.Load(username);
		return offlineRegistrationProfile;
	}

	public void Save()
	{
		OfflineDatabase.Write(data, data.Id());
	}
}
