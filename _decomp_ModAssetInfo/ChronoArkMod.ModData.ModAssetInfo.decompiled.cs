using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ChronoArkMod.Addressable;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ChronoArkMod.ModData;

public class ModAssetInfo
{
	public enum ObjectAssetType
	{
		FromAssetBundle,
		CodeConstructed,
		FaceGameObject,
		BattleCharGameObject,
		EnemyGameObject,
		CodeConstuctedAsync,
		SmallFaceGameObject
	}

	public delegate T ObjectChangeDelegate<T>(T obj) where T : UnityEngine.Object;

	public abstract class ModObjectInfo
	{
		public ObjectAssetType infoType;

		public string ID;

		public string FilePath;

		public string AssetPath;

		public string ImageKey;

		public Vector2 offsetMax;

		public Vector2 offsetMin;

		public Vector2 pivot;

		public ModInfo modinfo;

		public Vector3 Head;

		public Vector3 Center;

		public Vector3 UI;

		public string OriginalKey;

		public ModObjectInfo(ModInfo info)
		{
			modinfo = info;
		}

		public abstract object Get();
	}

	public class ModObjectInfo<T> : ModObjectInfo where T : UnityEngine.Object
	{
		public ObjectChangeDelegate<T> changeDelegate;

		public bool Registered
		{
			get
			{
				if (modinfo.assetInfo.ModObjectInfos.ContainsKey(ID))
				{
					return true;
				}
				return false;
			}
		}

		public ModObjectInfo(ModInfo info)
			: base(info)
		{
		}

		public override string ToString()
		{
			string text = string.Concat(ID, " ", modinfo.id, " ", typeof(T), " ", infoType.ToString(), " ");
			return infoType switch
			{
				ObjectAssetType.FromAssetBundle => text + " " + AssetPath + " " + FilePath, 
				ObjectAssetType.CodeConstructed => text + " " + ID, 
				ObjectAssetType.BattleCharGameObject => string.Concat(text, " ", ImageKey, " ", offsetMax, " ", offsetMin, " ", pivot), 
				ObjectAssetType.FaceGameObject => string.Concat(text, " ", ImageKey, " ", offsetMax, " ", offsetMin, " ", pivot), 
				ObjectAssetType.EnemyGameObject => string.Concat(text, " ", ImageKey, " ", Head, " ", Center, " ", UI), 
				ObjectAssetType.CodeConstuctedAsync => text + " " + OriginalKey + " " + changeDelegate.Method.Name, 
				_ => text, 
			};
		}

		public override object Get()
		{
			return Get<T>();
		}

		public T Get<T2>()
		{
			switch (infoType)
			{
			case ObjectAssetType.FromAssetBundle:
				if (modinfo.assetInfo.IDtoObject.ContainsKey(ID) && modinfo.assetInfo.IDtoObject[ID] is T)
				{
					return modinfo.assetInfo.IDtoObject[ID] as T;
				}
				if (typeof(T) == typeof(Sprite))
				{
					Sprite sprite = modinfo.assetInfo.GetAssetBundle(AssetPath).LoadAsset<Sprite>(FilePath);
					if (sprite == null)
					{
						Texture2D texture2D = modinfo.assetInfo.GetAssetBundle(AssetPath).LoadAsset<Texture2D>(FilePath);
						if (texture2D != null)
						{
							sprite = Misc.CreatSprite(texture2D);
						}
						modinfo.assetInfo.IDtoObject.Add(ID, sprite);
					}
					return sprite as T;
				}
				return modinfo.assetInfo.LoadFromAsset<T>(AssetPath, FilePath);
			case ObjectAssetType.CodeConstructed:
				if (modinfo.assetInfo.IDtoObject.ContainsKey(ID) && modinfo.assetInfo.IDtoObject[ID] is T)
				{
					return (T)modinfo.assetInfo.IDtoObject[ID];
				}
				return null;
			case ObjectAssetType.FaceGameObject:
				if (typeof(T) == typeof(GameObject))
				{
					return AssetGeneratingTools.Makeface(ImageKey, offsetMax, offsetMin, pivot) as T;
				}
				return null;
			case ObjectAssetType.BattleCharGameObject:
				if (typeof(T) == typeof(GameObject))
				{
					return AssetGeneratingTools.MakeBattleChar(ImageKey, offsetMax, offsetMin, pivot) as T;
				}
				return null;
			case ObjectAssetType.SmallFaceGameObject:
				if (typeof(T) == typeof(GameObject))
				{
					return AssetGeneratingTools.MakeSmallFace(ImageKey, offsetMax, offsetMin, pivot) as T;
				}
				return null;
			case ObjectAssetType.EnemyGameObject:
				if (typeof(T) == typeof(GameObject))
				{
					return AssetGeneratingTools.MakeEnemy(ImageKey, Head, Center, UI) as T;
				}
				return null;
			case ObjectAssetType.CodeConstuctedAsync:
			{
				if (modinfo.assetInfo.IDtoObject.ContainsKey(ID) && modinfo.assetInfo.IDtoObject[ID] is T)
				{
					return (T)modinfo.assetInfo.IDtoObject[ID];
				}
				T val = UnityEngine.Object.Instantiate(AddressableLoadManager.LoadAsyncCompletion<T>(OriginalKey, AddressableLoadManager.ManageType.None));
				UnityEngine.Object.DontDestroyOnLoad(val);
				val = changeDelegate(val);
				modinfo.assetInfo.IDtoObject.Add(ID, val);
				return val;
			}
			default:
				return null;
			}
		}
	}

