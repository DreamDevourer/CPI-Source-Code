// PCSessionStartRequest
using System;

[Serializable]
public struct PCSessionStartRequest
{
	public string DistributionChannelId;

	public string SourceIp;

	public string Language;

	public string DeviceType;
}
