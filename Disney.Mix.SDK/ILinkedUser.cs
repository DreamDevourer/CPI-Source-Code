// ILinkedUser
using Disney.Mix.SDK;
using System;

public interface ILinkedUser
{
	string Username
	{
		get;
	}

	string FirstName
	{
		get;
	}

	string LastName
	{
		get;
	}

	IDisplayName DisplayName
	{
		get;
	}

	string Email
	{
		get;
	}

	string ParentEmail
	{
		get;
	}

	AgeBandType AgeBand
	{
		get;
	}

	DateTime? DateOfBirth
	{
		get;
	}
}
