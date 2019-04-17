using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using Foundation.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Profiling;

namespace ClubPenguin.Avatar
{
	public class AvatarService
	{
		public class Request
		{
			public Mesh Mesh;

			public RenderTexture Atlas;

			public bool Finished;
		}

		private sealed class _partsCombiner_d__0 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private object __2__current;

			private int __1__state;

			public AvatarService.Request request;

			public AvatarDefinition definition;

			public BodyColorMaterialProperties bodycolor;

			public List<ViewPart> parts;

			public int maxAtlasDimension;

			public int _meshCount_5__1;

			public Mesh[] _meshes_5__2;

			public int[][] _meshBoneIndexes_5__3;

			public int _curSize_5__4;

			public Rect[] _atlasUVOffsets_5__5;

			public int _renderTextureSize_5__6;

			object IEnumerator<object>.Current
			{
				get
				{
					return this.__2__current;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					return this.__2__current;
				}
			}

			bool IEnumerator.MoveNext()
			{
				bool result;
				switch (this.__1__state)
				{
				case 0:
					this.__1__state = -1;
					this._meshCount_5__1 = this.parts.Count;
					this._meshes_5__2 = new Mesh[this._meshCount_5__1];
					this._meshBoneIndexes_5__3 = new int[this._meshCount_5__1][];
					for (int i = 0; i < this._meshCount_5__1; i++)
					{
						string[] boneNames = this.parts[i].GetBoneNames();
						this._meshes_5__2[i] = this.parts[i].GetMesh();
						this._meshBoneIndexes_5__3[i] = new int[boneNames.Length];
						for (int j = 0; j < boneNames.Length; j++)
						{
							this._meshBoneIndexes_5__3[i][j] = this.definition.BoneIndexLookup[boneNames[j]];
						}
					}
					this.request.Mesh = Combine.CombineSkinnedMeshes(this._meshes_5__2, this._meshBoneIndexes_5__3, this.definition.BindPose);
					this.__2__current = null;
					this.__1__state = 1;
					result = true;
					return result;
				case 1:
					this.__1__state = -1;
					this._atlasUVOffsets_5__5 = Combine.CalculateAtlasLayout(this.parts, out this._curSize_5__4);
					this.__2__current = null;
					this.__1__state = 2;
					result = true;
					return result;
				case 2:
					this.__1__state = -1;
					this._renderTextureSize_5__6 = Mathf.Min(Mathf.ClosestPowerOfTwo(this._curSize_5__4), this.maxAtlasDimension);
					this.request.Atlas = new RenderTexture(this._renderTextureSize_5__6, this._renderTextureSize_5__6, 0, RenderTextureFormat.ARGB32);
					this.request.Atlas.isPowerOfTwo = true;
					this.request.Atlas.filterMode = FilterMode.Bilinear;
					this.request.Atlas.useMipMap = false;
					Combine.BakeTexture(this.parts, this._atlasUVOffsets_5__5, this.bodycolor, this.request.Atlas);
					this.__2__current = null;
					this.__1__state = 3;
					result = true;
					return result;
				case 3:
					this.__1__state = -1;
					Combine.ApplyAtlasUV(this._meshes_5__2, this.request.Mesh, this._atlasUVOffsets_5__5);
					break;
				}
				result = false;
				return result;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			public _partsCombiner_d__0(int __1__state)
			{
				this.__1__state = __1__state;
			}
		}

		private sealed class _fibre_d__8 : IEnumerator<bool>, IEnumerator, IDisposable
		{
			private bool __2__current;

			private int __1__state;

			public AvatarService __4__this;

			public KeyValuePair<AvatarService.Request, IEnumerator> _current_5__9;

			public bool _busy_5__a;

			public int _step_5__b;

			bool IEnumerator<bool>.Current
			{
				get
				{
					return this.__2__current;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					return this.__2__current;
				}
			}

			bool IEnumerator.MoveNext()
			{
				switch (this.__1__state)
				{
				case 0:
					this.__1__state = -1;
					goto IL_17A;
				case 2:
					this.__1__state = -1;
					if (!this._busy_5__a)
					{
						goto IL_149;
					}
					goto IL_79;
				case 3:
					this.__1__state = -1;
					goto IL_179;
				}
				bool result = false;
				return result;
				IL_79:
				try
				{
					Profiler.BeginSample("ApplyCombinedMesh_" + this._step_5__b++);
					this._busy_5__a = this._current_5__9.Value.MoveNext();
					Profiler.EndSample();
				}
				catch (Exception ex)
				{
					Log.LogException(this.__4__this, ex);
					ComponentExtensions.DestroyIfInstance(this._current_5__9.Key.Mesh);
					ComponentExtensions.DestroyIfInstance(this._current_5__9.Key.Atlas);
					this._current_5__9.Key.Mesh = null;
					this._current_5__9.Key.Atlas = null;
					goto IL_149;
				}
				this.__2__current = true;
				this.__1__state = 2;
				result = true;
				return result;
				IL_149:
				this._current_5__9.Key.Finished = true;
				IL_179:
				IL_17A:
				if (this.__4__this.queue.Count > 0)
				{
					this._current_5__9 = this.__4__this.queue.Dequeue();
					this._step_5__b = 0;
					goto IL_79;
				}
				this.__2__current = false;
				this.__1__state = 3;
				result = true;
				return result;
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			public _fibre_d__8(int __1__state)
			{
				this.__1__state = __1__state;
			}
		}

