// QuestStateData
using ClubPenguin;
using ClubPenguin.Net.Domain;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class QuestStateData : ScopedData
{
	[SerializeField]
	private QuestStateCollection data;

	public QuestStateCollection Data
	{
		get
		{
			return data;
		}
		set
		{
			if (this.OnChanged != null)
			{
				this.OnChanged(value);
			}
			data = value;
		}
	}

	protected override string scopeID => CPDataScopes.Session.ToString();

	protected override Type monoBehaviourType => typeof(QuestStateDataMonoBehaviour);

	public event Action<QuestStateCollection> OnChanged;

	protected override void notifyWillBeDestroyed()
	{
		this.OnChanged = null;
	}
}
