using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using ChronoArkMod.ModData.Settings;
using GameDataEditor;
using Newtonsoft.Json;
using Steamworks;
using UnityEngine;

namespace ChronoArkMod.ModData;

public class ModInfo : IEquatable<ModInfo>
{
	public string Author = "";

	public string Version = "";

	private string _Description = "";

	public string id;

	public string Cover;

	public Sprite _CoverSprite;

	public string DefaultAssetBundlePath;

	public List<string> TagList = new List<string>();

	public List<string> Dependencies = new List<string>();

	public List<SettingEntry> ModSettingEntries = new List<SettingEntry>();

	public string DirectoryName;

	private string _Title = "";

	public Dictionary<string, object> settings = new Dictionary<string, object>();

	public bool NeedRestartWhenSettingChanged;

	public bool NeedReloadAllWhenEnabled;

	public bool NeedRestartWhenEnabled;

	public Dictionary<string, object> info_dict = new Dictionary<string, object>();

	public string WorkShopId = "";

	public string Uploader = "";

	public ERemoteStoragePublishedFileVisibility Visibility;

	public string ChangeNote = "";

	public bool OnlyUploadFiles;

	public bool FromWorkShop;

	private ModAssetInfo _assetInfo;

	private ModGDEInfo _gdeinfo;

	private ModAudioInfo _audioinfo;

	private ModAssemblyInfo _assemblyInfo;

	private ModLocalizationInfo _localizationInfo;

	public string Description
	{
		get
		{
			return localizationInfo.SyetemLocalizationUpdate(_Description);
		}
		set
		{
			_Description = value;
		}
	}

	public Sprite CoverSprite
	{
		get
		{
			if (_CoverSprite == null)
			{
				_CoverSprite = GetCoverSprite();
			}
			return _CoverSprite;
		}
	}

	public string Title
	{
		get
		{
			return localizationInfo.SyetemLocalizationUpdate(_Title);
		}
		set
		{
			_Title = value;
		}
	}

	public bool isUploaderPlaying
	{
		get
		{
			if (!SteamManager.Initialized)
			{
				return false;
			}
			string text = SteamUser.GetSteamID().ToString();
			string personaName = SteamFriends.GetPersonaName();
			if (Uploader != text && Uploader != personaName)
			{
				return false;
			}
			return true;
		}
	}

	public string modSettingsPath => Path.Combine(Application.persistentDataPath, "Mod", id + ".json");

	public ModAssetInfo assetInfo
	{
		get
		{
			if (_assetInfo == null)
			{
				_assetInfo = new ModAssetInfo(this);
			}
			return _assetInfo;
		}
	}

	public ModGDEInfo gdeinfo
	{
		get
		{
			if (_gdeinfo == null)
			{
				_gdeinfo = new ModGDEInfo(this);
			}
			return _gdeinfo;
		}
	}

	public ModAudioInfo audioinfo
	{
		get
		{
			if (_audioinfo == null)
			{
				_audioinfo = new ModAudioInfo(this);
			}
			return _audioinfo;
		}
	}

	public ModAssemblyInfo assemblyInfo
	{
		get
		{
			if (_assemblyInfo == null)
			{
				_assemblyInfo = new ModAssemblyInfo(this);
			}
			return _assemblyInfo;
		}
	}

	public ModLocalizationInfo localizationInfo
	{
		get
		{
			if (_localizationInfo == null)
			{
				_localizationInfo = new ModLocalizationInfo(this);
			}
			return _localizationInfo;
		}
	}

	public void SaveWorkShopId()
	{
		info_dict.TryAddOrUpdateValue("WorkShopId", WorkShopId);
		string contents = JsonHelper.FormatJson(JsonConvert.SerializeObject(info_dict));
		File.WriteAllText(Path.Combine(DirectoryName, "ChronoArkMod.json"), contents);
	}

	public void ReadModSetting()
	{
		if (File.Exists(modSettingsPath))
		{
			string textsettings = File.ReadAllText(modSettingsPath);
			DeserializeSettingsToEntries(textsettings);
		}
	}

