// IBlockResult
public interface IBlockResult
{
	byte[] Collect();

	int Collect(byte[] destination, int offset);
}
