// TemplateIcon
using ClubPenguin;
using ClubPenguin.ClothingDesigner;
using ClubPenguin.ClothingDesigner.ItemCustomizer;
using ClubPenguin.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemplateIcon : CustomizationButton
{
	[SerializeField]
	private GameObject memberBadge;

	[SerializeField]
	private GameObject progressionBadge;

	[SerializeField]
	private GameObject mascotBadges;

	[SerializeField]
	private MaterialSelector materialSelector;

	private bool isEnabled = true;

	private bool isMemberLocked = false;

	private Button button;

	public TemplateDefinition TemplateData
	{
		get;
		private set;
	}

	public bool CanSelect
	{
		get;
		private set;
	}

	public bool IsEnabled
	{
		get
		{
			return isEnabled;
		}
		set
		{
			isEnabled = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		memberBadge.SetActive(value: false);
		progressionBadge.SetActive(value: false);
		mascotBadges.SetActive(value: false);
		button = GetComponent<Button>();
	}

	private void OnEnable()
	{
		if (button != null)
		{
			button.onClick.AddListener(onButtonClicked);
		}
	}

	private void OnDisable()
	{
		if (button != null)
		{
			button.onClick.RemoveListener(onButtonClicked);
		}
	}

	public void SetTemplateToUnlocked(TemplateDefinition templateData)
	{
		TemplateData = templateData;
		materialSelector.SelectMaterial(0);
		CanSelect = true;
		progressionBadge.SetActive(value: false);
		memberBadge.SetActive(value: false);
		mascotBadges.SetActive(value: false);
		isMemberLocked = false;
	}

	public void SetTemplateMemberLocked(TemplateDefinition templateData)
	{
		TemplateData = templateData;
		materialSelector.SelectMaterial(1);
		CanSelect = false;
		progressionBadge.SetActive(value: false);
		mascotBadges.SetActive(value: false);
		memberBadge.SetActive(value: true);
		isMemberLocked = true;
	}

	public void SetTemplateToLevelLocked(TemplateDefinition templateData, int level)
	{
		TemplateData = templateData;
		materialSelector.SelectMaterial(1);
		CanSelect = false;
		memberBadge.SetActive(value: false);
		mascotBadges.SetActive(value: false);
		progressionBadge.SetActive(value: true);
		progressionBadge.GetComponentInChildren<Text>().text = level.ToString();
		isMemberLocked = false;
	}

	public void SetTemplateToProgressionLocked(TemplateDefinition templateData, string mascotName)
	{
		TemplateData = templateData;
		materialSelector.SelectMaterial(1);
		CanSelect = false;
		progressionBadge.SetActive(value: false);
		memberBadge.SetActive(value: false);
		mascotBadges.SetActive(value: true);
		IList<Transform> children = mascotBadges.GetChildren();
		for (int i = 0; i < children.Count; i++)
		{
			if (children[i].name.Equals(mascotName))
			{
				children[i].gameObject.SetActive(value: true);
			}
			else
			{
				children[i].gameObject.SetActive(value: false);
			}
		}
		isMemberLocked = false;
	}

	private void onButtonClicked()
	{
		if (isMemberLocked)
		{
			ClothingDesignerContext.EventBus.DispatchEvent(new ClothingDesignerUIEvents.ShowMemberFlow("blueprints"));
		}
	}
}
