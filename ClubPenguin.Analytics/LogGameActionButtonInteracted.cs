// LogGameActionButtonInteracted
using ClubPenguin.Analytics;
using ClubPenguin.Input;
using Disney.MobileNetwork;
using UnityEngine;

[RequireComponent(typeof(ButtonClickListener))]
public class LogGameActionButtonInteracted : MonoBehaviour
{
	[SerializeField]
	private string context = string.Empty;

	[SerializeField]
	private string action = string.Empty;

	[SerializeField]
	private string message = string.Empty;

	[SerializeField]
	private string type = string.Empty;

	private ButtonClickListener clickListener;

	private void Awake()
	{
		clickListener = GetComponent<ButtonClickListener>();
	}

	private void OnEnable()
	{
		clickListener.OnClick.AddListener(OnClicked);
	}

	private void OnDisable()
	{
		clickListener.OnClick.RemoveListener(OnClicked);
	}

	private void OnClicked(ButtonClickListener.ClickType interactedType)
	{
		string arg = $"{context}.{action}";
		if (!string.IsNullOrEmpty(message))
		{
			arg = $"{arg}.{message}";
		}
		if (!string.IsNullOrEmpty(type))
		{
			arg = $"{arg}.{type}";
		}
		arg = $"{arg}.{interactedType.ToString()}";
		Service.Get<ICPSwrveService>().NavigationAction(arg);
	}
}
