// DynamicLightingMaterialProperties
using ClubPenguin.DCE;
using System;
using UnityEngine;

[Serializable]
public class DynamicLightingMaterialProperties : BaseMaterialProperties
{
	public DynamicLightingMaterialProperties(Material mat = null)
	{
		if (!(mat != null))
		{
		}
	}

	public override void Apply(Material mat)
	{
	}

	public override string ToString()
	{
		return $"[DynamicLightingMaterialProperties : ";
	}
}
