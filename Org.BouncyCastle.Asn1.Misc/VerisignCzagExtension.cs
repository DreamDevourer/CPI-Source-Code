// VerisignCzagExtension
using Org.BouncyCastle.Asn1;

public class VerisignCzagExtension : DerIA5String
{
	public VerisignCzagExtension(DerIA5String str)
		: base(str.GetString())
	{
	}

	public override string ToString()
	{
		return "VerisignCzagExtension: " + GetString();
	}
}
