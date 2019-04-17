// InventoryDragEvents
using ClubPenguin.ClothingDesigner;
using System.Runtime.InteropServices;

public static class InventoryDragEvents
{
	public struct DragInventoryButton
	{
		public readonly CustomizerGestureModel GestureModel;

		public DragInventoryButton(CustomizerGestureModel gestureModel)
		{
			GestureModel = gestureModel;
		}
	}

	public struct RotatePenguinPreview
	{
		public readonly CustomizerGestureModel GestureModel;

		public RotatePenguinPreview(CustomizerGestureModel gestureModel)
		{
			GestureModel = gestureModel;
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct GestureComplete
	{
	}
}
