// FriendsSearchStateHandler
using UnityEngine;
using UnityEngine.UI;

public class FriendsSearchStateHandler : MonoBehaviour
{
	public Text TitleText;

	public GameObject FriendsResults;

	public GameObject SearchResult;

	public GameObject BackButton;

	public GameObject CloseButton;

	private string friendsResults = "#Friends Search#";

	private string searchResult = "#Search Result#";

	public void OnStateChanged(string state)
	{
		if (state == null)
		{
			return;
		}
		if (!(state == "FriendsResults"))
		{
			if (state == "SearchResult")
			{
				TitleText.text = searchResult;
				FriendsResults.SetActive(value: false);
				SearchResult.SetActive(value: true);
				CloseButton.SetActive(value: false);
				BackButton.SetActive(value: true);
			}
		}
		else
		{
			TitleText.text = friendsResults;
			FriendsResults.SetActive(value: true);
			SearchResult.SetActive(value: false);
			CloseButton.SetActive(value: true);
			BackButton.SetActive(value: false);
		}
	}
}
