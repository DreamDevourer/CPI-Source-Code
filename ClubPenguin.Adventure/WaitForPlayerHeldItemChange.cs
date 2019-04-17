// WaitForPlayerHeldItemChange
using ClubPenguin;
using ClubPenguin.Core;
using ClubPenguin.Props;
using Disney.Kelowna.Common.DataModel;
using Disney.MobileNetwork;
using HutongGames.PlayMaker;

[ActionCategory("Props")]
public class WaitForPlayerHeldItemChange : FsmStateAction
{
	public FsmString ObjectId;

	public FsmEvent RetrievedEvent;

	private DataEntityHandle handle;

	public override void OnEnter()
	{
		Prop component = base.Owner.GetComponent<Prop>();
		if (component != null)
		{
			handle = component.PropUserRef.PlayerHandle;
			if (!handle.IsNull)
			{
				Service.Get<CPDataEntityCollection>().GetComponent<HeldObjectsData>(handle).PlayerHeldObjectChanged += onPlayerHeldItemChanged;
			}
		}
	}

	public override void OnExit()
	{
		if (!handle.IsNull)
		{
			Service.Get<CPDataEntityCollection>().GetComponent<HeldObjectsData>(handle).PlayerHeldObjectChanged -= onPlayerHeldItemChanged;
		}
	}

	private void onPlayerHeldItemChanged(DHeldObject heldObject)
	{
		ObjectId.Value = ((heldObject != null) ? heldObject.ObjectId : "");
		base.Fsm.Event(RetrievedEvent);
	}
}
