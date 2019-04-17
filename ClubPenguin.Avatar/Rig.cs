using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	[DisallowMultipleComponent]
	public class Rig : MonoBehaviour
	{
		[SerializeField]
		private Transform rootBone;

		private Transform[] bones;

		private Dictionary<string, int> boneIndexLookup = new Dictionary<string, int>();

		public Transform[] Bones
		{
			get
			{
				if (this.bones == null)
				{
					if (this.rootBone == null)
					{
						this.rootBone = Rig.FindRootBone(base.gameObject);
					}
					this.bones = Rig.FindBones(this.rootBone);
					for (int i = 0; i < this.bones.Length; i++)
					{
						this.boneIndexLookup[this.bones[i].name] = i;
					}
				}
				return this.bones;
			}
		}

		public Transform RootBone
		{
			get
			{
				return this.Bones[0];
			}
		}

		public Transform this[int index]
		{
			get
			{
				return this.Bones[index];
			}
		}

		public Transform this[string name]
		{
			get
			{
				return this.Bones[this.boneIndexLookup[name]];
			}
		}

		public int Length
		{
			get
			{
				return this.Bones.Length;
			}
		}

		public static Transform FindRootBone(GameObject go)
		{
			Transform transform = null;
			int num = 0;
			while (transform == null && num < go.transform.childCount)
			{
				Transform child = go.transform.GetChild(num);
				if (child.childCount > 0)
				{
					transform = child;
				}
				num++;
			}
			return transform;
		}

		public static Transform[] FindBones(Transform rootBone)
		{
			return rootBone.GetComponentsInChildren<Transform>();
		}

		public static void SetupSkinnedMeshRenderer(SkinnedMeshRenderer smr)
		{
			smr.rootBone = Rig.FindRootBone(smr.gameObject);
			smr.bones = Rig.FindBones(smr.rootBone);
		}

		public void OnDrawGizmosSelected()
		{
			Transform transform = this.rootBone;
			if (transform == null)
			{
				transform = Rig.FindRootBone(base.gameObject);
			}
			if (transform != null)
			{
				Gizmos.color = Color.red;
				Transform[] componentsInChildren = transform.GetComponentsInChildren<Transform>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					Gizmos.DrawLine(componentsInChildren[i].position, componentsInChildren[i].parent.position);
				}
			}
		}
	}
}