using ClubPenguin.Input;
using Fabric;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace ClubPenguin.Audio
{
	[RequireComponent(typeof(ButtonClickListener))]
	public class ButtonToFabricEvents : MonoBehaviour
	{
		private const string DEFAULT_CLICK_AUDIO = "SFX/UI/MainTray/ButtonSmall";

		public bool Mute;

		[Tooltip("If left empty, this defaults to SFX/UI/MainTray/ButtonSmall")]
		public string AudioName = "";

		public EventAction EventType = EventAction.PlaySound;

		public GameObject OverrideSoundSource;

		private ButtonClickListener clickListener;

		private void Awake()
		{
			this.clickListener = base.GetComponent<ButtonClickListener>();
		}

		private void OnEnable()
		{
			if (this.clickListener != null)
			{
				this.clickListener.OnClick.AddListener(new UnityAction<ButtonClickListener.ClickType>(this.onClicked));
			}
		}

		private void OnDisable()
		{
			if (this.clickListener != null)
			{
				this.clickListener.OnClick.RemoveListener(new UnityAction<ButtonClickListener.ClickType>(this.onClicked));
			}
		}

		private void onClicked(ButtonClickListener.ClickType interactedType)
		{
			if (EventManager.Instance != null)
			{
				string eventName = string.IsNullOrEmpty(this.AudioName) ? "SFX/UI/MainTray/ButtonSmall" : this.AudioName;
				GameObject parentGameObject = (this.OverrideSoundSource != null) ? this.OverrideSoundSource : base.gameObject;
				EventManager.Instance.PostEvent(eventName, this.EventType, parentGameObject);
			}
		}
	}
}