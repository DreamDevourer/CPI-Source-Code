// GameObjectSelector
using Disney.LaunchPadFramework;
using UnityEngine;

public class GameObjectSelector : MonoBehaviour
{
	public GameObject[] GameObjects;

	public int DefaultIndex = 0;

	private int currentSelectedIndex;

	public GameObject SelectedObject => GameObjects[currentSelectedIndex];

	private void Awake()
	{
		SelectGameObject(DefaultIndex);
	}

	public void SelectGameObject(int index)
	{
		if (GameObjects != null && index < GameObjects.Length)
		{
			for (int i = 0; i < GameObjects.Length; i++)
			{
				if (i != index)
				{
					GameObjects[i].SetActive(value: false);
				}
				else
				{
					GameObjects[i].SetActive(value: true);
				}
			}
			currentSelectedIndex = index;
		}
		else
		{
			Log.LogErrorFormatted(this, "GameObjects array was null on game object {0}", base.name);
		}
	}
}
