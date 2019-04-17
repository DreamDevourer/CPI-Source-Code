// LoginCorruptionDetectedResult
using Disney.Mix.SDK;

internal class LoginCorruptionDetectedResult : ILoginCorruptionDetectedResult, ILoginResult
{
	public bool Success
	{
		get;
		private set;
	}

	public ISession Session
	{
		get;
		private set;
	}
}
