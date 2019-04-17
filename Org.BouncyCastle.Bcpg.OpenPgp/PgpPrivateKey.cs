// PgpPrivateKey
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Crypto;
using System;

public class PgpPrivateKey
{
	private readonly long keyID;

	private readonly PublicKeyPacket publicKeyPacket;

	private readonly AsymmetricKeyParameter privateKey;

	public long KeyId => keyID;

	public PublicKeyPacket PublicKeyPacket => publicKeyPacket;

	public AsymmetricKeyParameter Key => privateKey;

	public PgpPrivateKey(long keyID, PublicKeyPacket publicKeyPacket, AsymmetricKeyParameter privateKey)
	{
		if (!privateKey.IsPrivate)
		{
			throw new ArgumentException("Expected a private key", "privateKey");
		}
		this.keyID = keyID;
		this.publicKeyPacket = publicKeyPacket;
		this.privateKey = privateKey;
	}
}
