using System;
using System.Runtime.InteropServices;

namespace ClubPenguin.Accessibility
{
	public static class AccessibilityEvents
	{
		public struct AccessibilityScaleUpdated
		{
			public readonly float Scale;

			public AccessibilityScaleUpdated(float scale)
			{
				this.Scale = scale;
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct AccessibilityScaleModifierRemoved
		{
		}
	}
}