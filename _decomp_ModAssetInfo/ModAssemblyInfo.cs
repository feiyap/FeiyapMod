using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ChronoArkMod.Plugin;
using UnityEngine;

namespace ChronoArkMod.ModData;

public class ModAssemblyInfo
{
	public ModInfo info;

	public Dictionary<string, Assembly> Assemblies = new Dictionary<string, Assembly>();

	public List<ChronoArkPlugin> Plugins = new List<ChronoArkPlugin>();

	public List<ModDefinition> ModDefinitions = new List<ModDefinition>();

	public GameObject baseGameObject;

	public ModAssemblyInfo(ModInfo modInfo)
	{
		info = modInfo;
	}

	public void UnLoad()
	{
		UnityEngine.Object.Destroy(baseGameObject);
		foreach (ChronoArkPlugin plugin in Plugins)
		{
			plugin.Dispose();
			Debug.Log("Plugin from " + info.id + "[" + plugin.PluginName + "] Disposed");
		}
		foreach (ModDefinition modDefinition in ModDefinitions)
		{
			modDefinition.UnLoad();
		}
		ModDefinitions.Clear();
		Plugins.Clear();
		Assemblies.Clear();
	}

	public void LoadModDef()
	{
		foreach (ModDefinition modDefinition in ModDefinitions)
		{
			modDefinition.LoadAll();
		}
	}

	public void AfterModGDELoaded()
	{
		foreach (ModDefinition modDefinition in ModDefinitions)
		{
			modDefinition.AfterModGDELoaded();
		}
	}

	public void init()
	{
		UnLoad();
		baseGameObject = new GameObject(info.id);
		UnityEngine.Object.DontDestroyOnLoad(baseGameObject);
		Directory.CreateDirectory(Path.Combine(info.DirectoryName, "Assemblies"));
		List<Type> list = new List<Type>();
		List<Type> list2 = new List<Type>();
		List<Type> list3 = new List<Type>();
		string text = Path.Combine(info.DirectoryName, "Assemblies");
		FileInfo[] files = new DirectoryInfo(text).GetFiles("*.dll");
		foreach (FileInfo fileInfo in files)
		{
			Assembly value = Assembly.Load(ModCompatPatcher.PatchAssemblyBytes(File.ReadAllBytes(fileInfo.FullName), fileInfo.Name, info.id, text));
			Assemblies.Add(fileInfo.Name, value);
		}
		foreach (Assembly value2 in Assemblies.Values)
		{
			Type[] types = value2.GetTypes();
			foreach (Type type in types)
			{
				if (typeof(ChronoArkPlugin).IsAssignableFrom(type))
				{
					list.Add(type);
				}
				if (typeof(ChronoArkPluginMonoBehaviour).IsAssignableFrom(type))
				{
					list2.Add(type);
				}
				if (typeof(ModDefinition).IsAssignableFrom(type))
				{
					list3.Add(type);
				}
			}
		}
		foreach (Type item in list)
		{
			ChronoArkPlugin chronoArkPlugin = (ChronoArkPlugin)Activator.CreateInstance(item);
			if (chronoArkPlugin != null)
			{
				chronoArkPlugin.ModId = info.id;
				if (chronoArkPlugin.CreatorId.IsNullOrEmpty())
				{
					chronoArkPlugin.CreatorId = info.Author;
				}
				chronoArkPlugin.Initialize();
				Debug.Log("Plugin from " + info.id + "[" + chronoArkPlugin.PluginName + "] Initialized");
			}
			Plugins.Add(chronoArkPlugin);
		}
		foreach (Type item2 in list2)
		{
			ChronoArkPluginMonoBehaviour chronoArkPluginMonoBehaviour = (ChronoArkPluginMonoBehaviour)baseGameObject.AddComponent(item2);
			if (chronoArkPluginMonoBehaviour != null)
			{
				chronoArkPluginMonoBehaviour.ModId = info.id;
				if (chronoArkPluginMonoBehaviour.CreatorId.IsNullOrEmpty())
				{
					chronoArkPluginMonoBehaviour.CreatorId = info.Author;
				}
				Debug.Log("PluginMonoBehaviour from " + info.id + "[" + chronoArkPluginMonoBehaviour.PluginName + "] Awaked");
			}
		}
		foreach (Type item3 in list3)
		{
			ModDefinition singletonAs = item3.GetSingletonAs<ModDefinition>();
			if (singletonAs != null)
			{
				singletonAs.ModId = info.id;
			}
			ModDefinitions.Add(singletonAs);
		}
	}
}
You are not using the latest version of the tool, please update.
Latest version is '11.1.0.9782' (yours is '9.1.0.7988')
