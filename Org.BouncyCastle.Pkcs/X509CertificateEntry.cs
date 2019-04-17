// X509CertificateEntry
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;
using System;
using System.Collections;

public class X509CertificateEntry : Pkcs12Entry
{
	private readonly X509Certificate cert;

	public X509Certificate Certificate => cert;

	public X509CertificateEntry(X509Certificate cert)
		: base(Platform.CreateHashtable())
	{
		this.cert = cert;
	}

	[Obsolete]
	public X509CertificateEntry(X509Certificate cert, Hashtable attributes)
		: base(attributes)
	{
		this.cert = cert;
	}

	public X509CertificateEntry(X509Certificate cert, IDictionary attributes)
		: base(attributes)
	{
		this.cert = cert;
	}

	public override bool Equals(object obj)
	{
		X509CertificateEntry x509CertificateEntry = obj as X509CertificateEntry;
		if (x509CertificateEntry == null)
		{
			return false;
		}
		return cert.Equals(x509CertificateEntry.cert);
	}

	public override int GetHashCode()
	{
		return ~cert.GetHashCode();
	}
}
