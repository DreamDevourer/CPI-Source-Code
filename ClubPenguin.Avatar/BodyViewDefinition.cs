using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	[Serializable]
	public class BodyViewDefinition : BaseViewDefinition
	{
		public SkinnedMeshDefinition SkinnedMesh;

		public BodyMaterialProperties BodyMaterial;

		public override void ApplyToViewPart(ViewPart partView)
		{
			partView.SetMeshDefinition(this.SkinnedMesh);
			partView.InitMaterialProps();
			partView.AddMaterialProps(this.BodyMaterial);
		}

		public override List<Object> InternalReferences()
		{
			List<Object> list = this.SkinnedMesh.InternalReferences();
			list.AddRange(this.BodyMaterial.InternalReferences());
			return list;
		}
	}
}