using Disney.LaunchPadFramework;
using Disney.MobileNetwork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

namespace ClubPenguin.Avatar
{
	[DisallowMultipleComponent]
	public class AvatarModel : MonoBehaviour
	{
		public class Part
		{
			public readonly EquipmentModelDefinition Equipment;

			public readonly int Index;

			public readonly DCustomEquipmentDecal[] Decals;

			public Part(EquipmentModelDefinition equipment, int index, DCustomEquipmentDecal[] decals)
			{
				this.Equipment = equipment;
				this.Index = index;
				this.Decals = decals;
			}
		}

		public class ApplyResult
		{
			public DCustomEquipment CustomEquipmentApplied;

			public EquipmentModelDefinition EquipmentDefinitionApplied;

			public HashSet<AvatarModel.Part> PartsAdded;

			public HashSet<AvatarModel.Part> PartsEjected;

			public HashSet<EquipmentModelDefinition> EquipmentEjected;
		}

		private sealed class _IterateParts_d__0 : IEnumerable<AvatarModel.Part>, IEnumerable, IEnumerator<AvatarModel.Part>, IEnumerator, IDisposable
		{
			private AvatarModel.Part __2__current;

			private int __1__state;

			private int __l__initialThreadId;

			public AvatarModel __4__this;

			public int _i_5__1;

			public int _j_5__2;

			public AvatarModel.Part _part_5__3;

			AvatarModel.Part IEnumerator<AvatarModel.Part>.Current
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

			IEnumerator<AvatarModel.Part> IEnumerable<AvatarModel.Part>.GetEnumerator()
			{
				AvatarModel._IterateParts_d__0 _IterateParts_d__;
				if (Thread.CurrentThread.ManagedThreadId == this.__l__initialThreadId && this.__1__state == -2)
				{
					this.__1__state = 0;
					_IterateParts_d__ = this;
				}
				else
				{
					_IterateParts_d__ = new AvatarModel._IterateParts_d__0(0);
					_IterateParts_d__.__4__this = this.__4__this;
				}
				return _IterateParts_d__;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((System.Collections.Generic.IEnumerable<ClubPenguin.Avatar.AvatarModel.Part>)this).GetEnumerator();
			}

