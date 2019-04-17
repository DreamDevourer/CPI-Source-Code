using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	public class EquipmentViewDefinition : BodyViewDefinition
	{
		public EquipmentMaterialProperties EquipmentMaterial;

		public DecalMaterialProperties[] DecalMaterials;

		public override void ApplyToViewPart(ViewPart partView)
		{
			base.ApplyToViewPart(partView);
			partView.SetDefaultProps(this.DecalMaterials);
			partView.AddMaterialProps(this.EquipmentMaterial);
		}

		public override List<Object> InternalReferences()
		{
			List<Object> list = base.InternalReferences();
			list.AddRange(this.EquipmentMaterial.InternalReferences());
			DecalMaterialProperties[] decalMaterials = this.DecalMaterials;
			for (int i = 0; i < decalMaterials.Length; i++)
			{
				DecalMaterialProperties decalMaterialProperties = decalMaterials[i];
				list.AddRange(decalMaterialProperties.InternalReferences());
			}
			return list;
		}
	}
}