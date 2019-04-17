// PgpMarker
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpMarker : PgpObject
{
	private readonly MarkerPacket p;

	public PgpMarker(BcpgInputStream bcpgIn)
	{
		p = (MarkerPacket)bcpgIn.ReadPacket();
	}
}