	public enum ImageAssetType
	{
		FromFile,
		FromAssetBundle,
		CodeConstructed,
		SkillImage,
		SpritePivot
	}

	public class ModImageInfo
	{
		public ModInfo modinfo;

		public ImageAssetType infoType;

		public string ID;

		public string FilePath;

		public string AssetPath;

		public string OldID;

		public Vector2 pivot;

		public bool Registered
		{
			get
			{
				if (modinfo.assetInfo.ModImageInfos.ContainsKey(ID))
				{
					return true;
				}
				return false;
			}
		}

		public ModImageInfo(ModInfo info)
		{
			modinfo = info;
		}

		public override string ToString()
		{
			string text = ID + " " + modinfo.id + " " + infoType.ToString() + " ";
			return infoType switch
			{
				ImageAssetType.FromFile => text + FilePath, 
				ImageAssetType.FromAssetBundle => text + AssetPath + FilePath, 
				ImageAssetType.CodeConstructed => text + ID, 
				ImageAssetType.SkillImage => text + OldID, 
				_ => null, 
			};
		}

		public Sprite Get()
		{
			switch (infoType)
			{
			case ImageAssetType.FromFile:
			{
				if (modinfo.assetInfo.IDtoSprite.ContainsKey(ID))
				{
					return modinfo.assetInfo.IDtoSprite[ID];
				}
				Texture2D texture2D = null;
				try
				{
					texture2D = AssetGeneratingTools.LoadTexture(Path.Combine(modinfo.assetInfo.AssetDirectory, FilePath));
				}
				catch
				{
				}
				if (texture2D != null)
				{
					Sprite sprite3 = Misc.CreatSprite(texture2D);
					modinfo.assetInfo.IDtoSprite.Add(ID, sprite3);
					return sprite3;
				}
				return null;
			}
			case ImageAssetType.FromAssetBundle:
			{
				if (modinfo.assetInfo.IDtoSprite.ContainsKey(ID))
				{
					return modinfo.assetInfo.IDtoSprite[ID];
				}
				Sprite sprite4 = modinfo.assetInfo.LoadFromAsset<Sprite>(AssetPath, FilePath);
				if (sprite4 != null)
				{
					return sprite4;
				}
				Texture2D texture2D2 = modinfo.assetInfo.LoadFromAsset<Texture2D>(AssetPath, FilePath);
				if (texture2D2 != null)
				{
					Sprite sprite5 = Misc.CreatSprite(texture2D2);
					modinfo.assetInfo.IDtoSprite.Add(ID, sprite5);
					return sprite5;
				}
				return null;
			}
			case ImageAssetType.CodeConstructed:
				return modinfo.assetInfo.IDtoSprite[ID];
			case ImageAssetType.SkillImage:
			{
				if (modinfo.assetInfo.IDtoSprite.ContainsKey(ID))
				{
					return modinfo.assetInfo.IDtoSprite[ID];
				}
				Sprite sprite2 = AssetGeneratingTools.SkillImageResizeGet(OldID);
				if (sprite2 != null)
				{
					modinfo.assetInfo.IDtoSprite[ID] = sprite2;
					return sprite2;
				}
				return null;
			}
			case ImageAssetType.SpritePivot:
			{
				if (modinfo.assetInfo.IDtoSprite.ContainsKey(ID))
				{
					return modinfo.assetInfo.IDtoSprite[ID];
				}
				Sprite sprite = AssetGeneratingTools.ChangePivot(OldID, pivot);
				if (sprite != null)
				{
					modinfo.assetInfo.IDtoSprite[ID] = sprite;
					return sprite;
				}
				return null;
			}
			default:
				return null;
			}
		}
	}

