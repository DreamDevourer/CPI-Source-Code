// IdHasher
using System;
using System.Security.Cryptography;
using System.Text;

public static class IdHasher
{
	private static readonly HashAlgorithm hashAlgorithm = MD5.Create();

	public static string HashId(string id)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(id);
		byte[] inArray = hashAlgorithm.ComputeHash(bytes);
		return Convert.ToBase64String(inArray);
	}
}
