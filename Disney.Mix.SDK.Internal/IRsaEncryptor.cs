// IRsaEncryptor
using System.Security.Cryptography;

public interface IRsaEncryptor
{
	RSAParameters GenerateKeypair();

	byte[] Encrypt(byte[] plaintext, RSAParameters publicKey);

	byte[] Decrypt(byte[] ciphertext, RSAParameters privateKey);
}
