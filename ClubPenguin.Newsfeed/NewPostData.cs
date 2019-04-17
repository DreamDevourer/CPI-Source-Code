// NewPostData
using ClubPenguin.Newsfeed;
using Disney.Kelowna.Common.DataModel;
using System;

[Serializable]
public class NewPostData : BaseData
{
	protected override Type monoBehaviourType => typeof(NewPostDataMonoBehaviour);

	protected override void notifyWillBeDestroyed()
	{
	}
}