			bool IEnumerator.MoveNext()
			{
				switch (this.__1__state)
				{
				case 0:
					this.__1__state = -1;
					this._i_5__1 = 0;
					goto IL_C3;
				case 1:
					this.__1__state = -1;
					break;
				default:
					goto IL_DE;
				}
				IL_8E:
				this._j_5__2++;
				IL_9D:
				bool result;
				if (this._j_5__2 >= this.__4__this.ColumnMax)
				{
					this._i_5__1++;
				}
				else
				{
					this._part_5__3 = this.__4__this.parts[this._i_5__1, this._j_5__2];
					if (this._part_5__3 != null)
					{
						this.__2__current = this._part_5__3;
						this.__1__state = 1;
						result = true;
						return result;
					}
					goto IL_8E;
				}
				IL_C3:
				if (this._i_5__1 < this.__4__this.RowMax)
				{
					this._j_5__2 = 0;
					goto IL_9D;
				}
				IL_DE:
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

			public _IterateParts_d__0(int __1__state)
			{
				this.__1__state = __1__state;
				this.__l__initialThreadId = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class __c__DisplayClass8
		{
			public AvatarModel __4__this;

			public AvatarModel.Part modelPart;

			public bool _GetConnectedParts_b__7(AvatarModel.Part p)
			{
				return p.Equipment != null && p != this.modelPart;
			}
		}

		public int LodLevel;

		public string AvatarDefinitionName;

		private AvatarDefinition definition;

		private Color beakColor;

		private Color bellyColor;

		private Color bodyColor;

		private AvatarModel.Part[,] parts;

		private readonly HashSet<EquipmentModelDefinition> equipmentList = new HashSet<EquipmentModelDefinition>();

		public readonly int ColumnMax = Enum.GetValues(typeof(EquipmentPartType)).Length;

		public event Action<int, int, AvatarModel.Part, AvatarModel.Part> PartChanged;

		public event Action<IEnumerable<AvatarModel.ApplyResult>> OutfitSet;

		public event System.Action ColorChanged;

		public event Action<EquipmentModelDefinition> EquipmentEjected;

		public AvatarDefinition Definition
		{
			get
			{
				if (this.definition == null)
				{
					this.definition = Service.Get<AvatarService>().GetDefinitionByName(this.AvatarDefinitionName);
				}
				return this.definition;
			}
		}

		public Color BeakColor
		{
			get
			{
				return this.beakColor;
			}
			set
			{
				if (this.beakColor != value)
				{
					this.beakColor = value;
					if (this.ColorChanged != null)
					{
						this.ColorChanged();
					}
				}
			}
		}

		public Color BellyColor
		{
			get
			{
				return this.bellyColor;
			}
			set
			{
				if (this.bellyColor != value)
				{
					this.bellyColor = value;
					if (this.ColorChanged != null)
					{
						this.ColorChanged();
					}
				}
			}
		}

		public Color BodyColor
		{
			get
			{
				return this.bodyColor;
			}
			set
			{
				if (this.bodyColor != value)
				{
					this.bodyColor = value;
					if (this.ColorChanged != null)
					{
						this.ColorChanged();
					}
				}
			}
		}

		public int RowMax
		{
			get
			{
				return this.Definition.Slots.Length;
			}
		}

		public AvatarModel.Part this[int slotIndex, int partIndex]
		{
			get
			{
				return this.parts[slotIndex, partIndex];
			}
		}

		public IEnumerable<EquipmentModelDefinition> Equipment
		{
			get
			{
				return this.equipmentList;
			}
		}

		public AvatarModel.Part GetPart(int slotIndex, EquipmentPartType partType)
		{
			return this.parts[slotIndex, (int)partType];
		}

		private AvatarModel.Part setPart(int slotIndex, EquipmentPartType partType, AvatarModel.Part newPart)
		{
			AvatarModel.Part part = this.GetPart(slotIndex, partType);
			this.parts[slotIndex, (int)partType] = newPart;
			return part;
		}

		public bool TryGetEquippedPart(int slotIndex, EquipmentPartType partType, out AvatarModel.Part outPart)
		{
			outPart = this.GetPart(slotIndex, partType);
			return outPart != null && outPart.Equipment != null;
		}

		public EquipmentModelDefinition.Part GetPartDefinition(AvatarModel.Part part)
		{
			return part.Equipment.Parts[part.Index];
		}

		public bool IsRequiredPart(AvatarModel.Part part)
		{
			return this.GetPartDefinition(part).Required;
		}

		public IEnumerable<AvatarModel.Part> IterateParts()
		{
			AvatarModel._IterateParts_d__0 _IterateParts_d__ = new AvatarModel._IterateParts_d__0(-2);
			_IterateParts_d__.__4__this = this;
			return _IterateParts_d__;
		}

		public IEnumerable<AvatarModel.Part> GetConnectedParts(AvatarModel.Part modelPart)
		{
			AvatarModel.__c__DisplayClass8 __c__DisplayClass = new AvatarModel.__c__DisplayClass8();
			__c__DisplayClass.modelPart = modelPart;
			__c__DisplayClass.__4__this = this;
			EquipmentModelDefinition equipment = __c__DisplayClass.modelPart.Equipment;
			EquipmentModelDefinition.Part[] source = equipment.Parts;
			return source.Select(new Func<EquipmentModelDefinition.Part, AvatarModel.Part>(this._GetConnectedParts_b__6)).Where(new Func<AvatarModel.Part, bool>(__c__DisplayClass._GetConnectedParts_b__7));
		}

		public void Awake()
		{
			this.parts = new AvatarModel.Part[this.RowMax, this.ColumnMax];
			for (int i = 0; i < this.RowMax; i++)
			{
				this.parts[i, 0] = new AvatarModel.Part(null, i, null);
			}
			this.bodyColor = this.Definition.BodyColor.BodyColor;
			this.beakColor = this.Definition.BodyColor.BeakColor;
			this.bellyColor = this.Definition.BodyColor.BellyColor;
		}

		public IEnumerable<AvatarModel.ApplyResult> ApplyOutfit(DCustomOutfit outfit)
		{
			List<AvatarModel.ApplyResult> list = new List<AvatarModel.ApplyResult>();
			DCustomEquipment[] equipment = outfit.Equipment;
			for (int i = 0; i < equipment.Length; i++)
			{
				DCustomEquipment customEqToApply = equipment[i];
				list.Add(this.ApplyEquipment(customEqToApply));
			}
			if (this.OutfitSet != null)
			{
				this.OutfitSet(list);
			}
			return list;
		}

		public AvatarModel.ApplyResult ApplyEquipment(DCustomEquipment customEqToApply)
		{
			EquipmentModelDefinition equipmentDefinition = this.Definition.GetEquipmentDefinition(customEqToApply);
			AvatarModel.ApplyResult applyResult = new AvatarModel.ApplyResult();
			applyResult.CustomEquipmentApplied = customEqToApply;
			applyResult.EquipmentDefinitionApplied = equipmentDefinition;
			applyResult.PartsAdded = new HashSet<AvatarModel.Part>();
			if (equipmentDefinition != null)
			{
				this.ejectReplacedEquipment(equipmentDefinition, applyResult);
				this.applyParts(equipmentDefinition, customEqToApply, applyResult.PartsAdded);
				this.ejectRemainingParts(applyResult.PartsEjected);
				this.equipmentList.Add(equipmentDefinition);
			}
			return applyResult;
		}

		private void ejectReplacedEquipment(EquipmentModelDefinition eqDefToApply, AvatarModel.ApplyResult result)
		{
			HashSet<AvatarModel.Part> partsEjected = null;
			HashSet<EquipmentModelDefinition> hashSet = null;
			if (this.GetEquipmentToEject(eqDefToApply, out partsEjected, out hashSet))
			{
				foreach (EquipmentModelDefinition current in hashSet)
				{
					this.equipmentList.Remove(current);
					if (this.EquipmentEjected != null)
					{
						try
						{
							this.EquipmentEjected(current);
						}
						catch (Exception ex)
						{
							Log.LogException(this, ex);
						}
					}
				}
			}
			result.PartsEjected = partsEjected;
			result.EquipmentEjected = hashSet;
		}

		private void applyParts(EquipmentModelDefinition eqDefToApply, DCustomEquipment customEqToApply, HashSet<AvatarModel.Part> partsAdded)
		{
			for (int i = 0; i < eqDefToApply.Parts.Length; i++)
			{
				DCustomEquipmentDecal[] decals = null;
				EquipmentModelDefinition.Part newPartDef = eqDefToApply.Parts[i];
				if (customEqToApply.Parts != null)
				{
					for (int j = 0; j < customEqToApply.Parts.Length; j++)
					{
						if (customEqToApply.Parts[j].SlotIndex == newPartDef.SlotIndex)
						{
							decals = customEqToApply.Parts[j].Decals;
							break;
						}
					}
				}
				AvatarModel.Part part = new AvatarModel.Part(eqDefToApply, i, decals);
				this.changePart(newPartDef, part);
				partsAdded.Add(part);
			}
		}

		private void ejectRemainingParts(HashSet<AvatarModel.Part> partsToEject)
		{
			foreach (AvatarModel.Part current in partsToEject)
			{
				EquipmentModelDefinition.Part partDefinition = this.GetPartDefinition(current);
				AvatarModel.Part part = this.GetPart(partDefinition.SlotIndex, partDefinition.PartType);
				if (part == current)
				{
					this.changePart(partDefinition, null);
				}
			}
		}

		public bool GetEquipmentToEject(EquipmentModelDefinition eqToApply, out HashSet<AvatarModel.Part> ejectedParts, out HashSet<EquipmentModelDefinition> ejectedEquipment)
		{
			ejectedParts = new HashSet<AvatarModel.Part>();
			ejectedEquipment = new HashSet<EquipmentModelDefinition>();
			EquipmentModelDefinition.Part[] array = eqToApply.Parts;
			for (int i = 0; i < array.Length; i++)
			{
				EquipmentModelDefinition.Part part = array[i];
				AvatarModel.Part modelPart = null;
				bool flag = this.TryGetEquippedPart(part.SlotIndex, part.PartType, out modelPart);
				if (!flag)
				{
					flag = (part.PartType == EquipmentPartType.BaseMeshAddition && this.TryGetEquippedPart(part.SlotIndex, EquipmentPartType.BaseMeshReplacement, out modelPart));
				}
				if (!flag)
				{
					flag = (part.PartType == EquipmentPartType.BaseMeshReplacement && this.TryGetEquippedPart(part.SlotIndex, EquipmentPartType.BaseMeshAddition, out modelPart));
				}
				if (flag)
				{
					this.ejectPart(ejectedParts, ejectedEquipment, modelPart);
				}
			}
			return ejectedParts.Count > 0;
		}

		private void ejectPart(HashSet<AvatarModel.Part> ejectedParts, HashSet<EquipmentModelDefinition> ejectedEquipment, AvatarModel.Part modelPart)
		{
			ejectedParts.Add(modelPart);
			IEnumerable<AvatarModel.Part> connectedParts = this.GetConnectedParts(modelPart);
			if (this.IsRequiredPart(modelPart))
			{
				foreach (AvatarModel.Part current in connectedParts)
				{
					ejectedParts.Add(current);
				}
			}
			if (AvatarModel.areAllPartsRemoved(connectedParts, ejectedParts))
			{
				ejectedEquipment.Add(modelPart.Equipment);
			}
		}

		private static bool areAllPartsRemoved(IEnumerable<AvatarModel.Part> connectedModelParts, HashSet<AvatarModel.Part> ejectedParts)
		{
			bool result = true;
			foreach (AvatarModel.Part current in connectedModelParts)
			{
				if (!ejectedParts.Contains(current))
				{
					result = false;
					break;
				}
			}
			return result;
		}

		public bool RemoveEquipment(string equipmentName)
		{
			bool result = false;
			EquipmentModelDefinition equipmentDefinition = this.Definition.GetEquipmentDefinition(equipmentName);
			if (equipmentDefinition != null)
			{
				if (this.equipmentList.Contains(equipmentDefinition))
				{
					this.removeEquipment(equipmentDefinition);
					result = true;
				}
			}
			else
			{
				Log.LogErrorFormatted(this, "Trying to remove unknown equipment '{0}' from avatar model {1}", new object[]
				{
					equipmentName,
					base.name
				});
			}
			return result;
		}

		public void ClearAllEquipment()
		{
			this.equipmentList.Clear();
			for (int i = 0; i < this.RowMax; i++)
			{
				this.changePart(i, 0, new AvatarModel.Part(null, i, null));
				for (int j = 1; j < this.ColumnMax; j++)
				{
					this.changePart(i, j, null);
				}
			}
		}

		private void removeEquipment(EquipmentModelDefinition eq)
		{
			this.equipmentList.Remove(eq);
			for (int i = 0; i < eq.Parts.Length; i++)
			{
				int slotIndex = eq.Parts[i].SlotIndex;
				int partType = (int)eq.Parts[i].PartType;
				AvatarModel.Part part = this.parts[slotIndex, partType];
				if (part != null && part.Equipment == eq)
				{
					this.changePart(slotIndex, partType, null);
				}
			}
		}

		private void changePart(EquipmentModelDefinition.Part newPartDef, AvatarModel.Part newPart)
		{
			int slotIndex = newPartDef.SlotIndex;
			int partType = (int)newPartDef.PartType;
			this.changePart(slotIndex, partType, newPart);
		}

		private void changePart(int slotIndex, int partIndex, AvatarModel.Part newPart)
		{
			AvatarModel.Part arg = this.setPart(slotIndex, (EquipmentPartType)partIndex, newPart ?? ((partIndex == 0) ? new AvatarModel.Part(null, slotIndex, null) : null));
			if (this.PartChanged != null)
			{
				try
				{
					this.PartChanged(slotIndex, partIndex, arg, this.GetPart(slotIndex, (EquipmentPartType)partIndex));
				}
				catch (Exception ex)
				{
					Log.LogException(this, ex);
					throw;
				}
			}
		}

		private AvatarModel.Part _GetConnectedParts_b__6(EquipmentModelDefinition.Part p)
		{
			return this.GetPart(p.SlotIndex, p.PartType);
		}
	}
}