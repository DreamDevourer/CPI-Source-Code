// BackgroundButtonsController
using UnityEngine;

public class BackgroundButtonsController : MonoBehaviour
{
	public GameObject[] EnableButtons;

	public GameObject[] DisableButtons;

	private void Start()
	{
		GameObject[] enableButtons = EnableButtons;
		foreach (GameObject gameObject in enableButtons)
		{
			gameObject.SetActive(value: true);
		}
		enableButtons = DisableButtons;
		foreach (GameObject gameObject in enableButtons)
		{
			gameObject.SetActive(value: false);
		}
	}
}
