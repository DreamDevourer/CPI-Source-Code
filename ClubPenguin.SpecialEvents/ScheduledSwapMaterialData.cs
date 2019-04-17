// ScheduledSwapMaterialData
using Disney.Kelowna.Common;
using System;
using UnityEngine;

[Serializable]
public class ScheduledSwapMaterialData
{
	public GameObject SwapTarget;

	public MaterialContentKey SwapMaterialKey;

	public bool DestroyTexture = false;
}
