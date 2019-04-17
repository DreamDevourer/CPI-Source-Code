// DceController
using ClubPenguin.DCE;
using UnityEngine;

[DisallowMultipleComponent]
public class DceController : MonoBehaviour
{
	public DceModel Model;

	public virtual void Awake()
	{
		if (Model == null)
		{
			Model = GetComponent<DceModel>();
		}
	}
}
