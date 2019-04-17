// PkixNameConstraintValidatorException
using System;

[Serializable]
public class PkixNameConstraintValidatorException : Exception
{
	public PkixNameConstraintValidatorException(string msg)
		: base(msg)
	{
	}
}
