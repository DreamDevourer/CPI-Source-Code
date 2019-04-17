// FishBucketInkedPopup
using UnityEngine;
using UnityEngine.UI;

public class FishBucketInkedPopup : MonoBehaviour
{
	public Text ScoreText;

	public void SetScore(int scoreDelta)
	{
		ScoreText.text = scoreDelta.ToString();
	}
}
