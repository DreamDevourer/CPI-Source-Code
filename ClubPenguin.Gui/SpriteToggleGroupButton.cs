// SpriteToggleGroupButton
using ClubPenguin.Gui;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class SpriteToggleGroupButton : MonoBehaviour
{
	public Sprite OnSprite;

	public Sprite OffSprite;

	private SpriteToggleGroupButton[] group;

	private Image image;

	private Button button;

	public void SetSprite(bool on)
	{
		image.sprite = (on ? OnSprite : OffSprite);
	}

	public void Awake()
	{
		button = GetComponent<Button>();
		image = GetComponent<Image>();
		group = base.transform.parent.GetComponentsInChildren<SpriteToggleGroupButton>();
		if (group[0] == this)
		{
			SetSprite(on: true);
		}
		button.onClick.AddListener(OnClick);
	}

	public void OnClick()
	{
		if (group != null)
		{
			for (int i = 0; i < group.Length; i++)
			{
				group[i].SetSprite(on: false);
			}
			SetSprite(on: true);
		}
	}
}
