// TlsPskIdentityManager
public interface TlsPskIdentityManager
{
	byte[] GetHint();

	byte[] GetPsk(byte[] identity);
}
