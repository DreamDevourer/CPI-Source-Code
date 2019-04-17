// SceneLayoutIdComponent
using UnityEngine;

public class SceneLayoutIdComponent : MonoBehaviour
{
	[SerializeField]
	protected long layoutId;

	public long LayoutId => layoutId;
}
