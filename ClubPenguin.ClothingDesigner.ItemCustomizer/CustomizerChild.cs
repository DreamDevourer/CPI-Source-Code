// CustomizerChild
using ClubPenguin.Avatar;
using System;
using UnityEngine;

public class CustomizerChild : MonoBehaviour
{
	private AvatarViewDistinctChild avatarViewDistinctChild;

	private SkinnedMeshRenderer smr;

	private MeshCollider meshCollider;

	public int SlotIndex => avatarViewDistinctChild.SlotIndex;

	public Material SharedMaterial => smr.sharedMaterial;

	public bool HasEquipment => avatarViewDistinctChild.Model[avatarViewDistinctChild.SlotIndex, avatarViewDistinctChild.PartIndex].Equipment != null;

	public event Action<Renderer, DecalMaterialProperties[]> EquipmentSet;

	private void Awake()
	{
		avatarViewDistinctChild = GetComponent<AvatarViewDistinctChild>();
	}

	private void OnEnable()
	{
		avatarViewDistinctChild.OnReady += avatarBaseAsync_OnReady;
	}

	private void OnDisable()
	{
		avatarViewDistinctChild.OnReady -= avatarBaseAsync_OnReady;
	}

	private void avatarBaseAsync_OnReady(AvatarBaseAsync avatarBase)
	{
		if (HasEquipment)
		{
			smr = GetComponent<SkinnedMeshRenderer>();
			smr.updateWhenOffscreen = true;
			if (meshCollider == null)
			{
				meshCollider = base.gameObject.AddComponent<MeshCollider>();
			}
			meshCollider.sharedMesh = smr.sharedMesh;
			meshCollider.enabled = true;
			if (this.EquipmentSet != null)
			{
				this.EquipmentSet(smr, avatarViewDistinctChild.ViewPart.GetDefaultDecalProps());
			}
		}
	}

	public void Reset()
	{
		if (meshCollider != null)
		{
			meshCollider.enabled = false;
		}
	}
}
