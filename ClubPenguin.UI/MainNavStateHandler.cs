// MainNavStateHandler
using ClubPenguin;
using ClubPenguin.Core;
using ClubPenguin.UI;
using Disney.Kelowna.Common.DataModel;
using Disney.MobileNetwork;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MainNavStateHandler : MonoBehaviour
{
	public GameObject ButtonParent;

	public GameObject TitleParent;

	public GameObject CloseButtonParent;

	public GameObject BackButton;

	public Text TitleText;

	private MainNavData mainNavData;

	private CanvasGroup canvasGroup;

	private LayoutElement layoutElement;

	private float defaultLayoutElementHeight;

	public void Awake()
	{
		TitleParent.SetActive(value: true);
		CloseButtonParent.SetActive(value: true);
		CPDataEntityCollection cPDataEntityCollection = Service.Get<CPDataEntityCollection>();
		DataEntityHandle entityByType = cPDataEntityCollection.GetEntityByType<MainNavData>();
		mainNavData = cPDataEntityCollection.GetComponent<MainNavData>(entityByType);
		layoutElement = GetComponent<LayoutElement>();
		if (layoutElement != null)
		{
			defaultLayoutElementHeight = layoutElement.preferredHeight;
		}
	}

	public void Start()
	{
		MainNavButtonSelector mainNavButtonSelector = UnityEngine.Object.FindObjectOfType<MainNavButtonSelector>();
		if (mainNavButtonSelector != null)
		{
			mainNavButtonSelector.SelectNavButton();
		}
	}

	public void OnStateChanged(string newStateString)
	{
		MainNavData.State state = (MainNavData.State)Enum.Parse(typeof(MainNavData.State), newStateString);
		mainNavData.CurrentState = state;
		switch (state)
		{
		case MainNavData.State.Closed:
			setVisible(isVisible: true);
			ButtonParent.SetActive(value: true);
			TitleParent.SetActive(value: false);
			CloseButtonParent.GetComponentInChildren<MainNavBarCloseButton>().setState(MainNavButtonState.SELECTED);
			CloseButtonParent.SetActive(value: false);
			break;
		case MainNavData.State.Title:
			setVisible(isVisible: true);
			ButtonParent.SetActive(value: false);
			TitleParent.SetActive(value: true);
			CloseButtonParent.SetActive(value: true);
			CloseButtonParent.GetComponentInChildren<MainNavBarCloseButton>().setState(MainNavButtonState.NORMAL);
			scaleDownChildren(TitleParent.transform);
			break;
		case MainNavData.State.Open:
			setVisible(isVisible: true);
			ButtonParent.SetActive(value: true);
			TitleParent.SetActive(value: false);
			CloseButtonParent.SetActive(value: true);
			break;
		case MainNavData.State.Hidden:
			setVisible(isVisible: false);
			break;
		}
	}

	private void scaleDownChildren(Transform parent)
	{
		int childCount = parent.childCount;
		for (int i = 0; i < childCount; i++)
		{
			parent.GetChild(i).localScale = Vector3.zero;
		}
	}

	private void setVisible(bool isVisible)
	{
		if (!isVisible)
		{
			if (canvasGroup == null)
			{
				base.gameObject.AddComponent<CanvasGroup>();
				canvasGroup = GetComponent<CanvasGroup>();
			}
			canvasGroup.blocksRaycasts = false;
			canvasGroup.interactable = false;
			canvasGroup.alpha = 0f;
			if (layoutElement != null)
			{
				layoutElement.preferredHeight = 0f;
			}
		}
		else
		{
			if (canvasGroup != null)
			{
				canvasGroup.blocksRaycasts = true;
				canvasGroup.interactable = true;
				canvasGroup.alpha = 1f;
			}
			if (layoutElement != null)
			{
				layoutElement.preferredHeight = defaultLayoutElementHeight;
			}
		}
	}

	public void SetTitleText(string titleText)
	{
		TitleText.text = titleText;
	}

	public void SetBackButtonVisible(bool visible)
	{
		BackButton.SetActive(visible);
	}
}
