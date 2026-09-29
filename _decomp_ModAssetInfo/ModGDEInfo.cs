using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ChronoArkMod.ModEditor;
using GameDataEditor;
using Newtonsoft.Json;
using UnityEngine;

namespace ChronoArkMod.ModData;

public class ModGDEInfo
{
	public abstract class GDEChangeDelBase
	{
		public abstract bool Match(string key, string field);

		public virtual T Get<T>(string key, string field, T ori)
		{
			if (!Match(key, field))
			{
				return ori;
			}
			return DelApply(ori);
		}

		public abstract T DelApply<T>(T ori);
	}

	public abstract class GDEChangeDel_FromAttribute : GDEChangeDelBase
	{
		public string myKey;

		public string myField;

		public Type ModItemKeysType;

		public ModDefinition modDefinition;

		public List<string> Keys = new List<string>();

		public override bool Match(string key, string field)
		{
			if (MatchKey(key))
			{
				return field == myField;
			}
			return false;
		}

		public bool MatchKey(string key)
		{
			if (Keys.Count == 0)
			{
				Keys.Add(myKey);
				FieldInfo field = typeof(GDEItemKeys).GetField(myKey, BindingFlags.Static | BindingFlags.Public);
				if (field != null)
				{
					Keys.Add(field.GetValue(null).ToString());
				}
				field = ModItemKeysType?.GetField(myKey, BindingFlags.Static | BindingFlags.Public);
				if (field != null)
				{
					Keys.Add(field.GetValue(null).ToString());
				}
			}
			return Keys.Contains(key);
		}
	}

	public class GDEChangeDel_FromMethod : GDEChangeDel_FromAttribute
	{
		public MethodInfo myMethod;

		public override T DelApply<T>(T ori)
		{
			if (myMethod != null && typeof(T) == myMethod.ReturnType && myMethod.GetParameters().Length == 1 && typeof(T) == myMethod.GetParameters().FirstOrDefault()?.ParameterType)
			{
				return (T)myMethod.Invoke(modDefinition, new object[1] { ori });
			}
			return ori;
		}
	}

	public class GDEChangeDel_FromProperty : GDEChangeDel_FromAttribute
	{
		public PropertyInfo myProperty;

		public override T DelApply<T>(T ori)
		{
			if (myProperty != null && typeof(T) == myProperty.PropertyType)
			{
				return (T)myProperty.GetMethod.Invoke(modDefinition, null);
			}
			return ori;
		}
	}

	public class GDEChangeDel_FromField : GDEChangeDel_FromAttribute
	{
		public FieldInfo myFieldInfo;

		public override T DelApply<T>(T ori)
		{
			if (myFieldInfo != null && typeof(T) == myFieldInfo.FieldType)
			{
				return (T)myFieldInfo.GetValue(modDefinition);
			}
			return ori;
		}
	}

	public class GDEChangeDel<T> : GDEChangeDelBase
	{
		public Func<T, T> Del;

		public string mykey;

		public string myfield;

		public GDEChangeDel(string key, string field, Func<T, T> del)
		{
			mykey = key;
			myfield = field;
			Del = del;
		}

		public GDEChangeDel(string key, string field, T newvalue)
		{
			mykey = key;
			myfield = field;
			Del = (T x) => newvalue;
		}

		public GDEChangeDel()
		{
		}

		public override _T DelApply<_T>(_T ori)
		{
			if (typeof(_T) == typeof(T))
			{
				return (_T)(object)Del((T)(object)ori);
			}
			return ori;
		}

		public override bool Match(string key, string field)
		{
			if (key == mykey)
			{
				return field == myfield;
			}
			return false;
		}
	}

	public enum LoadingType
	{
		Add,
		Replace,
		AddItemToList,
		RemoveItemFromList,
		Remove
	}

	public ModInfo info;

	public Dictionary<string, object> gdatas = new Dictionary<string, object>();

	public List<string> Add = new List<string>();

	public List<string> Added = new List<string>();

	public List<string> Replace = new List<string>();

	public List<string> AddItemToList = new List<string>();

	public List<string> RemoveItemFromList = new List<string>();

	public List<string> Remove = new List<string>();

	public Dictionary<string, string> key_schema = new Dictionary<string, string>();

	public Dictionary<string, object> Removed = new Dictionary<string, object>();

	public List<GDEChangeDelBase> gDEChangeDelBases = new List<GDEChangeDelBase>();

	public T GDEChangeDelGet<T>(string key, string field, T ori)
	{
		T val = ori;
		foreach (GDEChangeDelBase gDEChangeDelBasis in gDEChangeDelBases)
		{
			val = gDEChangeDelBasis.Get(key, field, val);
		}
		return val;
	}

	public ModGDEInfo(ModInfo modinfo)
	{
		info = modinfo;
	}

	public void init()
	{
		Directory.CreateDirectory(Path.Combine(info.DirectoryName, "gdata"));
		UnLoad();
		LoadAdd();
		LoadRemove();
		LoadReplace();
		LoadAddList();
		LoadRemoveList();
	}

	public void UnLoad()
	{
		foreach (string item in Add)
		{
			if (GDEDataManager.masterData != null)
			{
				GDEDataManager.masterData.Remove(item);
			}
		}
		foreach (string key in Removed.Keys)
		{
			GDEDataManager.masterData.TryAddOrUpdateValue(key, Removed[key]);
		}
		Removed.Clear();
		Add.Clear();
		Remove.Clear();
		Replace.Clear();
		AddItemToList.Clear();
		RemoveItemFromList.Clear();
		gdatas.Clear();
		key_schema.Clear();
		gDEChangeDelBases.Clear();
	}

