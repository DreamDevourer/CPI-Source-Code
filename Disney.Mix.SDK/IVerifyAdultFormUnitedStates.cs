// IVerifyAdultFormUnitedStates
using Disney.Mix.SDK;
using System;

public interface IVerifyAdultFormUnitedStates : IVerifyAdultForm
{
	string AddressLine1
	{
		get;
	}

	string PostalCode
	{
		get;
	}

	DateTime DateOfBirth
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

	string Ssn
	{
		get;
	}
}
