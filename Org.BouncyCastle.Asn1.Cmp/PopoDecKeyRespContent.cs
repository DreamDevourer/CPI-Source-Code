// PopoDecKeyRespContent
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Utilities;
using System;

public class PopoDecKeyRespContent : Asn1Encodable
{
	private readonly Asn1Sequence content;

	private PopoDecKeyRespContent(Asn1Sequence seq)
	{
		content = seq;
	}

	public static PopoDecKeyRespContent GetInstance(object obj)
	{
		if (obj is PopoDecKeyRespContent)
		{
			return (PopoDecKeyRespContent)obj;
		}
		if (obj is Asn1Sequence)
		{
			return new PopoDecKeyRespContent((Asn1Sequence)obj);
		}
		throw new ArgumentException("Invalid object: " + Platform.GetTypeName(obj), "obj");
	}

	public virtual DerInteger[] ToDerIntegerArray()
	{
		DerInteger[] array = new DerInteger[content.Count];
		for (int i = 0; i != array.Length; i++)
		{
			array[i] = DerInteger.GetInstance(content[i]);
		}
		return array;
	}

	public override Asn1Object ToAsn1Object()
	{
		return content;
	}
}
