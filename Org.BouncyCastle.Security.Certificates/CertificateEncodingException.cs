// CertificateEncodingException
using Org.BouncyCastle.Security.Certificates;
using System;

[Serializable]
public class CertificateEncodingException : CertificateException
{
	public CertificateEncodingException()
	{
	}

	public CertificateEncodingException(string msg)
		: base(msg)
	{
	}

	public CertificateEncodingException(string msg, Exception e)
		: base(msg, e)
	{
	}
}
