// SubscriptionData
using ClubPenguin;
using Disney.Kelowna.Common.DataModel;
using System;

[Serializable]
public class SubscriptionData : BaseData
{
	public string SubscriptionVendor
	{
		get;
		set;
	}

	public string SubscriptionProductId
	{
		get;
		set;
	}

	public bool SubscriptionPaymentPending
	{
		get;
		set;
	}

	public bool SubscriptionRecurring
	{
		get;
		set;
	}

	protected override Type monoBehaviourType => typeof(SubscriptionDataMonoBehaviour);

	public override string ToString()
	{
		return $"SubscriptionData: \n \t SubscriptionVendor: {SubscriptionVendor},  \n \t SubscriptionProductId: {SubscriptionProductId},  \n \t SubscriptionPaymentPending: {SubscriptionPaymentPending},  \n \t SubscriptionRecurring: {SubscriptionRecurring}";
	}

	protected override void notifyWillBeDestroyed()
	{
	}
}
