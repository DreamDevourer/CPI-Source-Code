// DynamicMulticoloredListElement
using ClubPenguin.UI;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DynamicMulticoloredListElement : MonoBehaviour
{
	public void SetIndex(int index)
	{
		MulticoloredList componentInParent = GetComponentInParent<MulticoloredList>();
		if (componentInParent != null)
		{
			Image component = GetComponent<Image>();
			component.color = componentInParent.GetColorForIndex(index);
		}
	}
}
