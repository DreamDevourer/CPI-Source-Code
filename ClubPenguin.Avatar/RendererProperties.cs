using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace ClubPenguin.Avatar
{
	[Serializable]
	public class RendererProperties
	{
		public bool ReceiveShadows = false;

		public ReflectionProbeUsage ReflectionProbeUsage = ReflectionProbeUsage.Off;

		public ShadowCastingMode ShadowCastingMode = ShadowCastingMode.Off;

		public bool UseLightProbes = false;

		public RendererProperties(Renderer renderer)
		{
			this.ReceiveShadows = renderer.receiveShadows;
			this.ReflectionProbeUsage = renderer.reflectionProbeUsage;
			this.ShadowCastingMode = renderer.shadowCastingMode;
			this.UseLightProbes = (renderer.lightProbeUsage == LightProbeUsage.BlendProbes);
		}

		public void Apply(Renderer renderer)
		{
			renderer.receiveShadows = this.ReceiveShadows;
			renderer.reflectionProbeUsage = this.ReflectionProbeUsage;
			renderer.shadowCastingMode = this.ShadowCastingMode;
			renderer.lightProbeUsage = (this.UseLightProbes ? LightProbeUsage.BlendProbes : LightProbeUsage.Off);
		}
	}
}