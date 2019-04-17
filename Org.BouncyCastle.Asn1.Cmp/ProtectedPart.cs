// ProtectedPart
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Utilities;
using System;

public class ProtectedPart : Asn1Encodable
{
	private readonly PkiHeader header;

	private readonly PkiBody body;

	public virtual PkiHeader Header => header;

	public virtual PkiBody Body => body;

	private ProtectedPart(Asn1Sequence seq)
	{
		header = PkiHeader.GetInstance(seq[0]);
		body = PkiBody.GetInstance(seq[1]);
	}

	public static ProtectedPart GetInstance(object obj)
	{
		if (obj is ProtectedPart)
		{
			return (ProtectedPart)obj;
		}
		if (obj is Asn1Sequence)
		{
			return new ProtectedPart((Asn1Sequence)obj);
		}
		throw new ArgumentException("Invalid object: " + Platform.GetTypeName(obj), "obj");
	}

	public ProtectedPart(PkiHeader header, PkiBody body)
	{
		this.header = header;
		this.body = body;
	}

	public override Asn1Object ToAsn1Object()
	{
		return new DerSequence(header, body);
	}
}
