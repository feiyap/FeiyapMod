using System;
using System.Collections.Generic;
using ChronoArkMod.ModData;
using GameDataEditor;
using UnityEngine;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace ChronoArkMod.Addressable;

public class ModResourceLocator_Object : IResourceLocator
{
	private string id;

	private int Seed;

	public string LocatorId => "ModResourceLocator_Object" + info.id;

	public virtual IEnumerable<object> Keys => new object[0];

	private ModInfo info => ModManager.getModInfo(id);

	public ModResourceLocator_Object(string id)
	{
		this.id = id;
		Seed = UnityEngine.Random.Range(0, int.MaxValue);
	}

	public bool Locate(object key, Type type, out IList<IResourceLocation> locations)
	{
		locations = new List<IResourceLocation>();
		if (key is string)
		{
			string text = (string)key;
			if (info.assetInfo.ModObjectInfos.ContainsKey(text))
			{
				ResourceLocationBase resourceLocationBase = new ResourceLocationBase("ModObject", text + Seed, typeof(ModResourceProvider_Object).FullName + info.id, type);
				resourceLocationBase.Data = info.assetInfo.ModObjectInfos[text];
				if (resourceLocationBase.Data.GetType().GetGenericArguments()[0].IsAssignableFrom(type))
				{
					locations = new List<IResourceLocation> { resourceLocationBase };
					return true;
				}
				return false;
			}
		}
		return false;
	}

	public static List<T> GetCustomList<T>(string key, string field, List<T> defaultVal) where T : IGDEData
	{
		List<T> list = defaultVal;
		try
		{
			if (HasKeyField(key, field))
			{
				list = new List<T>();
				List<string> stringList = GDEDataManager.GetStringList(key, field);
				if (stringList != null)
				{
					foreach (string item in stringList)
					{
						list.Add((T)Activator.CreateInstance(typeof(T), item));
					}
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return list;
	}

	public static bool HasKeyField(string key, string field)
	{
		if (GDEDataManager.ModifiedData.TryGetValue(key, out var value))
		{
			return value.ContainsKey(field);
		}
		return false;
	}
}
You are not using the latest version of the tool, please update.
Latest version is '11.1.0.9782' (yours is '9.1.0.7988')
