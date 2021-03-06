//
//  Copyright (C) 2010 Andoni Morales Alastruey
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301, USA.
//
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VAS.Core.Common;
using VAS.Core.Interfaces;
using VAS.Core.Store;

namespace VAS.Core.Serialization
{
	public sealed class Serializer : ISerializer
	{
		static readonly Serializer instance = new Serializer ();

		private Serializer ()
		{
			TypesMappings = new Dictionary<string, Type> ();
			NamespacesReplacements = new Dictionary<string, Tuple<string, string>> ();
		}

		public static Serializer Instance {
			get {
				return instance;
			}
		}

		/// <summary>
		/// Gets or sets a mapping of type names to types
		/// </summary>
		/// <value>The types mappings.</value>
		public static Dictionary<string, Type> TypesMappings {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a mapping of namespaces to replace
		/// </summary>
		/// <value>The types mappings.</value>
		public static Dictionary<string, Tuple<string, string>> NamespacesReplacements {
			get;
			set;
		}

		public void Save<T> (T obj, Stream stream,
							 SerializationType type = SerializationType.Json)
		{
			switch (type) {
			case SerializationType.Binary:
				BinaryFormatter formatter = new BinaryFormatter ();
				formatter.Serialize (stream, obj);
				break;
			case SerializationType.Xml:
				XmlSerializer xmlformatter = new XmlSerializer (typeof (T));
				xmlformatter.Serialize (stream, obj);
				break;
			case SerializationType.Json:
				StreamWriter sw = new StreamWriter (stream, Encoding.UTF8);
				sw.NewLine = "\n";
				sw.Write (JsonConvert.SerializeObject (obj, JsonSettings));
				sw.Flush ();
				break;
			}
		}

		public void Save<T> (T obj, string filepath,
							 SerializationType type = SerializationType.Json)
		{
			string tmpPath = filepath + ".tmp";
			using (Stream stream = new FileStream (tmpPath, FileMode.Create,
									   FileAccess.Write, FileShare.None)) {
				Save<T> (obj, stream, type);
			}
			if (App.Current.FileSystemManager.FileExists (filepath)) {
				File.Replace (tmpPath, filepath, null);
			} else {
				File.Move (tmpPath, filepath);
			}
		}

		public object Load (Type type, Stream stream,
							SerializationType serType = SerializationType.Json)
		{
			switch (serType) {
			case SerializationType.Binary:
				BinaryFormatter formatter = new BinaryFormatter ();
				return formatter.Deserialize (stream);
			case SerializationType.Xml:
				XmlSerializer xmlformatter = new XmlSerializer (type);
				return xmlformatter.Deserialize (stream);
			case SerializationType.Json:
				StreamReader sr = new StreamReader (stream, Encoding.UTF8);
				JsonSerializerSettings settings = JsonSettings;
				settings.ContractResolver = IsChangedContractResolver.Instance;
				return JsonConvert.DeserializeObject (sr.ReadToEnd (), type, settings);
			default:
				throw new Exception ();
			}
		}

		public T Load<T> (Stream stream,
						  SerializationType type = SerializationType.Json)
		{
			return (T)Load (typeof (T), stream, type);
		}

		public T Load<T> (string filepath,
						  SerializationType type = SerializationType.Json)
		{
			Stream stream = new FileStream (filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
			using (stream) {
				return Load<T> (stream, type);
			}
		}

		public T LoadSafe<T> (string filepath)
		{
			Stream stream = new FileStream (filepath, FileMode.Open,
								FileAccess.Read, FileShare.Read);
			using (stream) {
				try {
					return Load<T> (stream, SerializationType.Json);
				} catch (Exception e) {
					Log.Exception (e);
					stream.Seek (0, SeekOrigin.Begin);
					return Load<T> (stream, SerializationType.Binary);
				}
			}
		}

		public static JsonSerializerSettings JsonSettings {
			get {
				JsonSerializerSettings settings = new JsonSerializerSettings ();
				settings.Formatting = Formatting.Indented;
				settings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
				settings.TypeNameHandling = TypeNameHandling.Objects;
				settings.ObjectCreationHandling = ObjectCreationHandling.Replace;
				settings.Converters.Add (new VersionConverter ());
				settings.Converters.Add (new VASConverter (true));
				settings.Binder = new MigrationBinder (Serializer.TypesMappings, Serializer.NamespacesReplacements);
				settings.MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead;
				return settings;
			}
		}

		public T Clone<T> (T obj, SerializationType serType = SerializationType.Json)
		{
			T retStorable;

			switch (serType) {
			case SerializationType.Json:
				var jsonSettings = JsonSettings;
				jsonSettings.ContractResolver = ClonerContractResolver.Instance;
				using (Stream s = new MemoryStream ()) {
					using (StreamWriter sw = new StreamWriter (s, Encoding.UTF8)) {
						sw.NewLine = "\n";
						sw.Write (JsonConvert.SerializeObject (obj, jsonSettings));
						sw.Flush ();
						s.Seek (0, SeekOrigin.Begin);
						using (StreamReader sr = new StreamReader (s, Encoding.UTF8)) {
							retStorable = (T)JsonConvert.DeserializeObject (sr.ReadToEnd (), obj.GetType (), jsonSettings);
						}
					}
				}
				break;
			default:
				using (Stream s = new MemoryStream ()) {
					Save<T> (obj, s, serType);
					s.Seek (0, SeekOrigin.Begin);
					retStorable = Load<T> (s, serType);
				}
				break;
			}

			return retStorable;
		}
	}

	public class VASConverter : JsonConverter
	{
		/// The old key values to modifiers.
		static Dictionary<int, int> oldKeyValuesToModifier = new Dictionary<int, int> {
			//Shift_L
			{0xFFE1, 1 << 0},
			//Alt_L
			{0xFFE9, 1 << 3},
			//Control_L
			{0xFFE3, 1 << 2},
		};

		bool handleImages;

		public VASConverter () : this (true)
		{
		}

		public VASConverter (bool handleImages)
		{
			this.handleImages = handleImages;
		}

		public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value is Time) {
				Time time = value as Time;
				if (time != null) {
					writer.WriteValue (time.MSeconds);
				}
			} else if (value is Color) {
				Color color = value as Color;
				if (color != null) {
					writer.WriteValue (String.Format ("#{0}{1}{2}{3}",
						color.R.ToString ("X2"),
						color.G.ToString ("X2"),
						color.B.ToString ("X2"),
						color.A.ToString ("X2")));
				}
			} else if (value is Image) {
				Image image = value as Image;
				if (image != null) {
					writer.WriteValue (image.Serialize ());
				}
			} else if (value is HotKey) {
				HotKey hotkey = value as HotKey;
				if (hotkey != null) {
					writer.WriteValue (String.Format ("{0} {1}", hotkey.Key, hotkey.Modifier));
				}
			} else if (value is Point) {
				Point p = value as Point;
				if (p != null) {
					writer.WriteValue (String.Format ("{0} {1}",
						p.X.ToString (NumberFormatInfo.InvariantInfo),
						p.Y.ToString (NumberFormatInfo.InvariantInfo)));
				}
			} else {
			}
		}

