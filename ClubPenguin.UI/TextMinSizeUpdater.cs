// TextMinSizeUpdater
using ClubPenguin.UI;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextMinSizeUpdater : AbstractMinSizeUpdater
{
	protected override ILayoutElement getTargetLayoutElement()
	{
		return GetComponent<Text>();
	}
}
