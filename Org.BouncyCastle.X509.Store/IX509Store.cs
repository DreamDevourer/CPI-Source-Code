// IX509Store
using Org.BouncyCastle.X509.Store;
using System.Collections;

public interface IX509Store
{
	ICollection GetMatches(IX509Selector selector);
}
