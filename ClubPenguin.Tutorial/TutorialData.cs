// TutorialData
using ClubPenguin;
using ClubPenguin.Tutorial;
using Disney.Kelowna.Common.DataModel;
using System;
using System.Collections;

[Serializable]
public class TutorialData : ScopedData
{
	private BitArray data = new BitArray(0);

	public BitArray Data
	{
		get
		{
			return data;
		}
		set
		{
			data = value;
		}
	}

	protected override Type monoBehaviourType => typeof(TutorialDataMonoBehaviour);

	protected override string scopeID => CPDataScopes.Session.ToString();

	protected override void notifyWillBeDestroyed()
	{
	}
}
