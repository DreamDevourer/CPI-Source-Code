// DestroyOnDelay
using UnityEngine;

public class DestroyOnDelay : MonoBehaviour
{
	public float Delay = 1f;

	private void Start()
	{
		Object.Destroy(base.gameObject, Delay);
	}
}
