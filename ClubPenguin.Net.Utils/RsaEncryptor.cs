// RsaEncryptor
using System.Security.Cryptography;

public static class RsaEncryptor
{
	public static RSAParameters GenerateKeypair()
	{
		using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider())
		{
			return rSACryptoServiceProvider.ExportParameters(includePrivateParameters: true);
		}
	}

	public static byte[] Encrypt(byte[] plaintext, RSAParameters publicKey)
	{
		using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider())
		{
			rSACryptoServiceProvider.ImportParameters(publicKey);
			return rSACryptoServiceProvider.Encrypt(plaintext, fOAEP: false);
		}
	}

	public static byte[] Decrypt(byte[] ciphertext, RSAParameters privateKey)
	{
		using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider())
		{
			rSACryptoServiceProvider.ImportParameters(privateKey);
			return rSACryptoServiceProvider.Decrypt(ciphertext, fOAEP: false);
		}
	}
}
