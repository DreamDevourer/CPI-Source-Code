// InputService
using ClubPenguin.Input;
using UnityEngine;

public class InputService : MonoBehaviour
{
	private ControlScheme controlScheme;

	private InputMapPriority inputMapPriority;

	public InputMapLib ModalInputMap => inputMapPriority.ModalInputMap;

	public InputMapLib AnyKeyInputMap => inputMapPriority.AnyKeyInputMap;

	public void Initialize(ControlScheme controlScheme, InputMapPriority inputMapPriority, KeyCodeRemapper keyCodeRemapper)
	{
		this.controlScheme = controlScheme;
		this.inputMapPriority = inputMapPriority;
		this.controlScheme.Initialize(keyCodeRemapper);
		foreach (InputMapLib priority in this.inputMapPriority.PriorityList)
		{
			priority.Initialize();
		}
	}

	private void Update()
	{
		controlScheme.StartFrame();
		bool flag = true;
		foreach (InputMapLib priority in inputMapPriority.PriorityList)
		{
			if (!flag)
			{
				priority.ResetInput();
			}
			else if (priority.ProcessInput(controlScheme) || priority.InputBlocker)
			{
				flag = false;
			}
		}
		controlScheme.EndFrame();
	}

	public void PopulateInputInfo(InputInfo inputInfo)
	{
		inputInfo.Populate(controlScheme);
	}
}
