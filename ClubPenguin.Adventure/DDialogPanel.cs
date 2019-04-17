// DDialogPanel
using ClubPenguin.Adventure;
using System;
using UnityEngine;

[Serializable]
public class DDialogPanel
{
	[TextArea]
	public DialogList.Entry Dialog;

	[HideInInspector]
	public string[] i18nTextArgs;

	public bool ClickToClose = true;
}
