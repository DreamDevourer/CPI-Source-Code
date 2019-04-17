// PkixCertPathBuilderException
using Org.BouncyCastle.Security;
using System;

[Serializable]
public class PkixCertPathBuilderException : GeneralSecurityException
{
	public PkixCertPathBuilderException()
	{
	}

	public PkixCertPathBuilderException(string message)
		: base(message)
	{
	}

	public PkixCertPathBuilderException(string message, Exception exception)
		: base(message, exception)
	{
	}
}
