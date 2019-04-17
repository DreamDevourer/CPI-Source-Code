// ECEndomorphism
using Org.BouncyCastle.Math.EC;

public interface ECEndomorphism
{
	ECPointMap PointMap
	{
		get;
	}

	bool HasEfficientPointMap
	{
		get;
	}
}
