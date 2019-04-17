// RsaEncryptor
using Disney.Mix.SDK.Internal;
using System.Security.Cryptography;

public class RsaEncryptor : IRsaEncryptor
{
	public RSAParameters GenerateKeypair()
	{
		using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider())
		{
			return rSACryptoServiceProvider.ExportParameters(includePrivateParameters: true);
		}
	}

	public byte[] Encrypt(byte[] plaintext, RSAParameters publicKey)
	{
		using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider())
		{
			rSACryptoServiceProvider.ImportParameters(publicKey);
			return rSACryptoServiceProvider.Encrypt(plaintext, fOAEP: false);
		}
	}

	public byte[] Decrypt(byte[] ciphertext, RSAParameters privateKey)
	{
		using (RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider())
		{
			rSACryptoServiceProvider.ImportParameters(privateKey);
			return rSACryptoServiceProvider.Decrypt(ciphertext, fOAEP: false);
		}
	}
}
