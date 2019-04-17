using System;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	[RequireComponent(typeof(AvatarOutfit))]
	public class AvatarControllerStaticOutfit : AvatarController
	{
		public void Start()
		{
			AvatarOutfit component = base.GetComponent<AvatarOutfit>();
			this.Model.BeakColor = component.BeakColor;
			this.Model.BellyColor = component.BellyColor;
			this.Model.BodyColor = component.BodyColor;
			this.Model.ClearAllEquipment();
			this.Model.ApplyOutfit(component.Outfit);
		}
	}
}