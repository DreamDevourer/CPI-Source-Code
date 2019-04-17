// UIChatRoot
using ClubPenguin;
using UnityEngine;

public class UIChatRoot : MonoBehaviour
{
	private void Awake()
	{
		SceneRefs.SetUiChatRoot(base.gameObject);
	}
}
