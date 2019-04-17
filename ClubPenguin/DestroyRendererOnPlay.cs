// DestroyRendererOnPlay
using UnityEngine;

public class DestroyRendererOnPlay : MonoBehaviour
{
	private void Awake()
	{
		Renderer component = base.gameObject.GetComponent<Renderer>();
		Object.Destroy(component);
	}
}
