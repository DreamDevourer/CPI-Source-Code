using Foundation.Unity;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	public static class Combine
	{
		public static Mesh CombineSkinnedMeshes(Mesh[] meshes, int[][] meshBoneIndexes, Matrix4x4[] bindPoses)
		{
			int num = 0;
			for (int i = 0; i < meshes.Length; i++)
			{
				num += meshes[i].vertexCount;
			}
			CombineInstance[] array = new CombineInstance[meshes.Length];
			BoneWeight[] array2 = new BoneWeight[num];
			int num2 = 0;
			for (int i = 0; i < meshes.Length; i++)
			{
				BoneWeight[] boneWeights = meshes[i].boneWeights;
				int[] array3 = meshBoneIndexes[i];
				for (int j = 0; j < boneWeights.Length; j++)
				{
					BoneWeight boneWeight = boneWeights[j];
					boneWeight.boneIndex0 = array3[boneWeight.boneIndex0];
					boneWeight.boneIndex1 = array3[boneWeight.boneIndex1];
					boneWeight.boneIndex2 = array3[boneWeight.boneIndex2];
					boneWeight.boneIndex3 = array3[boneWeight.boneIndex3];
					array2[num2++] = boneWeight;
				}
				array[i] = new CombineInstance
				{
					mesh = meshes[i]
				};
			}
			Mesh mesh = new Mesh();
			mesh.CombineMeshes(array, true, false);
			mesh.bindposes = bindPoses;
			mesh.boneWeights = array2;
			mesh.RecalculateBounds();
			mesh.name = string.Format("CombinedMesh_{0:X8}", mesh.GetHash());
			return mesh;
		}

		public static Rect[] CalculateAtlasLayout(List<ViewPart> parts, out int curSize)
		{
			Rect[] array = new Rect[parts.Count];
			for (int i = 0; i < parts.Count; i++)
			{
				ViewPart viewPart = parts[i];
				float num = viewPart.GetTextureSize().y;
				num = ((num > 0f) ? num : 16f);
				array[i] = new Rect(0f, 0f, num, num);
			}
			curSize = Combine.Pack(array, 0);
			for (int j = 0; j < array.Length; j++)
			{
				Rect rect = new Rect(array[j].x / (float)curSize, array[j].y / (float)curSize, array[j].width / (float)curSize, array[j].height / (float)curSize);
				array[j] = rect;
			}
			return array;
		}

		public static void BakeTexture(List<ViewPart> parts, Rect[] atlasUVOffsets, BodyColorMaterialProperties bodyColor, RenderTexture atlasRenderTexture)
		{
			BakeMaterialProperties bakeMaterialProperties = new BakeMaterialProperties(null);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = atlasRenderTexture;
			GL.Clear(true, true, new Color32(0, 0, 0, 0));
			for (int i = 0; i < parts.Count; i++)
			{
				ViewPart viewPart = parts[i];
				Material material = new Material(viewPart.HasMaterialProperties(typeof(EquipmentMaterialProperties)) ? AvatarService.EquipmentBakeShader : AvatarService.BodyBakeShader);
				Texture maskTexture = viewPart.GetMaskTexture();
				viewPart.ApplyMaterialProperties(material);
				bodyColor.Apply(material);
				Rect rect = atlasUVOffsets[i];
				bakeMaterialProperties.AtlasOffsetU = rect.x;
				bakeMaterialProperties.AtlasOffsetV = rect.y;
				bakeMaterialProperties.AtlasOffsetScaleU = rect.width;
				bakeMaterialProperties.AtlasOffsetScaleV = rect.height;
				bakeMaterialProperties.Apply(material);
				atlasRenderTexture.DiscardContents();
				Graphics.Blit(maskTexture, atlasRenderTexture, material);
				Object.Destroy(material);
			}
			RenderTexture.active = active;
		}

		public static void ApplyAtlasUV(Mesh[] meshes, Mesh combinedMesh, Rect[] atlasUVOffsets)
		{
			Vector2[] uv = combinedMesh.uv;
			Vector2[] array = new Vector2[uv.Length];
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].x = Mathf.Lerp(atlasUVOffsets[num].xMin, atlasUVOffsets[num].xMax, uv[i].x);
				array[i].y = Mathf.Lerp(atlasUVOffsets[num].yMin, atlasUVOffsets[num].yMax, uv[i].y);
				int vertexCount = meshes[num].vertexCount;
				if (i == num2 + vertexCount - 1)
				{
					num2 += vertexCount;
					num++;
				}
			}
			combinedMesh.uv = array;
		}

		public static int Pack(Rect[] rects, int padding)
		{
			int num = rects.Length;
			float[] array = new float[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = rects[i].width;
			}
			List<int> list = new List<int>();
			for (int i = 0; i < num; i++)
			{
				float num2 = 0f;
				int item = 0;
				for (int j = 0; j < num; j++)
				{
					if (!list.Contains(j))
					{
						float num3 = array[j];
						if (num3 > num2)
						{
							num2 = num3;
							item = j;
						}
					}
				}
				list.Add(item);
			}
			int num4 = 0;
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			for (int i = 0; i < num; i++)
			{
				Rect rect = rects[list[i]];
				int num5 = (int)rect.width;
				int num6 = (int)rect.height;
				bool flag = false;
				int num7 = list2.Count;
				int num8 = 0;
				for (int k = 0; k < num7; k++)
				{
					if (num6 + list3[k] + padding * 2 < num4 && num5 + padding * 2 <= list2[k])
					{
						rect.x = (float)(num8 + padding);
						rect.y = (float)(list3[k] + padding);
						if (num5 != list2[k])
						{
							list2.Insert(k + 1, list2[k] - (num5 + padding * 2));
							list3.Insert(k + 1, list3[k]);
							list2[k] = num5 + padding * 2;
							num7++;
						}
						List<int> list4;
						int index;
						(list4 = list3)[index = k] = list4[index] + (num6 + padding * 2);
						flag = true;
						break;
					}
					num8 += list2[k];
				}
				if (!flag)
				{
					rect.x = (float)(num4 + padding);
					rect.y = (float)padding;
					list2.Add(num5 + padding * 2);
					list3.Add(num6 + padding * 2);
					num4 += num5 + padding * 2;
				}
				rects[list[i]] = rect;
			}
			return num4;
		}
	}
}