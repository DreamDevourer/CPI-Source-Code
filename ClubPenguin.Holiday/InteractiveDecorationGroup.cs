// InteractiveDecorationGroup
using ClubPenguin.Holiday;
using System;
using UnityEngine;

public class InteractiveDecorationGroup : InteractiveDecoration
{
	private bool areDecorationsVisible;

	public override void Start()
	{
		base.Start();
		if (DuringHidePhase())
		{
			GroupSetActive(isActive: false);
			areDecorationsVisible = false;
		}
		else
		{
			areDecorationsVisible = true;
		}
		GroupColorChange(isInitializing: true);
	}

	public override void OnColorChange()
	{
		base.OnColorChange();
		if (areDecorationsVisible)
		{
			GroupColorChange();
			return;
		}
		GroupSetActive(isActive: true);
		areDecorationsVisible = true;
	}

	public void GroupColorChange(bool isInitializing = false)
	{
		if (!isInitializing)
		{
			int num = (int)(CurrentColor + 1);
			if (num >= 6)
			{
				num = 1;
			}
			CurrentColor = (DecorationColor)num;
		}
		foreach (Transform item in base.transform)
		{
			if (!item.name.StartsWith("NonInt", StringComparison.OrdinalIgnoreCase))
			{
				Renderer component = item.GetComponent<Renderer>();
				if (component != null)
				{
					base.ChangeColor(component, CurrentColor);
				}
			}
		}
	}
}
