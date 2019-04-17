// LdsVersionInfo
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Icao;
using System;

public class LdsVersionInfo : Asn1Encodable
{
	private DerPrintableString ldsVersion;

	private DerPrintableString unicodeVersion;

	public LdsVersionInfo(string ldsVersion, string unicodeVersion)
	{
		this.ldsVersion = new DerPrintableString(ldsVersion);
		this.unicodeVersion = new DerPrintableString(unicodeVersion);
	}

	private LdsVersionInfo(Asn1Sequence seq)
	{
		if (seq.Count != 2)
		{
			throw new ArgumentException("sequence wrong size for LDSVersionInfo", "seq");
		}
		ldsVersion = DerPrintableString.GetInstance(seq[0]);
		unicodeVersion = DerPrintableString.GetInstance(seq[1]);
	}

	public static LdsVersionInfo GetInstance(object obj)
	{
		if (obj is LdsVersionInfo)
		{
			return (LdsVersionInfo)obj;
		}
		if (obj != null)
		{
			return new LdsVersionInfo(Asn1Sequence.GetInstance(obj));
		}
		return null;
	}

	public virtual string GetLdsVersion()
	{
		return ldsVersion.GetString();
	}

	public virtual string GetUnicodeVersion()
	{
		return unicodeVersion.GetString();
	}

	public override Asn1Object ToAsn1Object()
	{
		return new DerSequence(ldsVersion, unicodeVersion);
	}
}
