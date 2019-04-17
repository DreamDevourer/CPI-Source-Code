// LocalPlayerMembershipSpriteSelector
using ClubPenguin;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LocalPlayerMembershipSpriteSelector : AbstractLocalPlayerMembershipControl
{
	public Sprite MemberSprite;

	private Image targetImage;

	private Sprite nonMemberSprite;

	private void Awake()
	{
		targetImage = GetComponent<Image>();
		nonMemberSprite = targetImage.sprite;
	}

	protected override void membershipSet(bool isMember)
	{
		if (isMember)
		{
			targetImage.sprite = MemberSprite;
		}
		else
		{
			targetImage.sprite = nonMemberSprite;
		}
	}
}
