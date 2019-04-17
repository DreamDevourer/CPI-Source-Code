// UITrayRoot
using ClubPenguin;
using UnityEngine;

public class UITrayRoot : MonoBehaviour
{
	private void Awake()
	{
		SceneRefs.SetUiTrayRoot(base.gameObject);
	}
}
