// PemWriter
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.IO.Pem;
using System.IO;

public class PemWriter : Org.BouncyCastle.Utilities.IO.Pem.PemWriter
{
	public PemWriter(TextWriter writer)
		: base(writer)
	{
	}

	public void WriteObject(object obj)
	{
		try
		{
			base.WriteObject((PemObjectGenerator)new MiscPemGenerator(obj));
		}
		catch (PemGenerationException ex)
		{
			if (ex.InnerException is IOException)
			{
				throw (IOException)ex.InnerException;
			}
			throw ex;
		}
	}

	public void WriteObject(object obj, string algorithm, char[] password, SecureRandom random)
	{
		base.WriteObject((PemObjectGenerator)new MiscPemGenerator(obj, algorithm, password, random));
	}
}
