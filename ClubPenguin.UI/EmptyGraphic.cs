// EmptyGraphic
using UnityEngine.UI;

public class EmptyGraphic : Graphic
{
	public bool lowPriorityTarget = false;

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
	}
}
