// MinSizeUpdater
using ClubPenguin.UI;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LayoutGroup))]
public class MinSizeUpdater : AbstractMinSizeUpdater
{
	protected override ILayoutElement getTargetLayoutElement()
	{
		return GetComponent<LayoutGroup>();
	}
}
