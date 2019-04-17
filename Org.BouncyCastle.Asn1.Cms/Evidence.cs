// Evidence
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Utilities;
using System;

public class Evidence : Asn1Encodable, IAsn1Choice
{
	private TimeStampTokenEvidence tstEvidence;

	public virtual TimeStampTokenEvidence TstEvidence => tstEvidence;

	public Evidence(TimeStampTokenEvidence tstEvidence)
	{
		this.tstEvidence = tstEvidence;
	}

	private Evidence(Asn1TaggedObject tagged)
	{
		if (tagged.TagNo == 0)
		{
			tstEvidence = TimeStampTokenEvidence.GetInstance(tagged, isExplicit: false);
		}
	}

	public static Evidence GetInstance(object obj)
	{
		if (obj is Evidence)
		{
			return (Evidence)obj;
		}
		if (obj is Asn1TaggedObject)
		{
			return new Evidence(Asn1TaggedObject.GetInstance(obj));
		}
		throw new ArgumentException("Unknown object in GetInstance: " + Platform.GetTypeName(obj), "obj");
	}

	public override Asn1Object ToAsn1Object()
	{
		if (tstEvidence != null)
		{
			return new DerTaggedObject(explicitly: false, 0, tstEvidence);
		}
		return null;
	}
}
