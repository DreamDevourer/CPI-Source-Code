// AccountBannedEventArgs
using Disney.Mix.SDK;
using Disney.Mix.SDK.Internal;
using Disney.Mix.SDK.Internal.MixDomain;
using System;

public class AccountBannedEventArgs : AbstractAccountBannedEventArgs
{
	public AccountBannedEventArgs(AbstractLogger logger, string reasonText)
	{
		if (!string.IsNullOrEmpty(reasonText))
		{
			try
			{
				BanResponse banResponse = JsonParser.FromJson<BanResponse>(reasonText);
				if (banResponse.Type.ToLower().Contains("temp"))
				{
					base.ExpirationDate = DateTime.Parse(banResponse.ExpirationDate);
				}
			}
			catch (Exception ex)
			{
				logger.Critical("Error parsing response body: " + ex + "\n" + reasonText);
			}
		}
	}
}
