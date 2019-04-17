// PkiConfirmContent
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Utilities;
using System;

public class PkiConfirmContent : Asn1Encodable
{
	public static PkiConfirmContent GetInstance(object obj)
	{
		if (obj is PkiConfirmContent)
		{
			return (PkiConfirmContent)obj;
		}
		if (obj is Asn1Null)
		{
			return new PkiConfirmContent();
		}
		throw new ArgumentException("Invalid object: " + Platform.GetTypeName(obj), "obj");
	}

	public override Asn1Object ToAsn1Object()
	{
		return DerNull.Instance;
	}
}