	public static ModInfo Deserialize(string text)
	{
		ModInfo modInfo = new ModInfo();
		modInfo.info_dict = Json.Deserialize(text) as Dictionary<string, object>;
		modInfo.info_dict.TryGetString("id", out modInfo.id);
		modInfo.info_dict.TryGetString("Title", out modInfo._Title);
		modInfo.info_dict.TryGetString("Author", out modInfo.Author);
		modInfo.info_dict.TryGetString("Description", out modInfo._Description);
		modInfo.info_dict.TryGetString("Version", out modInfo.Version);
		modInfo.info_dict.TryGetString("Cover", out modInfo.Cover);
		modInfo.info_dict.TryGetString("Uploader", out modInfo.Uploader);
		modInfo.info_dict.TryGetString("DefaultAssetBundlePath", out modInfo.DefaultAssetBundlePath);
		modInfo.info_dict.TryGetStringList("TagList", out modInfo.TagList);
		if (modInfo.TagList == null)
		{
			modInfo.TagList = new List<string>();
		}
		modInfo.info_dict.TryGetStringList("Dependencies", out modInfo.Dependencies);
		if (modInfo.Dependencies == null)
		{
			modInfo.Dependencies = new List<string>();
		}
		modInfo.info_dict.TryGetBool("NeedRestartWhenSettingChanged", out modInfo.NeedRestartWhenSettingChanged);
		modInfo.info_dict.TryGetBool("NeedReloadAllWhenEnabled", out modInfo.NeedReloadAllWhenEnabled);
		modInfo.info_dict.TryGetBool("NeedRestartWhenEnabled", out modInfo.NeedRestartWhenEnabled);
		modInfo.info_dict.TryGetList("ModSettingEntries", out var value);
		modInfo.info_dict.TryGetString("WorkShopId", out modInfo.WorkShopId);
		modInfo.info_dict.TryGetBool("OnlyUploadFiles", out modInfo.OnlyUploadFiles);
		modInfo.info_dict.TryGetString("Visibility", out var value2);
		switch (value2)
		{
		case "Public":
			modInfo.Visibility = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic;
			break;
		case "Private":
			modInfo.Visibility = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPrivate;
			break;
		case "FriendsOnly":
			modInfo.Visibility = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityFriendsOnly;
			break;
		default:
			modInfo.Visibility = ERemoteStoragePublishedFileVisibility.k_ERemoteStoragePublishedFileVisibilityPublic;
			break;
		}
		modInfo.info_dict.TryGetString("ChangeNote", out modInfo.ChangeNote);
		if (value == null)
		{
			return modInfo;
		}
		foreach (object item in value)
		{
			Dictionary<string, object> variable = item as Dictionary<string, object>;
			variable.TryGetString("SettingType", out var value3);
			variable.TryGetString("SettingKey", out var value4);
			variable.TryGetString("DisplayName", out var value5);
			variable.TryGetString("Description", out var value6);
			switch (value3)
			{
			case "ToggleSetting":
			{
				variable.TryGetBool("InitValue", out var value15);
				modInfo.ModSettingEntries.Add(new ToggleSetting(value4, value5, value6, value15, modInfo.id));
				break;
			}
			case "SliderSetting":
			{
				variable.TryGetFloat("InitValue", out var value11);
				variable.TryGetFloat("Max", out var value12);
				variable.TryGetFloat("Min", out var value13);
				variable.TryGetFloat("StepSize", out var value14);
				modInfo.ModSettingEntries.Add(new SliderSetting(value4, value5, value6, value11, value13, value12, value14, modInfo.id));
				break;
			}
			case "DropdownSetting":
			{
				variable.TryGetInt("InitValue", out var value9);
				variable.TryGetStringList("Options", out var value10);
				modInfo.ModSettingEntries.Add(new DropdownSetting(value4, value5, value6, value9, modInfo.id, value10.ToArray()));
				break;
			}
			case "InputFieldSetting":
			{
				variable.TryGetString("InitValue", out var value8);
				modInfo.ModSettingEntries.Add(new InputFieldSetting(value4, value5, value6, value8, modInfo.id));
				break;
			}
			case "InputFieldSetting_Int":
			{
				variable.TryGetInt("InitValue", out var value7);
				modInfo.ModSettingEntries.Add(new InputFieldSetting_Int(value4, value5, value6, value7, modInfo.id));
				break;
			}
			}
		}
		return modInfo;
	}

	public Sprite GetCoverSprite()
	{
		try
		{
			if (File.Exists(Path.Combine(DirectoryName, Cover)))
			{
				Debug.Log(Path.Combine(DirectoryName, Cover));
				return Misc.CreatSprite(AssetGeneratingTools.LoadTexture(Path.Combine(DirectoryName, Cover)));
			}
		}
		catch
		{
		}
		return null;
	}