	public void UpdateSchemaKeyDict()
	{
		List<string> list = new List<string>();
		foreach (string item in Add)
		{
			if (GDEDataManager.masterData.ContainsKey(item) && !Added.Contains(item))
			{
				Debug.Log("Cant add [" + item + "] of mod [" + info.id + "]");
				list.Add(item);
			}
		}
		Added.Clear();
		foreach (string item2 in Add)
		{
			if (!list.Contains(item2))
			{
				string text = key_schema[item2];
				if (GDEDataManager.Get("_gdeSchema_" + text, out var data))
				{
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					dictionary.Merge(data);
					dictionary.TryAddOrUpdateValue("_gdeSchema", text);
					GDEDataManager.masterData.TryAddOrUpdateValue(item2, dictionary);
				}
				else
				{
					Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
					dictionary2.TryAddOrUpdateValue("_gdeSchema", text);
					GDEDataManager.masterData.TryAddOrUpdateValue(item2, dictionary2);
				}
				Added.Add(item2);
			}
		}
		foreach (string item3 in Remove)
		{
			if (GDEDataManager.masterData.ContainsKey(item3))
			{
				Removed.TryAddOrUpdateValue(item3, GDEDataManager.masterData[item3]);
			}
			GDEDataManager.masterData.Remove(item3);
		}
	}

	private void LoadAdd()
	{
		Directory.CreateDirectory(Path.Combine(info.DirectoryName, "gdata", "Add"));
		DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(info.DirectoryName, "gdata", "Add"));
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		FileInfo[] files = directoryInfo.GetFiles("*.json");
		for (int i = 0; i < files.Length; i++)
		{
			string json = File.ReadAllText(files[i].FullName);
			dictionary.Merge(Json.Deserialize(json) as Dictionary<string, object>);
		}
		gdatas.Merge(dictionary);
		foreach (string key in dictionary.Keys)
		{
			try
			{
				Add.Add(key);
				key_schema.Add(key, (dictionary[key] as Dictionary<string, object>)["_gdeSchema"] as string);
			}
			catch
			{
				Debug.Log(key);
			}
		}
	}

	private void LoadRemove()
	{
		Directory.CreateDirectory(Path.Combine(info.DirectoryName, "gdata", "Remove"));
		DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(info.DirectoryName, "gdata", "Remove"));
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		FileInfo[] files = directoryInfo.GetFiles("*.json");
		for (int i = 0; i < files.Length; i++)
		{
			string json = File.ReadAllText(files[i].FullName);
			dictionary.Merge(Json.Deserialize(json) as Dictionary<string, object>);
		}
		foreach (string key in dictionary.Keys)
		{
			Remove.Add(key);
		}
	}

	private void LoadReplace()
	{
		Directory.CreateDirectory(Path.Combine(info.DirectoryName, "gdata", "Replace"));
		DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(info.DirectoryName, "gdata", "Replace"));
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		FileInfo[] files = directoryInfo.GetFiles("*.json");
		for (int i = 0; i < files.Length; i++)
		{
			string json = File.ReadAllText(files[i].FullName);
			dictionary.Merge(Json.Deserialize(json) as Dictionary<string, object>);
		}
		gdatas.Merge(dictionary);
		foreach (string key in dictionary.Keys)
		{
			Replace.Add(key);
			key_schema.Add(key, (dictionary[key] as Dictionary<string, object>)["_gdeSchema"] as string);
		}
	}

	private void LoadAddList()
	{
		Directory.CreateDirectory(Path.Combine(info.DirectoryName, "gdata", "AddItemToList"));
		DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(info.DirectoryName, "gdata", "AddItemToList"));
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		FileInfo[] files = directoryInfo.GetFiles("*.json");
		for (int i = 0; i < files.Length; i++)
		{
			string json = File.ReadAllText(files[i].FullName);
			dictionary.Merge(Json.Deserialize(json) as Dictionary<string, object>);
		}
		gdatas.Merge(dictionary);
		foreach (string key in dictionary.Keys)
		{
			AddItemToList.Add(key);
			key_schema.Add(key, (dictionary[key] as Dictionary<string, object>)["_gdeSchema"] as string);
		}
	}

	private void LoadRemoveList()
	{
		Directory.CreateDirectory(Path.Combine(info.DirectoryName, "gdata", "RemoveItemFromList"));
		DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(info.DirectoryName, "gdata", "RemoveItemFromList"));
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		FileInfo[] files = directoryInfo.GetFiles("*.json");
		for (int i = 0; i < files.Length; i++)
		{
			string json = File.ReadAllText(files[i].FullName);
			dictionary.Merge(Json.Deserialize(json) as Dictionary<string, object>);
		}
		gdatas.Merge(dictionary);
		foreach (string key in dictionary.Keys)
		{
			RemoveItemFromList.Add(key);
			key_schema.Add(key, (dictionary[key] as Dictionary<string, object>)["_gdeSchema"] as string);
		}
	}

	public void LoadModEditorJson()
	{
		Directory.CreateDirectory(Path.Combine(info.DirectoryName, "gdata", "ModEditorJson"));
		DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(info.DirectoryName, "gdata", "ModEditorJson"));
		new Dictionary<string, object>();
		FileInfo[] files = directoryInfo.GetFiles("*.json");
		for (int i = 0; i < files.Length; i++)
		{
			ModEditorChangeDel modEditorChangeDel = JsonConvert.DeserializeObject<ModEditorChangeDel>(File.ReadAllText(files[i].FullName));
			modEditorChangeDel.Init(info);
			if (gDEChangeDelBases == null)
			{
				gDEChangeDelBases = new List<GDEChangeDelBase>();
			}
			gDEChangeDelBases.Add(modEditorChangeDel);
		}
	}
}
You are not using the latest version of the tool, please update.
Latest version is '11.1.0.9782' (yours is '9.1.0.7988')
