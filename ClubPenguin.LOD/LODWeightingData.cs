// LODWeightingData
using UnityEngine;

public abstract class LODWeightingData : ScriptableObject
{
	public abstract void InstantiateRequest(GameObject entity);
}
