// PartySub
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartySub : MonoBehaviour
{
	public List<GameObject> DiscoFxs = new List<GameObject>();

	public List<GameObject> SceneObjs = new List<GameObject>();

	public GameObject InteractTrigger;

	public Animator DiscoBallAnim;

	public Animator HandleAnim;

	public float DiscoTimeout;

	private List<GameObject> DiscoFxInstances = new List<GameObject>();

	public void OnActionGraphActivation()
	{
		StartCoroutine(StartDiscoFX());
	}

	private IEnumerator StartDiscoFX()
	{
		InteractTrigger.SetActive(value: false);
		foreach (GameObject sceneObj in SceneObjs)
		{
			if (sceneObj != null)
			{
				sceneObj.SetActive(value: false);
			}
		}
		foreach (GameObject discoFx in DiscoFxs)
		{
			if (discoFx != null)
			{
				GameObject gameObject = Object.Instantiate(discoFx);
				gameObject.transform.SetParent(base.transform, worldPositionStays: false);
				DiscoFxInstances.Add(gameObject);
			}
		}
		DiscoBallAnim.SetTrigger("Drop");
		HandleAnim.SetTrigger("Pull");
		yield return new WaitForSeconds(DiscoTimeout);
		DiscoBallAnim.SetTrigger("Raise");
		yield return new WaitForSeconds(1.5f);
		foreach (GameObject sceneObj2 in SceneObjs)
		{
			sceneObj2.SetActive(value: true);
		}
		foreach (GameObject discoFxInstance in DiscoFxInstances)
		{
			Object.Destroy(discoFxInstance);
		}
		InteractTrigger.SetActive(value: true);
	}
}
