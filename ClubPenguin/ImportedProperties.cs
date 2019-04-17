using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClubPenguin
{
	public class ImportedProperties : MonoBehaviour
	{
		[Serializable]
		public struct StringProperty
		{
			public string Key;

			public string Value;

			public StringProperty(string key, object value)
			{
				this.Key = key;
				this.Value = (string)value;
			}
		}

		[Serializable]
		public struct FloatProperty
		{
			public string Key;

			public float Value;

			public FloatProperty(string key, object value)
			{
				this.Key = key;
				this.Value = (float)value;
			}
		}

		[Serializable]
		public struct ColorProperty
		{
			public string Key;

			public Color Value;

			public ColorProperty(string key, object value)
			{
				this.Key = key;
				this.Value = new Color(((Vector4)value).x, ((Vector4)value).y, ((Vector4)value).z);
			}
		}

		[Serializable]
		public struct BooleanProperty
		{
			public string Key;

			public bool Value;

			public BooleanProperty(string key, object value)
			{
				this.Key = key;
				this.Value = (bool)value;
			}
		}

		public List<ImportedProperties.StringProperty> Strings;

		public List<ImportedProperties.FloatProperty> Floats;

		public List<ImportedProperties.ColorProperty> Colors;

		public List<ImportedProperties.BooleanProperty> Booleans;

		public void Parse(string[] keys, object[] values)
		{
			this.Strings = new List<ImportedProperties.StringProperty>();
			this.Floats = new List<ImportedProperties.FloatProperty>();
			this.Colors = new List<ImportedProperties.ColorProperty>();
			this.Booleans = new List<ImportedProperties.BooleanProperty>();
			for (int i = 0; i < keys.Length; i++)
			{
				string text = keys[i];
				object obj = values[i];
				Type type = obj.GetType();
				if (type == typeof(string))
				{
					this.Strings.Add(new ImportedProperties.StringProperty(text, obj));
				}
				else if (type == typeof(float))
				{
					this.Floats.Add(new ImportedProperties.FloatProperty(text, obj));
				}
				else if (type == typeof(bool))
				{
					this.Booleans.Add(new ImportedProperties.BooleanProperty(text, obj));
				}
				else
				{
					if (type != typeof(Vector4))
					{
						throw new UnityException(string.Format("Imported property {0} has invalid type {1}. Value: {2}!", text, type, obj));
					}
					this.Colors.Add(new ImportedProperties.ColorProperty(text, obj));
				}
			}
		}
	}
}