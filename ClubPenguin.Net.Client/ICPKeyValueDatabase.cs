// ICPKeyValueDatabase
using System.Security.Cryptography;

public interface ICPKeyValueDatabase
{
	RSAParameters? GetRsaParameters();

	void SetRsaParameters(RSAParameters rsaParameters);
}
