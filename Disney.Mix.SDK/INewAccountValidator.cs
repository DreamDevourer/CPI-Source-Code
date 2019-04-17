// INewAccountValidator
using Disney.Mix.SDK;
using System;

public interface INewAccountValidator
{
	void ValidateAdultAccount(string email, string password, Action<IValidateNewAccountResult> callback);

	void ValidateChildAccount(string username, string password, Action<IValidateNewAccountResult> callback);
}
