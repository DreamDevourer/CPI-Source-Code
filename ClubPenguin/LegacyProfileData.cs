// LegacyProfileData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;

[Serializable]
public class LegacyProfileData : BaseData
{
	public string Username
	{
		get;
		set;
	}

	public bool IsMember
	{
		get;
		set;
	}

	public long CreatedDate
	{
		get;
		set;
	}

	public long MigratedDate
	{
		get;
		set;
	}

	protected override Type monoBehaviourType => typeof(LegacyProfileDataDataMonoBehaviour);

	public override string ToString()
	{
		return $"legacyProfileData: \n \t username: {Username.ToString()}, \n \t isMember: {IsMember.ToString()}, \n \t createdDate: {CreatedDate.ToString()},  \n \t migratedDate: {MigratedDate.ToString()}";
	}

	protected override void notifyWillBeDestroyed()
	{
	}
}
