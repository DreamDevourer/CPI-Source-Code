// PCGetProductDetailsRequest
using System;

[Serializable]
public struct PCGetProductDetailsRequest
{
	public string DistributionChannelId;

	public string SourceIp;

	public string Language;

	public string DeviceType;

	public string SessionId;
}
