// SwidData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;
using UnityEngine;

[Serializable]
public class SwidData : BaseData, IEntityIdentifierData<string>
{
	[SerializeField]
	private string swid;

	public string Swid
	{
		get
		{
			return swid;
		}
		set
		{
			if (!string.IsNullOrEmpty(value))
			{
				swid = value;
				return;
			}
			throw new Exception("Swid cannot be null or empty");
		}
	}

	protected override Type monoBehaviourType => typeof(SwidDataMonoBehaviour);

	public bool Match(string identifier)
	{
		return identifier == swid;
	}

	protected override void notifyWillBeDestroyed()
	{
	}
}