		public const string COMBINED_MESH_SHADER_NAME = "CpRemix/Combined Avatar";

		public const string COMBINED_MESH_TRANSPARENT_SHADER_NAME = "CpRemix/Combined Avatar Alpha";

		public const string BODY_PREVIEW_SHADER_NAME = "CpRemix/Avatar Body Preview";

		public const string BODY_BAKE_SHADER_NAME = "CpRemix/Avatar Body Bake";

		public const string EQUIPMENT_PREVIEW_SHADER_NAME = "CpRemix/Equipment Preview";

		public const string EQUIPMENT_BAKE_SHADER_NAME = "CpRemix/Equipment Bake";

		public const string EQUIPMENT_SCREENSHOT_SHADER_NAME = "CpRemix/Equipment Screenshot";

		public const string GPU_COMBINED_MESH_SHADER_NAME = "CpRemix/GPU Combined Avatar";

		public const string GPU_COMBINED_TRANSPARENT_SHADER_NAME = "CpRemix/GPU Combined Avatar Alpha";

		public static Shader CombinedMeshShader;

		public static Shader BodyBakeShader;

		public static Shader BodyPreviewShader;

		public static Shader EquipmentBakeShader;

		public static Shader EquipmentPreviewShader;

		public static Shader EquipmentScreenshotShader;

		public static Shader GpuCombinedMeshShader;

		public static readonly Color DefaultBodyColor = new Color32(25, 210, 214, 255);

		protected readonly AvatarDefinition[] definitions;

		private readonly Queue<KeyValuePair<AvatarService.Request, IEnumerator>> queue = new Queue<KeyValuePair<AvatarService.Request, IEnumerator>>();

		[RuntimeInitializeOnLoadMethod]
		public static void Initialize()
		{
			AvatarService.CombinedMeshShader = Shader.Find("CpRemix/Combined Avatar");
			AvatarService.BodyBakeShader = Shader.Find("CpRemix/Avatar Body Bake");
			AvatarService.BodyPreviewShader = Shader.Find("CpRemix/Avatar Body Preview");
			AvatarService.EquipmentBakeShader = Shader.Find("CpRemix/Equipment Bake");
			AvatarService.EquipmentPreviewShader = Shader.Find("CpRemix/Equipment Preview");
			AvatarService.EquipmentScreenshotShader = Shader.Find("CpRemix/Equipment Screenshot");
			AvatarService.GpuCombinedMeshShader = Shader.Find("CpRemix/GPU Combined Avatar");
		}

		public AvatarService(AvatarDefinition[] definitions)
		{
			Service.Get<FibreService>().AddFibre("AvatarService:New", 5f, new FibreService.FibreFactory(this.fibre));
			this.definitions = definitions;
		}

		public AvatarService.Request CombineParts(AvatarDefinition definition, BodyColorMaterialProperties bodycolor, List<ViewPart> parts, int maxAtlasDimension)
		{
			AvatarService.Request request = new AvatarService.Request();
			IEnumerator value = AvatarService.partsCombiner(request, definition, bodycolor ?? definition.BodyColor, parts, maxAtlasDimension);
			this.queue.Enqueue(new KeyValuePair<AvatarService.Request, IEnumerator>(request, value));
			return request;
		}

		public void ForceClearQueue()
		{
			this.queue.Clear();
		}

		public void CancelAllRequests()
		{
			throw new NotImplementedException("CancelAllRequests has not been implemented yet");
		}

		public AvatarDefinition GetDefinitionByName(string name)
		{
			AvatarDefinition result;
			for (int i = 0; i < this.definitions.Length; i++)
			{
				if (this.definitions[i].name == name)
				{
					result = this.definitions[i];
					return result;
				}
			}
			result = null;
			return result;
		}

		private static IEnumerator partsCombiner(AvatarService.Request request, AvatarDefinition definition, BodyColorMaterialProperties bodycolor, List<ViewPart> parts, int maxAtlasDimension)
		{
			AvatarService._partsCombiner_d__0 _partsCombiner_d__ = new AvatarService._partsCombiner_d__0(0);
			_partsCombiner_d__.request = request;
			_partsCombiner_d__.definition = definition;
			_partsCombiner_d__.bodycolor = bodycolor;
			_partsCombiner_d__.parts = parts;
			_partsCombiner_d__.maxAtlasDimension = maxAtlasDimension;
			return _partsCombiner_d__;
		}

		private IEnumerator<bool> fibre()
		{
			AvatarService._fibre_d__8 _fibre_d__ = new AvatarService._fibre_d__8(0);
			_fibre_d__.__4__this = this;
			return _fibre_d__;
		}
	}
}