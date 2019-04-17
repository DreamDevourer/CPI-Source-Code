// JigsawForeground
using UnityEngine;

public class JigsawForeground : MonoBehaviour
{
	public GameObject[] ActivateList;

	public GameObject[] DeactivateList;

	public void OnPieceLocked()
	{
		int num = ActivateList.Length;
		for (int i = 0; i < num; i++)
		{
			ActivateList[i].SetActive(value: true);
		}
		num = DeactivateList.Length;
		for (int i = 0; i < num; i++)
		{
			DeactivateList[i].SetActive(value: false);
		}
	}
}
