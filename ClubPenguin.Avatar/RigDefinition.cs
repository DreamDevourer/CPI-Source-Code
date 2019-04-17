using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Assertions;

namespace ClubPenguin.Avatar
{
	[Serializable]
	public class RigDefinition
	{
		[Serializable]
		public class Bone
		{
			public string Name;

			public Vector3 Position;

			public Quaternion Rotation;

			public int ChildCount;

			public Bone(Transform source)
			{
				this.Name = source.name;
				this.Position = source.localPosition;
				this.Rotation = source.localRotation;
				this.ChildCount = source.childCount;
			}

			public Transform ToTransform(Transform parent = null)
			{
				Transform transform = new GameObject(this.Name).transform;
				transform.localPosition = this.Position;
				transform.localRotation = this.Rotation;
				if (parent != null)
				{
					transform.SetParent(parent, false);
				}
				return transform;
			}

			public override string ToString()
			{
				return string.Format("[Bone: Name={0}, Position={1}, Rotation={2}, ChildCount={3}]", new object[]
				{
					this.Name,
					this.Position,
					this.Rotation,
					this.ChildCount
				});
			}
		}

		public RigDefinition.Bone[] Bones;

		public int GetHash()
		{
			StructHash sh = default(StructHash);
			for (int i = 0; i < this.Bones.Length; i++)
			{
				sh.Combine<string>(this.Bones[i].Name);
				sh.Combine<Vector3>(this.Bones[i].Position);
				sh.Combine<Quaternion>(this.Bones[i].Rotation);
				sh.Combine<int>(this.Bones[i].ChildCount);
			}
			return sh;
		}

		public RigDefinition()
		{
			this.Bones = new RigDefinition.Bone[0];
		}

		[Conditional("UNITY_EDITOR")]
		public void FromTransform(Transform source)
		{
			List<RigDefinition.Bone> list = new List<RigDefinition.Bone>();
			this.Bones = list.ToArray();
		}

		[Conditional("UNITY_EDITOR")]
		private void addBone(Transform source, List<RigDefinition.Bone> bones)
		{
			bones.Add(new RigDefinition.Bone(source));
			for (int i = 0; i < source.childCount; i++)
			{
			}
		}

		public Transform ToTransform(Transform[] boneList = null)
		{
			Transform transform = this.Bones[0].ToTransform(null);
			this.createTransforms(transform, 0, boneList);
			return transform;
		}

		private int createTransforms(Transform parent, int index, Transform[] boneList)
		{
			if (boneList != null)
			{
				boneList[index] = parent;
			}
			RigDefinition.Bone bone = this.Bones[index++];
			for (int i = 0; i < bone.ChildCount; i++)
			{
				Transform parent2 = this.Bones[index].ToTransform(parent);
				index = this.createTransforms(parent2, index, boneList);
			}
			return index;
		}

		public int FindBoneIndex(RigDefinition.Bone rhsBone)
		{
			Assert.IsNotNull<RigDefinition.Bone>(rhsBone);
			Assert.IsNotNull<RigDefinition.Bone[]>(this.Bones);
			int num = this.Bones.Length;
			for (int i = 0; i < num; i++)
			{
				RigDefinition.Bone bone = this.Bones[i];
				if (bone.Name == rhsBone.Name)
				{
					num = i;
				}
			}
			return num;
		}
	}
}