// TintToggleGroupButton_Text
using ClubPenguin.Gui;
using UnityEngine;
using UnityEngine.UI;

public class TintToggleGroupButton_Text : MonoBehaviour
{
	public Color OnTint;

	public Color OffTint;

	public Text text;

	public Button button;

	private void SetTint(bool on)
	{
		text.color = (on ? OnTint : OffTint);
	}

	private void Awake()
	{
		if (button == null)
		{
			button = GetComponent<Button>();
		}
		if (text == null)
		{
			text = GetComponentInChildren<Text>();
		}
		button.onClick.AddListener(OnClick);
		if (base.transform.parent != null)
		{
			TintToggleGroupButton_Text[] componentsInChildren = base.transform.parent.GetComponentsInChildren<TintToggleGroupButton_Text>(includeInactive: true);
			if (componentsInChildren[0] == this)
			{
				OnClick();
			}
		}
	}

	public void OnClick()
	{
		for (int i = 0; i < base.transform.parent.GetComponentsInChildren<TintToggleGroupButton_Text>(includeInactive: true).Length; i++)
		{
			base.transform.parent.GetComponentsInChildren<TintToggleGroupButton_Text>(includeInactive: true)[i].SetTint(on: false);
		}
		SetTint(on: true);
	}

	private void OnDestroy()
	{
		button.onClick.RemoveListener(OnClick);
	}
}
