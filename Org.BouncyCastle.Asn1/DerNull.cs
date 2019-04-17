// DerNull
using Org.BouncyCastle.Asn1;
using System;

public class DerNull : Asn1Null
{
	public static readonly DerNull Instance = new DerNull(0);

	private byte[] zeroBytes = new byte[0];

	[Obsolete("Use static Instance object")]
	public DerNull()
	{
	}

	protected internal DerNull(int dummy)
	{
	}

	internal override void Encode(DerOutputStream derOut)
	{
		derOut.WriteEncoded(5, zeroBytes);
	}

	protected override bool Asn1Equals(Asn1Object asn1Object)
	{
		return asn1Object is DerNull;
	}

	protected override int Asn1GetHashCode()
	{
		return -1;
	}
}
