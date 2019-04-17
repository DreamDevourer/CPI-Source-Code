// FullScreenChatButton
using ClubPenguin.UI;
using UnityEngine;

public class FullScreenChatButton : MonoBehaviour
{
	private const string SHOWN = "Shown";

	public OnOffSpriteSelector ArrowSprite;

	public Animator ButtonAnimator;

	public void SetIsActive(bool isActive)
	{
		ButtonAnimator.SetBool("Shown", isActive);
	}

	public void SetIsFullScreen(bool isFullScreen)
	{
		ArrowSprite.IsOn = isFullScreen;
	}
}
