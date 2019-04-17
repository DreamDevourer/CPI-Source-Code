// PlayerStatusData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class PlayerStatusData : ScopedData
{
	[SerializeField]
	private string questMascotName;

	public string QuestMascotName
	{
		get
		{
			return questMascotName;
		}
		set
		{
			if (questMascotName != value)
			{
				if (this.OnQuestMascotNameChanged != null)
				{
					this.OnQuestMascotNameChanged(this, value);
				}
				questMascotName = value;
			}
		}
	}

	protected override string scopeID => CPDataScopes.Zone.ToString();

	protected override Type monoBehaviourType => typeof(PlayerStatusDataMonoBehaviour);

	public event Action<PlayerStatusData, string> OnQuestMascotNameChanged;

	protected override void notifyWillBeDestroyed()
	{
		this.OnQuestMascotNameChanged = null;
	}
}
