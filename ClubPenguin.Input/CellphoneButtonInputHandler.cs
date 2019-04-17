// CellphoneButtonInputHandler
using ClubPenguin.Input;
using UnityEngine;

public class CellphoneButtonInputHandler : InputMapHandler<CellphoneButtonInputMap.Result>
{
	[SerializeField]
	private InputMappedButton btnCellphone = null;

	private new void OnValidate()
	{
	}

	protected override void onHandle(CellphoneButtonInputMap.Result inputResult)
	{
		btnCellphone.HandleMappedInput(inputResult.Cellphone);
	}

	protected override void onReset()
	{
		btnCellphone.HandleMappedInput();
	}
}
