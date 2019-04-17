using System;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	[RequireComponent(typeof(Rig))]
	public class AvatarViewDistinct : AvatarView
	{
		private AvatarViewDistinctChild[,] children;

		private Rig rig;

		private bool boundsIsDirty = false;

		private Bounds cachedBounds;

		public event Action<AvatarViewDistinctChild> OnChildAdded;

		protected override void onAwake()
		{
			this.children = new AvatarViewDistinctChild[this.Model.RowMax, this.Model.ColumnMax];
			this.rig = base.GetComponent<Rig>();
		}

		public override Bounds GetBounds()
		{
			if (this.boundsIsDirty)
			{
				UnityEngine.Debug.Log("CARL: UPDATING");
				this.cachedBounds = new Bounds(base.transform.position, Vector3.zero);
				for (int i = 0; i < this.children.GetLength(0); i++)
				{
					for (int j = 0; j < this.children.GetLength(1); j++)
					{
						AvatarViewDistinctChild avatarViewDistinctChild = this.children[i, j];
						if (avatarViewDistinctChild != null)
						{
							this.cachedBounds.Encapsulate(avatarViewDistinctChild.Renderer.bounds);
						}
					}
				}
				this.boundsIsDirty = false;
			}
			return this.cachedBounds;
		}

		public void OnEnable()
		{
			this.Model.PartChanged += new Action<int, int, AvatarModel.Part, AvatarModel.Part>(this.model_PartChanged);
		}

		public void OnDisable()
		{
			this.Model.PartChanged -= new Action<int, int, AvatarModel.Part, AvatarModel.Part>(this.model_PartChanged);
		}

		protected override void cleanup()
		{
		}

		private void applyPart(int slotIndex, int partIndex, AvatarModel.Part newPart)
		{
			AvatarViewDistinctChild avatarViewDistinctChild = this.children[slotIndex, partIndex];
			if (avatarViewDistinctChild == null && newPart != null)
			{
				string text = this.Model.Definition.Slots[slotIndex].Name;
				if (partIndex > 0)
				{
					text = text + "_" + AvatarDefinition.PartTypeStrings[partIndex];
				}
				GameObject gameObject = new GameObject(text);
				gameObject.transform.SetParent(base.transform, false);
				gameObject.layer = base.gameObject.layer;
				gameObject.SetActive(false);
				avatarViewDistinctChild = gameObject.AddComponent<AvatarViewDistinctChild>();
				avatarViewDistinctChild.SlotIndex = slotIndex;
				avatarViewDistinctChild.PartIndex = partIndex;
				avatarViewDistinctChild.Model = this.Model;
				avatarViewDistinctChild.Rig = this.rig;
				gameObject.SetActive(true);
				this.children[slotIndex, partIndex] = avatarViewDistinctChild;
				if (this.OnChildAdded != null)
				{
					this.OnChildAdded(avatarViewDistinctChild);
				}
			}
			this.boundsIsDirty = true;
			if (avatarViewDistinctChild != null)
			{
				avatarViewDistinctChild.Apply(newPart);
				if (avatarViewDistinctChild.IsBusy && !base.IsBusy)
				{
					base.startWork();
				}
			}
		}

		public void Update()
		{
			bool flag = false;
			bool flag2 = true;
			for (int i = 0; i < this.children.GetLength(0); i++)
			{
				for (int j = 0; j < this.children.GetLength(1); j++)
				{
					AvatarViewDistinctChild avatarViewDistinctChild = this.children[i, j];
					if (avatarViewDistinctChild != null)
					{
						flag |= avatarViewDistinctChild.IsBusy;
						flag2 &= avatarViewDistinctChild.IsReady;
					}
				}
			}
			if (flag && !base.IsBusy)
			{
				base.startWork();
			}
			else if (!flag && base.IsBusy)
			{
				base.stopWork();
			}
			else if (flag2 && !base.IsReady)
			{
				base.startWork();
				base.stopWork();
			}
		}

		private void model_PartChanged(int slotIndex, int partIndex, AvatarModel.Part oldPart, AvatarModel.Part newPart)
		{
			this.applyPart(slotIndex, partIndex, newPart);
		}
	}
}