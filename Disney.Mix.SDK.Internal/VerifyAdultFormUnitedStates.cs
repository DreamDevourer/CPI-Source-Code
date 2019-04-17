// VerifyAdultFormUnitedStates
using Disney.Mix.SDK;
using System;

public class VerifyAdultFormUnitedStates : IVerifyAdultFormUnitedStates, IVerifyAdultForm
{
	public string AddressLine1 => null;

	public string PostalCode => null;

	public DateTime DateOfBirth => default(DateTime);

	public string FirstName => null;

	public string LastName => null;

	public string Ssn => null;
}