		public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			object ret = null;

			if (reader.Value != null) {
				if (objectType == typeof (Time)) {
					if (reader.ValueType == typeof (Int64)) {
						ret = new Time ((int)(Int64)reader.Value);
					} else {
						ret = new Time ((Int32)reader.Value);
					}
				} else if (objectType == typeof (Color)) {
					string rgbStr = (string)reader.Value;
					ret = Color.Parse (rgbStr);
				} else if (objectType == typeof (Image)) {
					byte [] buf = Convert.FromBase64String ((string)reader.Value);
					ret = Image.Deserialize (buf);
				} else if (objectType == typeof (HotKey)) {
					string [] hk = ((string)reader.Value).Split (' ');
					ret = new HotKey { Key = int.Parse (hk [0]), Modifier = GetModifierValue (hk [1]) };
				} else if (objectType == typeof (Point)) {
					string [] ps = ((string)reader.Value).Split (' ');
					ret = new Point (double.Parse (ps [0], NumberFormatInfo.InvariantInfo),
						double.Parse (ps [1], NumberFormatInfo.InvariantInfo));
				}
			}
			if (ret is IChanged) {
				(ret as IChanged).IsChanged = false;
			}
			return ret;
		}

		public override bool CanConvert (Type objectType)
		{
			return (
				objectType == typeof (Time) ||
				objectType == typeof (Color) ||
				objectType == typeof (Point) ||
				objectType == typeof (HotKey) ||
				objectType == typeof (Image) && handleImages);
		}

