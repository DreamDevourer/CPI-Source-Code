// GetGeolocationResult
using Disney.Mix.SDK;

public class GetGeolocationResult : IGetGeolocationResult
{
	public bool Success
	{
		get;
		private set;
	}

	public string CountryCode
	{
		get;
		private set;
	}

	public GetGeolocationResult(bool success, string countryCode)
	{
		Success = success;
		CountryCode = countryCode;
	}
}
