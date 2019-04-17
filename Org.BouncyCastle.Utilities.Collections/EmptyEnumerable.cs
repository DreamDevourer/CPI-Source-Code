// EmptyEnumerable
using Org.BouncyCastle.Utilities.Collections;
using System.Collections;

public sealed class EmptyEnumerable : IEnumerable
{
	public static readonly IEnumerable Instance = new EmptyEnumerable();

	private EmptyEnumerable()
	{
	}

	public IEnumerator GetEnumerator()
	{
		return EmptyEnumerator.Instance;
	}
}