	public void DeserializeSettingsToEntries(string textsettings)
	{
		settings = Json.Deserialize(textsettings) as Dictionary<string, object>;
		if (settings == null)
		{
			settings = new Dictionary<string, object>();
		}
		SettingsToEntries();
	}

	public string SerializeSettingsFromEntries()
	{
		if (settings == null)
		{
			settings = new Dictionary<string, object>();
		}
		foreach (SettingEntry modSettingEntry in ModSettingEntries)
		{
			modSettingEntry.SaveToModSettings(settings);
		}
		return JsonHelper.FormatJson(Json.Serialize(settings));
	}

	public void SettingsToEntries()
	{
		foreach (SettingEntry modSettingEntry in ModSettingEntries)
		{
			modSettingEntry.RestoreFromModSettings(settings);
		}
	}

	public void SaveSetting()
	{
		string contents = SerializeSettingsFromEntries();
		File.WriteAllText(modSettingsPath, contents);
	}

	public SettingEntry GetSetting(string key)
	{
		foreach (SettingEntry modSettingEntry in ModSettingEntries)
		{
			if (modSettingEntry.Key == key)
			{
				return modSettingEntry;
			}
		}
		return null;
	}

	public T GetSetting<T>(string key) where T : SettingEntry
	{
		foreach (SettingEntry modSettingEntry in ModSettingEntries)
		{
			if (modSettingEntry.Key == key && modSettingEntry is T)
			{
				return modSettingEntry as T;
			}
		}
		return null;
	}

	public ModInfo()
	{
		ModSettingEntries = new List<SettingEntry>();
		Dependencies = new List<string>();
		TagList = new List<string>();
		settings = new Dictionary<string, object>();
	}

	public void LoadAtVeryBegining()
	{
		assemblyInfo.init();
		assetInfo.init();
	}

	public void Load()
	{
		if (assemblyInfo.Assemblies.Count == 0)
		{
			LoadAtVeryBegining();
		}
		LoadGDE();
		audioinfo.init();
	}

	public void LoadGDE()
	{
		gdeinfo.init();
		assemblyInfo.LoadModDef();
		gdeinfo.LoadModEditorJson();
		assemblyInfo.AfterModGDELoaded();
	}

	public void UnLoad()
	{
		assetInfo.UnLoad();
		gdeinfo.UnLoad();
		assemblyInfo.UnLoad();
		audioinfo.UnLoad();
	}

	public void UpdateModInfo()
	{
		gdeinfo.UpdateSchemaKeyDict();
		localizationInfo.LocalizationUpdate();
	}

	public T Loadgdata<T>(string key, T value, T result)
	{
		try
		{
			if (gdeinfo.Add.Contains(key) || gdeinfo.Replace.Contains(key))
			{
				return value;
			}
			return result;
		}
		catch
		{
			Debug.Log($"Error {key} {value} {result}");
			return result;
		}
	}

	public List<T> LoadgdataList<T>(string key, List<T> value, List<T> oldresult)
	{
		try
		{
			if (gdeinfo.Add.Contains(key) || gdeinfo.Replace.Contains(key))
			{
				return value;
			}
			if (gdeinfo.AddItemToList.Contains(key))
			{
				foreach (T item in value)
				{
					oldresult.Add(item);
				}
				return oldresult;
			}
			if (gdeinfo.RemoveItemFromList.Contains(key))
			{
				foreach (T item2 in value)
				{
					oldresult.Remove(item2);
				}
				return oldresult;
			}
			return oldresult;
		}
		catch
		{
			Debug.Log($"Error {key} {value} {oldresult}");
			return oldresult;
		}
	}

