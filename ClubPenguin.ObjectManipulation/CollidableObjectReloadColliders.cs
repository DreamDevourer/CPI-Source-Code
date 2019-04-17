// CollidableObjectReloadColliders
using ClubPenguin.ObjectManipulation;
using UnityEngine;

public class CollidableObjectReloadColliders : MonoBehaviour
{
	public void OnEnable()
	{
		CollidableObject component = GetComponent<CollidableObject>();
		if (component != null)
		{
			component.ReloadColliders();
		}
		base.enabled = false;
	}
}
