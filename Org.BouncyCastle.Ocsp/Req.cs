// Req
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Ocsp;
using Org.BouncyCastle.X509;

public class Req : X509ExtensionBase
{
	private Request req;

	public X509Extensions SingleRequestExtensions => req.SingleRequestExtensions;

	public Req(Request req)
	{
		this.req = req;
	}

	public CertificateID GetCertID()
	{
		return new CertificateID(req.ReqCert);
	}

	protected override X509Extensions GetX509Extensions()
	{
		return SingleRequestExtensions;
	}
}
