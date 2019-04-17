// RecipientID
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509.Store;

public class RecipientID : X509CertStoreSelector
{
	private byte[] keyIdentifier;

	public byte[] KeyIdentifier
	{
		get
		{
			return Arrays.Clone(keyIdentifier);
		}
		set
		{
			keyIdentifier = Arrays.Clone(value);
		}
	}

	public override int GetHashCode()
	{
		int num = Arrays.GetHashCode(keyIdentifier) ^ Arrays.GetHashCode(base.SubjectKeyIdentifier);
		BigInteger serialNumber = base.SerialNumber;
		if (serialNumber != null)
		{
			num ^= serialNumber.GetHashCode();
		}
		X509Name issuer = base.Issuer;
		if (issuer != null)
		{
			num ^= issuer.GetHashCode();
		}
		return num;
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		RecipientID recipientID = obj as RecipientID;
		if (recipientID == null)
		{
			return false;
		}
		if (Arrays.AreEqual(keyIdentifier, recipientID.keyIdentifier) && Arrays.AreEqual(base.SubjectKeyIdentifier, recipientID.SubjectKeyIdentifier) && object.Equals(base.SerialNumber, recipientID.SerialNumber))
		{
			return X509CertStoreSelector.IssuersMatch(base.Issuer, recipientID.Issuer);
		}
		return false;
	}
}
