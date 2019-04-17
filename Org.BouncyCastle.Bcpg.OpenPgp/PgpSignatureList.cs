// PgpSignatureList
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;

public class PgpSignatureList : PgpObject
{
	private PgpSignature[] sigs;

	public PgpSignature this[int index]
	{
		get
		{
			return sigs[index];
		}
	}

	[Obsolete("Use 'Count' property instead")]
	public int Size
	{
		get
		{
			return sigs.Length;
		}
	}

	public int Count => sigs.Length;

	public bool IsEmpty => sigs.Length == 0;

	public PgpSignatureList(PgpSignature[] sigs)
	{
		this.sigs = (PgpSignature[])sigs.Clone();
	}

	public PgpSignatureList(PgpSignature sig)
	{
		sigs = new PgpSignature[1]
		{
			sig
		};
	}

	[Obsolete("Use 'object[index]' syntax instead")]
	public PgpSignature Get(int index)
	{
		return this[index];
	}
}
