using Fabric;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ClubPenguin.Audio
{
	[RequireComponent(typeof(Toggle))]
	internal class ToggleToFabricEvents : MonoBehaviour
	{
		private const string DEFAULT_CLICK_AUDIO = "SFX/UI/Button/Select";

		public bool Mute;

		[Tooltip("If left empty, this defaults to SFX/UI/Button/Select")]
		public string AudioName = "";

		public EventAction EventType = EventAction.PlaySound;

		public GameObject OverrideSoundSource;

		private void Start()
		{
			base.GetComponent<Toggle>().onValueChanged.AddListener(new UnityAction<bool>(this.onToggleChanged));
		}

		private void onToggleChanged(bool isActive)
		{
			string eventName = "SFX/UI/Button/Select";
			if (!string.IsNullOrEmpty(this.AudioName))
			{
				eventName = this.AudioName;
			}
			GameObject parentGameObject = (this.OverrideSoundSource != null) ? this.OverrideSoundSource : base.gameObject;
			EventManager.Instance.PostEvent(eventName, this.EventType, parentGameObject);
		}
	}
}