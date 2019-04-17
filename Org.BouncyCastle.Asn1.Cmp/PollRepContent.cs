// PollRepContent
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Utilities;
using System;

public class PollRepContent : Asn1Encodable
{
	private readonly DerInteger certReqId;

	private readonly DerInteger checkAfter;

	private readonly PkiFreeText reason;

	public virtual DerInteger CertReqID => certReqId;

	public virtual DerInteger CheckAfter => checkAfter;

	public virtual PkiFreeText Reason => reason;

	private PollRepContent(Asn1Sequence seq)
	{
		certReqId = DerInteger.GetInstance(seq[0]);
		checkAfter = DerInteger.GetInstance(seq[1]);
		if (seq.Count > 2)
		{
			reason = PkiFreeText.GetInstance(seq[2]);
		}
	}

	public static PollRepContent GetInstance(object obj)
	{
		if (obj is PollRepContent)
		{
			return (PollRepContent)obj;
		}
		if (obj is Asn1Sequence)
		{
			return new PollRepContent((Asn1Sequence)obj);
		}
		throw new ArgumentException("Invalid object: " + Platform.GetTypeName(obj), "obj");
	}

	public override Asn1Object ToAsn1Object()
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(certReqId, checkAfter);
		asn1EncodableVector.AddOptional(reason);
		return new DerSequence(asn1EncodableVector);
	}
}