		int GetModifierValue (string serializedValue)
		{
			int value = int.Parse (serializedValue);

			if (oldKeyValuesToModifier.ContainsKey (value)) {
				value = oldKeyValuesToModifier [value];
			}

			return value;
		}
	}

	/// <summary>
	// Cloner Contract Resolver. Serializes all writable properties, even those marked as JsonIgnore and only ignore
	// the properties marked as CloneIgnore or NonSerialized
	/// </summary>
	public sealed class ClonerContractResolver : DefaultContractResolver
	{
		private static readonly ClonerContractResolver instance = new ClonerContractResolver ();

		private ClonerContractResolver () { }

		public static ClonerContractResolver Instance {
			get {
				return instance;
			}
		}

		protected override JsonProperty CreateProperty (MemberInfo member, MemberSerialization memberSerialization)
		{
			var property = base.CreateProperty (member, memberSerialization);
			var attribs = property.AttributeProvider.GetAttributes (typeof (NonSerializedAttribute), true);
			var attribs2 = property.AttributeProvider.GetAttributes (typeof (CloneIgnoreAttribute), true);
			if (attribs.Count + attribs2.Count > 0 || !property.Writable) {
				property.Ignored = true;
			} else {
				property.Ignored = false;
			}
			return property;
		}
	}

	/// <summary>
	/// Is Changed Contract resolver, it sets the IsChanged property to false, used mainly for deserialize/Load
	/// </summary>
	public sealed class IsChangedContractResolver : DefaultContractResolver
	{
		private static readonly IsChangedContractResolver instance = new IsChangedContractResolver ();

		private IsChangedContractResolver () { }

		public static IsChangedContractResolver Instance {
			get {
				return instance;
			}
		}

		protected override JsonContract CreateContract (Type objectType)
		{
			JsonContract contract = base.CreateContract (objectType);

			if (typeof (IChanged).IsAssignableFrom (objectType)) {
				contract.OnDeserializedCallbacks.Add (
					(o, context) => { (o as IChanged).IsChanged = false; });
			}
			return contract;
		}
	}

	/// <summary>
	/// This binder allows mapping renamed types to their new names, making it possible to deserialize
	/// objects created with older versions of the software.
	/// </summary>
	public class MigrationBinder : DefaultSerializationBinder
	{
		readonly Dictionary<string, Type> cachedTypes;
		readonly Dictionary<string, Tuple<string, string>> namespacesReplacements;

		public MigrationBinder (Dictionary<string, Type> typesMappings, Dictionary<string, Tuple<string, string>> namespacesReplacements)
		{
			cachedTypes = typesMappings.ToDictionary (entry => entry.Key,
				entry => entry.Value);
			this.namespacesReplacements = namespacesReplacements;
		}

		/// <summary>
		/// Converts a formated type string to a real <see cref="Type"/>.
		/// </summary>
		/// <returns>The resolved type.</returns>
		/// <param name="assemblyTypeNameString">The string with the type name and assembly name.</param>
		public Type BindToType (string assemblyTypeNameString)
		{
			var assemblyTypeName = assemblyTypeNameString.Split (',');
			return BindToType (assemblyTypeName [1].Trim (), assemblyTypeName [0].Trim ());
		}

		public override Type BindToType (string assemblyName, string typeName)
		{
			Type type = null;
			string originalTypeName = typeName;

			// Try first with our cache, which is a combination of already resolved types and types mappings
			// configured by the user
			cachedTypes.TryGetValue (typeName, out type);
			if (type != null) {
				return type;
			}

			// Try without any replacemente first
			try {
				type = base.BindToType (assemblyName, typeName);
				if (type != null) {
					cachedTypes.Add (typeName, type);
					return type;
				}
			} catch (JsonSerializationException) {
			}

			// Try to replace the namespace if it matches with any of the replacements
			foreach (var kv in namespacesReplacements) {
				if (typeName.StartsWith (kv.Key)) {
					var newnamespace = kv.Value.Item1;
					typeName = typeName.Replace (kv.Key, newnamespace);
					assemblyName = kv.Value.Item2;
					break;
				}
			}

			// Try again with the replacements
			type = base.BindToType (assemblyName, typeName);
			if (type != null) {
				cachedTypes.Add (originalTypeName, type);
			}
			return type;
		}
	}
}
