// PkiMessages
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Utilities;
using System;

public class PkiMessages : Asn1Encodable
{
	private Asn1Sequence content;

	private PkiMessages(Asn1Sequence seq)
	{
		content = seq;
	}

	public static PkiMessages GetInstance(object obj)
	{
		if (obj is PkiMessages)
		{
			return (PkiMessages)obj;
		}
		if (obj is Asn1Sequence)
		{
			return new PkiMessages((Asn1Sequence)obj);
		}
		throw new ArgumentException("Invalid object: " + Platform.GetTypeName(obj), "obj");
	}

	public PkiMessages(params PkiMessage[] msgs)
	{
		content = new DerSequence(msgs);
	}

	public virtual PkiMessage[] ToPkiMessageArray()
	{
		PkiMessage[] array = new PkiMessage[content.Count];
		for (int i = 0; i != array.Length; i++)
		{
			array[i] = PkiMessage.GetInstance(content[i]);
		}
		return array;
	}

	public override Asn1Object ToAsn1Object()
	{
		return content;
	}
}
