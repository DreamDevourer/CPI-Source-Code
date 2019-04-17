// OCSPRespGenerator
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Ocsp;
using System;

public class OCSPRespGenerator
{
	public const int Successful = 0;

	public const int MalformedRequest = 1;

	public const int InternalError = 2;

	public const int TryLater = 3;

	public const int SigRequired = 5;

	public const int Unauthorized = 6;

	public OcspResp Generate(int status, object response)
	{
		if (response == null)
		{
			return new OcspResp(new OcspResponse(new OcspResponseStatus(status), null));
		}
		if (response is BasicOcspResp)
		{
			BasicOcspResp basicOcspResp = (BasicOcspResp)response;
			Asn1OctetString response2;
			try
			{
				response2 = new DerOctetString(basicOcspResp.GetEncoded());
			}
			catch (Exception e)
			{
				throw new OcspException("can't encode object.", e);
			}
			ResponseBytes responseBytes = new ResponseBytes(OcspObjectIdentifiers.PkixOcspBasic, response2);
			return new OcspResp(new OcspResponse(new OcspResponseStatus(status), responseBytes));
		}
		throw new OcspException("unknown response object");
	}
}