	public List<T> ModGdataGetList<T>(string key, string field, List<T> oldresult)
	{
		List<T> list = new List<T>();
		try
		{
			if (gdeinfo.gdatas.ContainsKey(key) && (gdeinfo.gdatas[key] as Dictionary<string, object>).ContainsKey(field))
			{
				list = ((!((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] is List<object>)) ? ((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<T>) : ((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<object>).ConvertAll((object x) => (T)x));
				for (int num = 0; num < list.Count; num++)
				{
					list[num] = ChangeModValue(list[num]);
				}
				(gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = list;
				return gdeinfo.GDEChangeDelGet(key, field, LoadgdataList(key, list, oldresult));
			}
		}
		catch
		{
		}
		return gdeinfo.GDEChangeDelGet(key, field, oldresult);
	}

	public bool GetBool(string key, string field, bool defaultVal)
	{
		bool ori = defaultVal;
		try
		{
			if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out var value))
			{
				ori = Convert.ToBoolean(value);
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return gdeinfo.GDEChangeDelGet(key, field, ori);
	}

	public float GetFloat(string key, string field, float defaultVal)
	{
		float ori = defaultVal;
		try
		{
			if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out var value))
			{
				ori = float.Parse(value.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture);
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return gdeinfo.GDEChangeDelGet(key, field, ori);
	}

	public int GetInt(string key, string field, int defaultVal)
	{
		int ori = defaultVal;
		try
		{
			if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out var value))
			{
				ori = Convert.ToInt32(value);
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return gdeinfo.GDEChangeDelGet(key, field, ori);
	}

	public List<int> GetIntList(string key, string field, List<int> defaultVal = null)
	{
		List<int> list = defaultVal;
		try
		{
			if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out var value))
			{
				List<int> value2 = new List<int>();
				if (value is List<int>)
				{
					value2 = value as List<int>;
				}
				if (value is List<object>)
				{
					value2 = (value as List<object>).ConvertAll((object obj2) => Convert.ToInt32(obj2));
				}
				list = LoadgdataList(key, value2, list);
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return gdeinfo.GDEChangeDelGet(key, field, list);
	}

	public string GetString(string key, string field, string defaultVal)
	{
		string value = defaultVal;
		try
		{
			if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out var value2) && value2 != null)
			{
				value = value2.ToString();
				if (UpdateModTypeName(ref value))
				{
					(gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = value;
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return gdeinfo.GDEChangeDelGet(key, field, value);
	}

	public bool UpdateModTypeName(ref string value)
	{
		if (value.Contains(".") && !value.Contains("PublicKeyToken="))
		{
			foreach (Assembly value2 in assemblyInfo.Assemblies.Values)
			{
				Type type = value2.GetType(value);
				if (type != null)
				{
					value = type.AssemblyQualifiedName;
					return true;
				}
			}
		}
		return false;
	}

	public List<string> GetStringList(string key, string field, List<string> defaultVal = null)
	{
		List<string> list = defaultVal;
		try
		{
			if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out var value) && value != null)
			{
				List<string> list2 = new List<string>();
				if (value is List<object>)
				{
					list2 = (value as List<object>).ConvertAll((object obj2) => obj2.ToString());
				}
				if (value is List<string>)
				{
					list2 = value as List<string>;
				}
				bool flag = false;
				for (int num = 0; num < list2.Count; num++)
				{
					string value2 = list2[num];
					if (UpdateModTypeName(ref value2))
					{
						list2[num] = value2;
						flag = true;
					}
				}
				if (flag)
				{
					(gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = list2;
				}
				list = LoadgdataList(key, list2, list);
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return gdeinfo.GDEChangeDelGet(key, field, list);
	}

	public List<List<string>> GetStringTwoDList(string key, string field, List<List<string>> defaultVal = null)
	{
		List<List<string>> list = defaultVal;
		try
		{
			if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out var value) && value != null)
			{
				List<List<string>> value2 = new List<List<string>>();
				if (value is List<object>)
				{
					value2 = (value as List<object>).ConvertAll((object obj2) => (obj2 as List<object>).ConvertAll((object obj3) => obj3.ToString()));
				}
				if (value is List<List<string>>)
				{
					value2 = value as List<List<string>>;
				}
				list = LoadgdataList(key, value2, list);
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return gdeinfo.GDEChangeDelGet(key, field, list);
	}

	public Vector2 GetVector2(string key, string field, Vector2 defaultVal)
	{
		Vector2 ori = defaultVal;
		try
		{
			if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out var value))
			{
				if (value is Dictionary<string, object> dictionary)
				{
					ori.x = float.Parse(dictionary["x"].ToString(), NumberStyles.Float, CultureInfo.InvariantCulture);
					ori.y = float.Parse(dictionary["y"].ToString(), NumberStyles.Float, CultureInfo.InvariantCulture);
				}
				if (value is Vector2)
				{
					ori = (Vector2)value;
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return gdeinfo.GDEChangeDelGet(key, field, ori);
	}

	public Vector3 GetVector3(string key, string field, Vector3 defaultVal)
	{
		Vector3 ori = defaultVal;
		try
		{
			if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out var value) && gdeinfo.gdatas.TryGetFromKeyField(key, field, out value))
			{
				if (value is Dictionary<string, object> dictionary)
				{
					ori.x = float.Parse(dictionary["x"].ToString(), NumberStyles.Float, CultureInfo.InvariantCulture);
					ori.y = float.Parse(dictionary["y"].ToString(), NumberStyles.Float, CultureInfo.InvariantCulture);
					ori.z = float.Parse(dictionary["z"].ToString(), NumberStyles.Float, CultureInfo.InvariantCulture);
				}
				if (value is Vector3)
				{
					ori = (Vector3)value;
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return gdeinfo.GDEChangeDelGet(key, field, ori);
	}

	public List<Vector3> GetVector3List(string key, string field, List<Vector3> defaultVal = null)
	{
		List<Vector3> list = defaultVal;
		try
		{
			if (gdeinfo.gdatas.TryGetFromKeyField(key, field, out var value))
			{
				List<Vector3> list2 = new List<Vector3>();
				if (value is List<object>)
				{
					foreach (object item2 in value as List<object>)
					{
						Dictionary<string, object> dictionary = item2 as Dictionary<string, object>;
						Vector3 item = default(Vector3);
						if (dictionary != null)
						{
							dictionary.TryGetFloat("x", out item.x);
							dictionary.TryGetFloat("y", out item.y);
							dictionary.TryGetFloat("z", out item.z);
						}
						if (item2 is Vector3)
						{
							item = (Vector3)item2;
						}
						list2.Add(item);
					}
				}
				if (value is List<Vector3>)
				{
					foreach (Vector3 item3 in value as List<Vector3>)
					{
						list2.Add(item3);
					}
				}
				list = LoadgdataList(key, list2, list);
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return gdeinfo.GDEChangeDelGet(key, field, list);
	}

	public static List<string> GetSpriteListPath(string key, string field, List<string> defaultVal)
	{
		List<string> list = defaultVal;
		foreach (string loadedMod in ModManager.LoadedMods)
		{
			list = ModManager.getModInfo(loadedMod).ModGdataGetList(key, field, list);
		}
		return list;
	}

	public static string GetSpritePath(string key, string field, string defaultVal)
	{
		string text = defaultVal;
		foreach (string loadedMod in ModManager.LoadedMods)
		{
			text = ModManager.getModInfo(loadedMod).ModSpriteGet(key, field, text);
		}
		return text;
	}

	public string ModSpriteGet(string key, string field, string oldresult)
	{
		try
		{
			if (gdeinfo.gdatas.ContainsKey(key) && (gdeinfo.gdatas[key] as Dictionary<string, object>).ContainsKey(field))
			{
				string value = (gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as string;
				bool isSkill = false;
				if (field == "Image_1" || field == "Image_2")
				{
					isSkill = true;
				}
				value = ChangeModValueSprite(value, isSkill);
				(gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = value;
				value = Loadgdata(key, value, oldresult);
				return gdeinfo.GDEChangeDelGet(key, field, value);
			}
		}
		catch
		{
		}
		return gdeinfo.GDEChangeDelGet(key, field, oldresult);
	}

	public List<string> ModSpriteListGet(string key, string field, List<string> oldresult)
	{
		List<string> list = new List<string>();
		try
		{
			if (gdeinfo.gdatas.ContainsKey(key) && (gdeinfo.gdatas[key] as Dictionary<string, object>).ContainsKey(field))
			{
				list = ((!((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] is List<object>)) ? ((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<string>) : ((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<object>).ConvertAll((object x) => x.ToString()));
				for (int num = 0; num < list.Count; num++)
				{
					list[num] = ChangeModValueSprite(list[num]);
				}
				(gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = list;
				return gdeinfo.GDEChangeDelGet(key, field, LoadgdataList(key, list, oldresult));
			}
		}
		catch
		{
		}
		return gdeinfo.GDEChangeDelGet(key, field, oldresult);
	}

	public static List<string> GetGameObjectListPath(string key, string field, List<string> defaultVal)
	{
		List<string> list = defaultVal;
		foreach (string loadedMod in ModManager.LoadedMods)
		{
			list = ModManager.getModInfo(loadedMod).ModGdataGetList(key, field, list);
		}
		return list;
	}

	public static string GetGameObjectPath(string key, string field, string defaultVal)
	{
		string text = defaultVal;
		foreach (string loadedMod in ModManager.LoadedMods)
		{
			text = ModManager.getModInfo(loadedMod).ModGameObjectGet(key, field, text);
		}
		return text;
	}

	public string ModGameObjectGet(string key, string field, string oldresult)
	{
		try
		{
			if (gdeinfo.gdatas.ContainsKey(key) && (gdeinfo.gdatas[key] as Dictionary<string, object>).ContainsKey(field))
			{
				string value = (gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as string;
				value = ChangeModValueGameObject(value);
				(gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = value;
				value = Loadgdata(key, value, oldresult);
				return gdeinfo.GDEChangeDelGet(key, field, value);
			}
		}
		catch
		{
		}
		return gdeinfo.GDEChangeDelGet(key, field, oldresult);
	}

	public List<string> ModGameObjectListGet(string key, string field, List<string> oldresult)
	{
		List<string> list = new List<string>();
		try
		{
			if (gdeinfo.gdatas.ContainsKey(key) && (gdeinfo.gdatas[key] as Dictionary<string, object>).ContainsKey(field))
			{
				list = ((!((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] is List<object>)) ? ((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<string>) : ((gdeinfo.gdatas[key] as Dictionary<string, object>)[field] as List<object>).ConvertAll((object x) => x.ToString()));
				for (int num = 0; num < list.Count; num++)
				{
					list[num] = ChangeModValueGameObject(list[num]);
				}
				(gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = list;
				return gdeinfo.GDEChangeDelGet(key, field, LoadgdataList(key, list, oldresult));
			}
		}
		catch
		{
		}
		return gdeinfo.GDEChangeDelGet(key, field, oldresult);
	}

	public string ChangeModValueSprite(string value, bool isSkill = false)
	{
		try
		{
			string text = value;
			if (text.EndsWith(".png"))
			{
				if (File.Exists(Path.Combine(assetInfo.AssetDirectory, text)))
				{
					text = assetInfo.ImageFromFile(text);
				}
				else if (!DefaultAssetBundlePath.IsNullOrEmpty())
				{
					text = assetInfo.ImageFromAsset(DefaultAssetBundlePath, text);
				}
				if (isSkill)
				{
					text = assetInfo.SkillImageResize(text);
				}
			}
			return text;
		}
		catch
		{
			return value;
		}
	}

	public string ChangeModValueGameObject(string value)
	{
		try
		{
			string text = value;
			if (text.EndsWith(".prefab") && !DefaultAssetBundlePath.IsNullOrEmpty())
			{
				text = assetInfo.ObjectFromAsset<GameObject>(DefaultAssetBundlePath, text);
			}
			return text;
		}
		catch
		{
			return value;
		}
	}

	public T ModGdataGet<T>(string key, string field, T oldresult)
	{
		try
		{
			if (gdeinfo.gdatas.ContainsKey(key) && (gdeinfo.gdatas[key] as Dictionary<string, object>).ContainsKey(field))
			{
				T value = (T)(gdeinfo.gdatas[key] as Dictionary<string, object>)[field];
				bool isSkill = false;
				if (field == "Image_1" || field == "Image_2")
				{
					isSkill = true;
				}
				value = ChangeModValue(value, isSkill);
				(gdeinfo.gdatas[key] as Dictionary<string, object>)[field] = value;
				value = Loadgdata(key, value, oldresult);
				return gdeinfo.GDEChangeDelGet(key, field, value);
			}
		}
		catch
		{
		}
		return oldresult;
	}

	public T ChangeModValue<T>(T value, bool isSkill = false)
	{
		if (typeof(T) != typeof(string))
		{
			return value;
		}
		try
		{
			if (!(value is string))
			{
				return value;
			}
			string text = value as string;
			if (text.EndsWith(".png"))
			{
				if (File.Exists(Path.Combine(assetInfo.AssetDirectory, text)))
				{
					text = assetInfo.ImageFromFile(text);
				}
				else if (!DefaultAssetBundlePath.IsNullOrEmpty())
				{
					text = assetInfo.ImageFromAsset(DefaultAssetBundlePath, text);
				}
				if (isSkill)
				{
					text = assetInfo.SkillImageResize(text);
				}
			}
			else if (text.EndsWith(".prefab") && !DefaultAssetBundlePath.IsNullOrEmpty())
			{
				text = assetInfo.ObjectFromAsset<GameObject>(DefaultAssetBundlePath, text);
			}
			return (T)(object)text;
		}
		catch
		{
			return value;
		}
	}

	public bool Equals(ModInfo other)
	{
		return id.Equals(other.id);
	}

	public override int GetHashCode()
	{
		return id.GetHashCode();
	}

	public string GetVersionString()
	{
		return Version;
	}
}
You are not using the latest version of the tool, please update.
Latest version is '11.1.0.9782' (yours is '9.1.0.7988')
