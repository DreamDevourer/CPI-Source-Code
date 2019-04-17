// GlvEndomorphism
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC.Endo;

public interface GlvEndomorphism : ECEndomorphism
{
	BigInteger[] DecomposeScalar(BigInteger k);
}