	public ModInfo modinfo;

	public string AssetDirectory;

	public Dictionary<string, ModImageInfo> ModImageInfos = new Dictionary<string, ModImageInfo>();

	public Dictionary<string, Sprite> IDtoSprite = new Dictionary<string, Sprite>();

	public Dictionary<string, AssetBundle> PathToAssetBundle = new Dictionary<string, AssetBundle>();

	public Dictionary<string, ModObjectInfo> ModObjectInfos = new Dictionary<string, ModObjectInfo>();

	public Dictionary<string, UnityEngine.Object> IDtoObject = new Dictionary<string, UnityEngine.Object>();

	public ModResourceLocator_Image _ImageLocator;

	public ModResourceProvider_Image _ImageProvider;

	public ModResourceLocator_Object _ObjectLocator;

	public ModResourceProvider_Object _ObjectProvider;

	public List<TMP_SpriteAsset> TMPSpriteAssets = new List<TMP_SpriteAsset>();

	public ModResourceLocator_Image ImageLocator
	{
		get
		{
			if (_ImageLocator == null)
			{
				_ImageLocator = new ModResourceLocator_Image(modinfo.id);
			}
			return _ImageLocator;
		}
		set
		{
			_ImageLocator = value;
		}
	}

	public ModResourceProvider_Image ImageProvider
	{
		get
		{
			if (_ImageProvider == null)
			{
				_ImageProvider = new ModResourceProvider_Image(modinfo.id);
			}
			return _ImageProvider;
		}
		set
		{
			_ImageProvider = value;
		}
	}

	public ModResourceLocator_Object ObjectLocator
	{
		get
		{
			if (_ObjectLocator == null)
			{
				_ObjectLocator = new ModResourceLocator_Object(modinfo.id);
			}
			return _ObjectLocator;
		}
		set
		{
			_ObjectLocator = value;
		}
	}

	public ModResourceProvider_Object ObjectProvider
	{
		get
		{
			if (_ObjectProvider == null)
			{
				_ObjectProvider = new ModResourceProvider_Object(modinfo.id);
			}
			return _ObjectProvider;
		}
		set
		{
			_ObjectProvider = value;
		}
	}

	public string AssetFolder => Path.Combine(modinfo.DirectoryName, "Assets");

	public ModAssetInfo(ModInfo modInfo)
	{
		modinfo = modInfo;
		AssetDirectory = Path.Combine(modInfo.DirectoryName, "Assets");
	}

	public string SkillImageResize(string path)
	{
		return ChangeToSkillImage(path);
	}

	public void init()
	{
		Directory.CreateDirectory(AssetDirectory);
		Addressables.AddResourceLocator(ImageLocator);
		Addressables.AddResourceLocator(ObjectLocator);
		Addressables.ResourceManager.ResourceProviders.Add(ImageProvider);
		Addressables.ResourceManager.ResourceProviders.Add(ObjectProvider);
		Load_TMPSpriteAssets();
	}

	public void UnLoad()
	{
		List<string> list = new List<string>();
		foreach (string key in ModImageInfos.Keys)
		{
			ModImageInfo modImageInfo = ModImageInfos[key];
			if (modImageInfo != null && modImageInfo.infoType == ImageAssetType.CodeConstructed)
			{
				list.Add(key);
			}
		}
		foreach (string item in list)
		{
			ModImageInfos.Remove(item);
		}
		list.Clear();
		foreach (string key2 in ModObjectInfos.Keys)
		{
			ModObjectInfo modObjectInfo = ModObjectInfos[key2];
			if (modObjectInfo != null && modObjectInfo.infoType == ObjectAssetType.CodeConstructed)
			{
				list.Add(key2);
			}
		}
		foreach (string item2 in list)
		{
			ModObjectInfos.Remove(item2);
		}
		foreach (UnityEngine.Object value in IDtoObject.Values)
		{
			UnityEngine.Object.Destroy(value);
		}
		foreach (Sprite value2 in IDtoSprite.Values)
		{
			UnityEngine.Object.Destroy(value2);
		}
		foreach (AssetBundle value3 in PathToAssetBundle.Values)
		{
			value3?.Unload(unloadAllLoadedObjects: true);
		}
		IDtoObject.Clear();
		IDtoSprite.Clear();
		PathToAssetBundle.Clear();
		Addressables.RemoveResourceLocator(ImageLocator);
		Addressables.RemoveResourceLocator(ObjectLocator);
		Addressables.ResourceManager?.ResourceProviders?.Remove(ImageProvider);
		Addressables.ResourceManager?.ResourceProviders?.Remove(ObjectProvider);
		ImageLocator = null;
		ImageProvider = null;
		ObjectLocator = null;
		ObjectProvider = null;
	}

