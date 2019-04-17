// LogSingularGameActionButtonInteracted
using ClubPenguin.Analytics;
using ClubPenguin.Input;
using Disney.MobileNetwork;
using UnityEngine;

public class LogSingularGameActionButtonInteracted : MonoBehaviour
{
	[SerializeField]
	private string context = string.Empty;

	[SerializeField]
	private string action = string.Empty;

	[SerializeField]
	private string id = string.Empty;

	private bool listenerAdded;

	private ButtonClickListener clickListener;

	private void Start()
	{
		clickListener = GetComponentInParent<ButtonClickListener>();
		if (clickListener == null)
		{
		}
		addListener();
	}

	private void OnEnable()
	{
		addListener();
	}

	private void OnDisable()
	{
		if (listenerAdded && clickListener != null)
		{
			clickListener.OnClick.RemoveListener(OnClicked);
			listenerAdded = false;
		}
	}

	private void addListener()
	{
		if (!listenerAdded && clickListener != null)
		{
			clickListener.OnClick.AddListener(OnClicked);
			listenerAdded = true;
		}
	}

	private void OnClicked(ButtonClickListener.ClickType interactedType)
	{
		string callID = $"{id}_{interactedType.ToString()}";
		Service.Get<ICPSwrveService>().ActionSingular(callID, $"game.{context}", action, interactedType.ToString());
	}
}
