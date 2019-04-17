// ModalInputHandler
using ClubPenguin.Input;
using Disney.MobileNetwork;

public class ModalInputHandler : InputMapHandler<ModalInputMap.Result>
{
	protected override void Awake()
	{
		if (inputMap == null)
		{
			inputMap = Service.Get<InputService>().ModalInputMap;
		}
		base.Awake();
	}

	protected override void onHandle(ModalInputMap.Result inputResult)
	{
	}

	protected override void onReset()
	{
	}
}