	public void UnLoad_TMPSpriteAssets()
	{
		foreach (TMP_SpriteAsset tMPSpriteAsset in TMPSpriteAssets)
		{
			TMP_Settings.defaultSpriteAsset.fallbackSpriteAssets.Remove(tMPSpriteAsset);
		}
	}

	public void Load_TMPSpriteAssets()
	{
		TMPSpriteAssets.Clear();
		string path = Path.Combine(modinfo.DirectoryName, "TMP_SpriteAssets");
		Directory.CreateDirectory(path);
		string[] files = Directory.GetFiles(path);
		foreach (string path2 in files)
		{
			try
			{
				Texture2D texture2D = AssetGeneratingTools.LoadTexture(path2);
				if (!(texture2D != null))
				{
					continue;
				}
				Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0f, 0f), 100f, 0u, SpriteMeshType.FullRect);
				if (sprite != null)
				{
					sprite.name = modinfo.id + "_" + Path.GetFileNameWithoutExtension(path2);
					TMP_SpriteAsset item = AssetGeneratingTools.CreateTMPSpriteAsset(sprite);
					TMPSpriteAssets.Add(item);
					if (!TMP_Settings.defaultSpriteAsset.fallbackSpriteAssets.Contains(item))
					{
						TMP_Settings.defaultSpriteAsset.fallbackSpriteAssets.Add(item);
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}

	public AssetBundle GetAssetBundle(string path)
	{
		path = path.Replace("\\", "/");
		if (PathToAssetBundle.ContainsKey(path))
		{
			return PathToAssetBundle[path];
		}
		AssetBundle assetBundle = null;
		try
		{
			assetBundle = AssetBundle.LoadFromFile(Path.Combine(AssetDirectory, path));
			PathToAssetBundle.Add(path, assetBundle);
		}
		catch
		{
		}
		return assetBundle;
	}

	public T LoadFromAsset<T>(string AssetPath, string FilePath) where T : UnityEngine.Object
	{
		return GetAssetBundle(AssetPath).LoadAsset<T>(FilePath);
	}

	public string ConstructObjectByCode<T>(T gameObject) where T : UnityEngine.Object
	{
		ModObjectInfo<T> modObjectInfo = new ModObjectInfo<T>(modinfo);
		modObjectInfo.ID = gameObject.GetHashCode().ToString();
		modObjectInfo.infoType = ObjectAssetType.CodeConstructed;
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		modObjectInfo.ID = (modObjectInfo.ID.GetHashCode() + modObjectInfo.modinfo.GetHashCode() + modObjectInfo.infoType.GetHashCode()).GetHashCode().ToString();
		if (!modObjectInfo.Registered)
		{
			ModObjectInfos.Add(modObjectInfo.ID, modObjectInfo);
			IDtoObject.Add(modObjectInfo.ID, gameObject);
		}
		return modObjectInfo.ID;
	}

	public string FaceGameObject(string ImageKey, Vector2 offsetMax, Vector2 offsetMin, Vector2 pivot)
	{
		ModObjectInfo<GameObject> modObjectInfo = new ModObjectInfo<GameObject>(modinfo);
		modObjectInfo.ImageKey = ImageKey;
		modObjectInfo.offsetMax = offsetMax;
		modObjectInfo.offsetMin = offsetMin;
		modObjectInfo.pivot = pivot;
		modObjectInfo.infoType = ObjectAssetType.FaceGameObject;
		modObjectInfo.ID = (modObjectInfo.ImageKey.GetHashCode() + modObjectInfo.infoType.GetHashCode()).GetHashCode().ToString();
		modObjectInfo.ID = (modObjectInfo.ID.GetHashCode() + modObjectInfo.modinfo.GetHashCode()).GetHashCode().ToString();
		modObjectInfo.ID = (modObjectInfo.ID.GetHashCode() + modObjectInfo.offsetMax.GetHashCode() + modObjectInfo.offsetMin.GetHashCode() + modObjectInfo.pivot.GetHashCode()).GetHashCode().ToString();
		if (!modObjectInfo.Registered)
		{
			ModObjectInfos.Add(modObjectInfo.ID, modObjectInfo);
		}
		return modObjectInfo.ID;
	}

	public string BattleCharGameObject(string ImageKey, Vector2 offsetMax, Vector2 offsetMin, Vector2 pivot)
	{
		ModObjectInfo<GameObject> modObjectInfo = new ModObjectInfo<GameObject>(modinfo);
		modObjectInfo.ImageKey = ImageKey;
		modObjectInfo.offsetMax = offsetMax;
		modObjectInfo.offsetMin = offsetMin;
		modObjectInfo.pivot = pivot;
		modObjectInfo.infoType = ObjectAssetType.BattleCharGameObject;
		modObjectInfo.ID = (modObjectInfo.ImageKey.GetHashCode() + modObjectInfo.infoType.GetHashCode()).GetHashCode().ToString();
		modObjectInfo.ID = (modObjectInfo.ID.GetHashCode() + modObjectInfo.modinfo.GetHashCode()).GetHashCode().ToString();
		modObjectInfo.ID = (modObjectInfo.ID.GetHashCode() + modObjectInfo.offsetMax.GetHashCode() + modObjectInfo.offsetMin.GetHashCode() + modObjectInfo.pivot.GetHashCode()).GetHashCode().ToString();
		if (!modObjectInfo.Registered)
		{
			ModObjectInfos.Add(modObjectInfo.ID, modObjectInfo);
		}
		return modObjectInfo.ID;
	}

	public string SmallFaceGameObject(string ImageKey, Vector2 offsetMax, Vector2 offsetMin, Vector2 pivot)
	{
		ModObjectInfo<GameObject> modObjectInfo = new ModObjectInfo<GameObject>(modinfo);
		modObjectInfo.ImageKey = ImageKey;
		modObjectInfo.offsetMax = offsetMax;
		modObjectInfo.offsetMin = offsetMin;
		modObjectInfo.pivot = pivot;
		modObjectInfo.infoType = ObjectAssetType.SmallFaceGameObject;
		modObjectInfo.ID = (modObjectInfo.ImageKey.GetHashCode() + modObjectInfo.infoType.GetHashCode()).GetHashCode().ToString();
		modObjectInfo.ID = (modObjectInfo.ID.GetHashCode() + modObjectInfo.modinfo.GetHashCode()).GetHashCode().ToString();
		modObjectInfo.ID = (modObjectInfo.ID.GetHashCode() + modObjectInfo.offsetMax.GetHashCode() + modObjectInfo.offsetMin.GetHashCode() + modObjectInfo.pivot.GetHashCode()).GetHashCode().ToString();
		if (!modObjectInfo.Registered)
		{
			ModObjectInfos.Add(modObjectInfo.ID, modObjectInfo);
		}
		return modObjectInfo.ID;
	}

	public string EnemyGameObject(string ImageKey, Vector3 Head, Vector3 Center, Vector3 UI)
	{
		ModObjectInfo<GameObject> modObjectInfo = new ModObjectInfo<GameObject>(modinfo);
		modObjectInfo.ImageKey = ImageKey;
		modObjectInfo.Head = Head;
		modObjectInfo.Center = Center;
		modObjectInfo.UI = UI;
		modObjectInfo.infoType = ObjectAssetType.EnemyGameObject;
		modObjectInfo.ID = (modObjectInfo.ImageKey.GetHashCode() + modObjectInfo.infoType.GetHashCode()).GetHashCode().ToString();
		modObjectInfo.ID = (modObjectInfo.ID.GetHashCode() + modObjectInfo.modinfo.GetHashCode()).GetHashCode().ToString();
		modObjectInfo.ID = (modObjectInfo.ID.GetHashCode() + modObjectInfo.Head.GetHashCode() + modObjectInfo.Center.GetHashCode() + modObjectInfo.UI.GetHashCode()).GetHashCode().ToString();
		if (!modObjectInfo.Registered)
		{
			ModObjectInfos.Add(modObjectInfo.ID, modObjectInfo);
		}
		return modObjectInfo.ID;
	}

	public string CodeConstuctAsync<T>(string Original, ObjectChangeDelegate<T> del) where T : UnityEngine.Object
	{
		ModObjectInfo<T> modObjectInfo = new ModObjectInfo<T>(modinfo);
		modObjectInfo.changeDelegate = del;
		modObjectInfo.OriginalKey = Original;
		modObjectInfo.infoType = ObjectAssetType.CodeConstuctedAsync;
		modObjectInfo.ID = (modObjectInfo.OriginalKey.GetHashCode() + modObjectInfo.changeDelegate.GetHashCode() + modObjectInfo.infoType.GetHashCode()).GetHashCode().ToString();
		modObjectInfo.ID = (modObjectInfo.ID.GetHashCode() + modObjectInfo.modinfo.GetHashCode()).GetHashCode().ToString();
		if (!modObjectInfo.Registered)
		{
			ModObjectInfos.Add(modObjectInfo.ID, modObjectInfo);
			SaveManager.savemanager.StartCoroutine(CodeConstuctAsyncInit<T>(modObjectInfo));
		}
		return modObjectInfo.ID;
	}

	public IEnumerator CodeConstuctAsyncInit<T>(ModObjectInfo modObjectInfo) where T : UnityEngine.Object
	{
		yield return new WaitForFixedUpdate();
		object addressableimpl = typeof(Addressables).GetField("m_AddressablesInstance", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
		PropertyInfo property = typeof(Addressables).Assembly.GetType("UnityEngine.AddressableAssets.AddressablesImpl").GetProperty("ShouldChainRequest", BindingFlags.Instance | BindingFlags.NonPublic);
		yield return new WaitUntil(() => !(bool)property.GetValue(addressableimpl));
		string originalKey = modObjectInfo.OriginalKey;
		if (string.IsNullOrEmpty(originalKey))
		{
			yield break;
		}
		AsyncOperationHandle asyncOperationHandle = Addressables.LoadAssetAsync<T>(originalKey);
		asyncOperationHandle.Completed += delegate(AsyncOperationHandle x)
		{
			try
			{
				if (!IDtoObject.ContainsKey(modObjectInfo.ID) || !(IDtoObject[modObjectInfo.ID] is T))
				{
					T val = UnityEngine.Object.Instantiate((T)x.Result);
					UnityEngine.Object.DontDestroyOnLoad(val);
					val = ((ModObjectInfo<T>)modObjectInfo).changeDelegate(val);
					IDtoObject.Add(modObjectInfo.ID, val);
				}
			}
			catch (Exception exception)
			{
				Debug.Log("CodeConstuctAsyncInit Error:" + modObjectInfo.ID);
				Debug.LogException(exception);
			}
		};
	}

	public string ObjectFromAsset<T>(string AssetBundlePath, string FilePath) where T : UnityEngine.Object
	{
		ModObjectInfo<T> modObjectInfo = new ModObjectInfo<T>(modinfo);
		modObjectInfo.AssetPath = AssetBundlePath.Replace("\\", "/");
		modObjectInfo.infoType = ObjectAssetType.FromAssetBundle;
		modObjectInfo.FilePath = FilePath.Replace("\\", "/");
		modObjectInfo.ID = (modObjectInfo.AssetPath + modObjectInfo.FilePath).GetHashCode().ToString();
		modObjectInfo.ID = (modObjectInfo.ID.GetHashCode() + modObjectInfo.modinfo.GetHashCode() + modObjectInfo.infoType.GetHashCode()).GetHashCode().ToString();
		if (!modObjectInfo.Registered)
		{
			if (File.Exists(Path.Combine(AssetFolder, modObjectInfo.AssetPath)))
			{
				AssetBundle assetBundle = GetAssetBundle(modObjectInfo.AssetPath);
				if (assetBundle != null && assetBundle.Contains(modObjectInfo.FilePath))
				{
					ModObjectInfos.Add(modObjectInfo.ID, modObjectInfo);
					return modObjectInfo.ID;
				}
			}
			return "";
		}
		return modObjectInfo.ID;
	}

	public string ChangeToSkillImage(string OldID)
	{
		ModImageInfo modImageInfo = new ModImageInfo(modinfo);
		modImageInfo.ID = OldID.GetHashCode().ToString();
		modImageInfo.OldID = OldID;
		modImageInfo.infoType = ImageAssetType.SkillImage;
		modImageInfo.ID = (modImageInfo.ID.GetHashCode() + modImageInfo.modinfo.GetHashCode() + modImageInfo.infoType.GetHashCode()).GetHashCode().ToString();
		if (!modImageInfo.Registered)
		{
			ModImageInfos.Add(modImageInfo.ID, modImageInfo);
			return modImageInfo.ID;
		}
		return modImageInfo.ID;
	}

	public string ChangeSpritePivot(string OldID, Vector2 pivot)
	{
		ModImageInfo modImageInfo = new ModImageInfo(modinfo);
		modImageInfo.ID = OldID.GetHashCode().ToString();
		modImageInfo.OldID = OldID;
		modImageInfo.infoType = ImageAssetType.SpritePivot;
		modImageInfo.pivot = pivot;
		modImageInfo.ID = (modImageInfo.ID.GetHashCode() + modImageInfo.modinfo.GetHashCode() + modImageInfo.infoType.GetHashCode() + modImageInfo.pivot.GetHashCode()).GetHashCode().ToString();
		if (!modImageInfo.Registered)
		{
			ModImageInfos.Add(modImageInfo.ID, modImageInfo);
			return modImageInfo.ID;
		}
		return modImageInfo.ID;
	}

	public string ConstructImageByCode(Sprite sprite)
	{
		ModImageInfo modImageInfo = new ModImageInfo(modinfo);
		modImageInfo.ID = sprite.GetHashCode().ToString();
		modImageInfo.infoType = ImageAssetType.CodeConstructed;
		modImageInfo.ID = (modImageInfo.ID.GetHashCode() + modImageInfo.modinfo.GetHashCode() + modImageInfo.infoType.GetHashCode()).GetHashCode().ToString();
		if (!modImageInfo.Registered)
		{
			ModImageInfos.Add(modImageInfo.ID, modImageInfo);
			IDtoSprite.Add(modImageInfo.ID, sprite);
		}
		return modImageInfo.ID;
	}

	public string ImageFromAsset(string AssetBundlePath, string FilePath)
	{
		ModImageInfo modImageInfo = new ModImageInfo(modinfo);
		modImageInfo.AssetPath = AssetBundlePath.Replace("\\", "/");
		modImageInfo.infoType = ImageAssetType.FromAssetBundle;
		modImageInfo.FilePath = FilePath.Replace("\\", "/");
		modImageInfo.ID = (modImageInfo.AssetPath + modImageInfo.FilePath).GetHashCode().ToString();
		modImageInfo.ID = (modImageInfo.ID.GetHashCode() + modImageInfo.modinfo.GetHashCode() + modImageInfo.infoType.GetHashCode()).GetHashCode().ToString();
		if (!modImageInfo.Registered)
		{
			if (File.Exists(Path.Combine(AssetFolder, modImageInfo.AssetPath)))
			{
				AssetBundle assetBundle = GetAssetBundle(modImageInfo.AssetPath);
				if (assetBundle != null && assetBundle.Contains(modImageInfo.FilePath))
				{
					ModImageInfos.Add(modImageInfo.ID, modImageInfo);
					return modImageInfo.ID;
				}
			}
			return "";
		}
		return modImageInfo.ID;
	}

	public string ImageFromFile(string path)
	{
		ModImageInfo modImageInfo = new ModImageInfo(modinfo);
		modImageInfo.FilePath = path.Replace("\\", "/");
		modImageInfo.infoType = ImageAssetType.FromFile;
		modImageInfo.ID = modImageInfo.FilePath.GetHashCode().ToString();
		modImageInfo.ID = (modImageInfo.ID.GetHashCode() + modImageInfo.modinfo.GetHashCode() + modImageInfo.infoType.GetHashCode()).GetHashCode().ToString();
		if (!modImageInfo.Registered)
		{
			if (!File.Exists(Path.Combine(AssetFolder, modImageInfo.FilePath)))
			{
				return "";
			}
			ModImageInfos.Add(modImageInfo.ID, modImageInfo);
		}
		return modImageInfo.ID;
	}
}
