// AbstractPooledLayoutElement
using UnityEngine;

public abstract class AbstractPooledLayoutElement : MonoBehaviour
{
	public abstract float GetPreferredWidth(int elementCount, bool ignoreRestrictions = false);

	public abstract float GetPreferredHeight(int elementCount);
}
