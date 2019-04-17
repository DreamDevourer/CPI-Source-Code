// AllAccessCelebrationData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;

[Serializable]
public class AllAccessCelebrationData : ScopedData
{
	public bool ShowAllAccessCelebration;

	protected override string scopeID => CPDataScopes.Session.ToString();

	protected override Type monoBehaviourType => typeof(AllAccessCelebrationDataMonoBehaviour);

	protected override void notifyWillBeDestroyed()
	{
	}
}
