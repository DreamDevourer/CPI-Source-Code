// GroupsCollectible
using System;
using System.Collections.Generic;
using UnityEngine;

public class GroupsCollectible : MonoBehaviour
{
	private Dictionary<string, GameObject> groupObjects = new Dictionary<string, GameObject>();

	private List<string> groupNames = new List<string>();

	private void Awake()
	{
		foreach (Transform item in base.transform)
		{
			GameObject gameObject = item.transform.gameObject;
			if (gameObject.activeSelf)
			{
				if (groupObjects.ContainsKey(gameObject.name))
				{
					return;
				}
				groupObjects.Add(gameObject.name, gameObject);
				groupNames.Add(gameObject.name);
				gameObject.SetActive(value: false);
			}
		}
		int dayOfYear = DateTime.Today.DayOfYear;
		int index = dayOfYear % groupObjects.Count;
		groupObjects[groupNames[index]].SetActive(value: true);
	}
}
