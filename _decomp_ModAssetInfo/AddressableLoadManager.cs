using System;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AddressableLoadManager
{
	public enum ManageType
	{
		None,
		Character,
		Stage,
		Collection,
		StoryRecord,
		Battle,
		EachStage
	}

	private static List<AsyncOperationHandle> CharacterHandleList = new List<AsyncOperationHandle>();

	private static List<AsyncOperationHandle> StageHandleList = new List<AsyncOperationHandle>();

	private static List<AsyncOperationHandle> OtherHandleList = new List<AsyncOperationHandle>();

	private static List<AsyncOperationHandle> RecordHandleList = new List<AsyncOperationHandle>();

	private static List<AsyncOperationHandle> CollectionHandleList = new List<AsyncOperationHandle>();

	private static List<AsyncOperationHandle> BattleHandleList = new List<AsyncOperationHandle>();

	private static List<AsyncOperationHandle> EachStageList = new List<AsyncOperationHandle>();

	private static List<AsyncOperationHandle> CrimsonHandleList = new List<AsyncOperationHandle>();

	public static List<string> MonsterKey;

	public static T LoadAddressableAsset<T>(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return default(T);
		}
		return Addressables.LoadAssetAsync<T>(path).WaitForCompletion();
	}

	private static void HandleAdd(ManageType Mtype, AsyncOperationHandle h)
	{
		switch (Mtype)
		{
		case ManageType.Character:
			CharacterHandleList.Add(h);
			break;
		case ManageType.Stage:
			StageHandleList.Add(h);
			break;
		case ManageType.Collection:
			CollectionHandleList.Add(h);
			break;
		case ManageType.None:
			OtherHandleList.Add(h);
			break;
		case ManageType.StoryRecord:
			RecordHandleList.Add(h);
			break;
		case ManageType.Battle:
			BattleHandleList.Add(h);
			break;
		case ManageType.EachStage:
			EachStageList.Add(h);
			break;
		}
	}

	public static GameObject Instantiate(string path, ManageType Mtype, Vector3 pos)
	{
		return Instantiate(path, Mtype, pos, Quaternion.identity, null);
	}

	public static GameObject Instantiate(AssetReference assetRef, ManageType Mtype, Vector3 pos, Transform parent = null)
	{
		if (assetRef == null)
		{
			return null;
		}
		AsyncOperationHandle h = Addressables.InstantiateAsync(assetRef, pos, Quaternion.identity, parent);
		HandleAdd(Mtype, h);
		return (GameObject)h.WaitForCompletion();
	}

	public static GameObject Instantiate(string path, ManageType Mtype, Vector3 pos, Quaternion rot)
	{
		return Instantiate(path, Mtype, pos, rot, null);
	}

	public static GameObject Instantiate(string path, ManageType Mtype, Vector3 pos, Quaternion rot, Transform parent)
	{
		if (string.IsNullOrEmpty(path))
		{
			return null;
		}
		AsyncOperationHandle h = Addressables.InstantiateAsync(path, pos, rot, parent);
		HandleAdd(Mtype, h);
		return (GameObject)h.WaitForCompletion();
	}

	public static GameObject Instantiate(string Path, ManageType Mtype)
	{
		return Instantiate(Path, Mtype, null);
	}

	public static GameObject Instantiate(string Path, ManageType Mtype, Transform parent)
	{
		if (string.IsNullOrEmpty(Path))
		{
			return null;
		}
		AsyncOperationHandle h = Addressables.InstantiateAsync(Path, parent);
		HandleAdd(Mtype, h);
		return (GameObject)h.WaitForCompletion();
	}

	public static GameObject Instantiate(AssetReference assetRef, ManageType MType, Transform parent = null)
	{
		if (assetRef == null)
		{
			return null;
		}
		AsyncOperationHandle h = Addressables.InstantiateAsync(assetRef, parent);
		HandleAdd(MType, h);
		return (GameObject)h.WaitForCompletion();
	}

	public static T LoadAsyncCompletion<T>(string Path, ManageType Mtype)
	{
		if (string.IsNullOrEmpty(Path))
		{
			return default(T);
		}
		AsyncOperationHandle h = Addressables.LoadAssetAsync<T>(Path);
		HandleAdd(Mtype, h);
		return (T)h.WaitForCompletion();
	}

	public static T LoadAsyncCompletion<T>(AssetReference Path, ManageType Mtype)
	{
		AsyncOperationHandle h = Addressables.LoadAssetAsync<T>(Path);
		HandleAdd(Mtype, h);
		return (T)h.WaitForCompletion();
	}

	public static void LoadAsyncListAction(List<string> Path, ManageType Mtype, Action<AsyncOperationHandle> collback)
	{
		AsyncOperationHandle h = Addressables.LoadAssetsAsync<UnityEngine.Object>(Path, null);
		HandleAdd(Mtype, h);
		h.Completed += collback;
	}

	public static void LoadAsyncAction(string Path, ManageType Mtype, Action<AsyncOperationHandle> collback)
	{
		if (!string.IsNullOrEmpty(Path))
		{
			AsyncOperationHandle h = Addressables.LoadAssetAsync<UnityEngine.Object>(Path);
			HandleAdd(Mtype, h);
			h.Completed += collback;
		}
	}

	public static void LoadAsyncAction(ItemBase Item, string Path)
	{
		if (string.IsNullOrEmpty(Path))
		{
			return;
		}
		AsyncOperationHandle<Sprite> asyncOperationHandle = Addressables.LoadAssetAsync<Sprite>(Path);
		asyncOperationHandle.Completed += delegate(AsyncOperationHandle<Sprite> handle)
		{
			HandleAdd(ManageType.None, handle);
			if (handle.Result != null)
			{
				Item.icon = handle.Result;
			}
		};
	}

	public static void LoadAsyncAction(string Path, ManageType Mtype, Image addsprite)
	{
		if (string.IsNullOrEmpty(Path))
		{
			return;
		}
		AsyncOperationHandle<Sprite> asyncOperationHandle = Addressables.LoadAssetAsync<Sprite>(Path);
		asyncOperationHandle.Completed += delegate(AsyncOperationHandle<Sprite> handle)
		{
			HandleAdd(Mtype, handle);
			try
			{
				if (handle.Result != null)
				{
					addsprite.sprite = handle.Result;
				}
			}
			catch
			{
			}
		};
	}

	public static void LoadAsyncAction(string Path, ManageType Mtype, Sprite addsprite)
	{
		AsyncOperationHandle<Sprite> asyncOperationHandle = Addressables.LoadAssetAsync<Sprite>(Path);
		asyncOperationHandle.Completed += delegate(AsyncOperationHandle<Sprite> handle)
		{
			HandleAdd(Mtype, handle);
			addsprite = handle.Result;
		};
	}

	public static void LoadAsyncAction(string Path, ManageType Mtype, SpriteRenderer addsprite)
	{
		if (string.IsNullOrEmpty(Path))
		{
			return;
		}
		AsyncOperationHandle<Sprite> asyncOperationHandle = Addressables.LoadAssetAsync<Sprite>(Path);
		asyncOperationHandle.Completed += delegate(AsyncOperationHandle<Sprite> handle)
		{
			if (handle.Result != null)
			{
				addsprite.sprite = handle.Result;
			}
		};
	}

	public static IEnumerator _LoadAsyncAction(string Path, ManageType Mtype, Sprite addsprite)
	{
		if (!string.IsNullOrEmpty(Path))
		{
			AsyncOperationHandle<Sprite> hand = Addressables.LoadAssetAsync<Sprite>(Path);
			HandleAdd(Mtype, hand);
			yield return hand;
			if (hand.Status == AsyncOperationStatus.Succeeded && hand.Result != null)
			{
				addsprite = hand.Result;
			}
		}
	}

	public static void LoadAsyncAction(string Path, ManageType Mtype, GameObject addGO)
	{
		if (!string.IsNullOrEmpty(Path))
		{
			AsyncOperationHandle hand = Addressables.LoadAssetAsync<UnityEngine.Object>(Path);
			HandleAdd(Mtype, hand);
			hand.Completed += delegate
			{
				object result = hand.Result;
				addGO = (GameObject)result;
			};
		}
	}

	public static void UnloadAllAddressableData()
	{
		UnloadAddressableData(ManageType.Battle);
		UnloadAddressableData(ManageType.Character);
		UnloadAddressableData(ManageType.Collection);
		UnloadAddressableData(ManageType.Stage);
		UnloadAddressableData(ManageType.StoryRecord);
		UnloadAddressableData(ManageType.EachStage);
		Resources.UnloadUnusedAssets();
	}

	public static void UnloadAddressableData(ManageType Mtype)
	{
		List<AsyncOperationHandle> list = null;
		switch (Mtype)
		{
		case ManageType.Character:
			list = CharacterHandleList;
			break;
		case ManageType.Stage:
			list = StageHandleList;
			break;
		case ManageType.Collection:
			list = CollectionHandleList;
			break;
		case ManageType.StoryRecord:
			list = RecordHandleList;
			break;
		case ManageType.Battle:
			list = BattleHandleList;
			break;
		case ManageType.EachStage:
			list = EachStageList;
			break;
		}
		if (list == null)
		{
			return;
		}
		foreach (AsyncOperationHandle item in list)
		{
			if (item.IsValid())
			{
				Addressables.Release(item);
			}
		}
		list.Clear();
	}

	public static void BattleAllyAssetLoad(BattleAlly Ally, ManageType MType)
	{
		foreach (Skill skill in Ally.Skills)
		{
			SkillDataLoad(skill, MType);
		}
		SkillDataLoad(Ally.BasicSkill, MType);
	}

	public static void BattleEnemyAssetLoad(BattleEnemy Enemy, ManageType MType)
	{
		foreach (Skill skill in Enemy.Skills)
		{
			try
			{
				SkillDataLoad(skill, MType);
			}
			catch
			{
			}
		}
	}

	public static void SkillDataLoad(Skill Myskill, ManageType MType)
	{
		string path = Myskill.MySkill.Particle_Path;
		string path2 = Myskill.MySkill.Image_0_Path;
		string path3 = Myskill.MySkill.Image_1_Path;
		string path4 = Myskill.MySkill.Image_2_Path;
		if (Myskill.Master is BattleAlly)
		{
			string vFXChangePath = CharacterSkinData.GetVFXChangePath(Myskill.Master.Info.KeyData, Myskill.MySkill.KeyID);
			if (!vFXChangePath.IsEmpty())
			{
				path = vFXChangePath;
			}
			string illustChangePath = CharacterSkinData.GetIllustChangePath(Myskill.Master.Info.KeyData, Myskill.MySkill.KeyID, 0);
			string illustChangePath2 = CharacterSkinData.GetIllustChangePath(Myskill.Master.Info.KeyData, Myskill.MySkill.KeyID, 1);
			string illustChangePath3 = CharacterSkinData.GetIllustChangePath(Myskill.Master.Info.KeyData, Myskill.MySkill.KeyID, 2);
			if (!illustChangePath.IsEmpty())
			{
				path2 = illustChangePath;
			}
			if (!illustChangePath2.IsEmpty())
			{
				path3 = illustChangePath2;
			}
			if (!illustChangePath3.IsEmpty())
			{
				path4 = illustChangePath3;
			}
		}
		LoadManagedAsset<GameObject>(path, MType);
		LoadManagedAsset<Sprite>(path2, MType);
		LoadManagedAsset<Sprite>(path3, MType);
		LoadManagedAsset<Sprite>(path4, MType);
		if (Myskill.MySkill.Effect_Target != null && Myskill.MySkill.Effect_Target.Buffs != null)
		{
			foreach (GDEBuffData buff in Myskill.MySkill.Effect_Target.Buffs)
			{
				LoadManagedAsset<Sprite>(buff.Icon_Path, MType);
				LoadManagedAsset<GameObject>(buff.AllyBuffEffect_Path, MType);
				LoadManagedAsset<GameObject>(buff.EnemyBuffEffect_Path, MType);
			}
		}
		if (Myskill.MySkill.Effect_Self != null && Myskill.MySkill.Effect_Self.Buffs != null)
		{
			foreach (GDEBuffData buff2 in Myskill.MySkill.Effect_Self.Buffs)
			{
				LoadManagedAsset<Sprite>(buff2.Icon_Path, MType);
				LoadManagedAsset<GameObject>(buff2.AllyBuffEffect_Path, MType);
				LoadManagedAsset<GameObject>(buff2.EnemyBuffEffect_Path, MType);
			}
		}
		foreach (string item in Myskill.MySkill.SubParticle_Path)
		{
			LoadManagedAsset<GameObject>(item, MType);
		}
	}

	public static void AddPartyAssetLoad(GDECharacterData CData)
	{
		LoadManagedAsset<GameObject>(CData.BattleChar_Path, ManageType.Character);
		foreach (string item in CData.CampSD_Path)
		{
			LoadManagedAsset<Sprite>(item, ManageType.Character);
		}
		AsyncOperationHandle<GameObject> asyncOperationHandle = LoadManagedAsset<GameObject>(CData.Key, ManageType.Character);
		asyncOperationHandle.Completed += delegate
		{
			AsyncOperationHandle<Sprite> asyncOperationHandle2 = LoadManagedAsset<Sprite>(CData.face_Path, ManageType.Character);
			asyncOperationHandle2.Completed += delegate
			{
				AsyncOperationHandle<Sprite> asyncOperationHandle3 = LoadManagedAsset<Sprite>(CData.Face_NoGlass_Path, ManageType.Character);
				asyncOperationHandle3.Completed += delegate
				{
					AsyncOperationHandle<Sprite> asyncOperationHandle5 = LoadManagedAsset<Sprite>(CData.Illust_NoGlass_Path, ManageType.Character);
					asyncOperationHandle5.Completed += delegate
					{
						AsyncOperationHandle<GameObject> asyncOperationHandle7 = LoadManagedAsset<GameObject>(CData.FaceOriginChar_Path, ManageType.Character);
						asyncOperationHandle7.Completed += delegate
						{
							LoadManagedAsset<Sprite>(CData.PassiveIcon_Path, ManageType.Character);
						};
					};
				};
			};
		};
	}

	public static AsyncOperationHandle<T> LoadManagedAsset<T>(string path, ManageType Mtype)
	{
		if (string.IsNullOrEmpty(path))
		{
			return Addressables.ResourceManager.CreateCompletedOperation(default(T), "");
		}
		AsyncOperationHandle<T> asyncOperationHandle = Addressables.LoadAssetAsync<T>(path);
		HandleAdd(Mtype, asyncOperationHandle);
		return asyncOperationHandle;
	}

	private static AsyncOperationHandle<IList<T>> LoadManagedAssets<T>(string path, ManageType Mtype)
	{
		if (string.IsNullOrEmpty(path))
		{
			return Addressables.ResourceManager.CreateCompletedOperation<IList<T>>(null, "");
		}
		AsyncOperationHandle<IList<T>> asyncOperationHandle = Addressables.LoadAssetsAsync<T>(path, null);
		HandleAdd(Mtype, asyncOperationHandle);
		return asyncOperationHandle;
	}

	public static void StageAssetLoad(GDEStageData SData)
	{
		int stageNum = PlayData.TSavedata.StageNum;
		int num = 0;
		if (SData.Key == GDEItemKeys.Stage_Stage1_1 || SData.Key == GDEItemKeys.Stage_Stage1_2)
		{
			num = 1;
		}
		if (SData.Key == GDEItemKeys.Stage_Stage2_1 || SData.Key == GDEItemKeys.Stage_Stage2_2)
		{
			num = 2;
		}
		if (SData.Key == GDEItemKeys.Stage_Stage3)
		{
			num = 3;
		}
		if (SData.Key == GDEItemKeys.Stage_Stage4)
		{
			num = 4;
		}
		if (SData.Key == GDEItemKeys.Stage_Stage_Crimson || SData.Key == GDEItemKeys.Stage_Stage_Crimson_2)
		{
			num = 5;
		}
		UnloadAddressableData(ManageType.EachStage);
		if (stageNum != 0 && stageNum != 3)
		{
			UnloadAddressableData(ManageType.Stage);
			UnloadAddressableData(ManageType.Collection);
			List<GDEEnemyData> list = new List<GDEEnemyData>();
			if (MonsterKey == null)
			{
				MonsterKey = new List<string>();
				GDEDataManager.GetAllDataKeysBySchema(GDESchemaKeys.Enemy, out MonsterKey);
			}
			foreach (string item in MonsterKey)
			{
				GDEEnemyData gDEEnemyData = new GDEEnemyData(item);
				if (gDEEnemyData.CollactionEnemy == num)
				{
					list.Add(gDEEnemyData);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				LoadManagedAssets<GameObject>(list[i].BattleObject_Path, ManageType.Stage);
				LoadManagedAssets<GameObject>(list[i].Face_Path, ManageType.Stage);
				for (int j = 0; j < list[i].Skills.Count; j++)
				{
					LoadManagedAssets<GameObject>(list[i].Skills[j].Particle_Path, ManageType.Stage);
					LoadManagedAssets<Sprite>(list[i].Skills[j].Image_0_Path, ManageType.Stage);
					LoadManagedAssets<Sprite>(list[i].Skills[j].Image_1_Path, ManageType.Stage);
					LoadManagedAssets<Sprite>(list[i].Skills[j].Image_2_Path, ManageType.Stage);
					for (int k = 0; k < list[i].Skills[j].SubParticle_Path.Count; k++)
					{
						if (!string.IsNullOrEmpty(list[i].Skills[j].SubParticle_Path[k]))
						{
							LoadManagedAssets<GameObject>(list[i].Skills[j].SubParticle_Path[k], ManageType.Stage);
						}
					}
				}
			}
			LoadManagedAsset<GameObject>(SData.Tile_Iso_Path, ManageType.Stage);
			LoadManagedAsset<GameObject>(SData.StageEffect_Path, ManageType.Stage);
			LoadManagedAsset<GameObject>(SData.BattleMap.MapPrefab_Path, ManageType.Stage);
		}
		foreach (GDERandomEventData randomEvent in SData.RandomEventList)
		{
			if (randomEvent == null || (string.IsNullOrEmpty(randomEvent.EventFieldObject_Path) && string.IsNullOrEmpty(randomEvent.EventFieldObject_2Stage_Path) && string.IsNullOrEmpty(randomEvent.EventFieldObject_3Stage_Path)))
			{
				continue;
			}
			switch (stageNum)
			{
			case 0:
			case 1:
				LoadManagedAsset<GameObject>(randomEvent.EventFieldObject_Path, ManageType.Stage);
				LoadManagedAsset<Sprite>(randomEvent.MainImage_Path, ManageType.Stage);
				break;
			case 2:
			case 3:
				if (!string.IsNullOrEmpty(randomEvent.EventFieldObject_2Stage_Path))
				{
					LoadManagedAsset<GameObject>(randomEvent.EventFieldObject_2Stage_Path, ManageType.Stage);
					LoadManagedAsset<Sprite>(randomEvent.MainImage_2Stage_Path, ManageType.Stage);
				}
				else
				{
					LoadManagedAsset<GameObject>(randomEvent.EventFieldObject_Path, ManageType.Stage);
					LoadManagedAsset<Sprite>(randomEvent.MainImage_Path, ManageType.Stage);
				}
				break;
			case 4:
				if (!string.IsNullOrEmpty(randomEvent.EventFieldObject_2Stage_Path))
				{
					LoadManagedAsset<GameObject>(randomEvent.EventFieldObject_3Stage_Path, ManageType.Stage);
					LoadManagedAsset<Sprite>(randomEvent.MainImage_3Stage_Path, ManageType.Stage);
				}
				else
				{
					LoadManagedAsset<GameObject>(randomEvent.EventFieldObject_Path, ManageType.Stage);
					LoadManagedAsset<Sprite>(randomEvent.MainImage_Path, ManageType.Stage);
				}
				break;
			}
		}
		foreach (GDEFieldObjectData item2 in SData.EventObject_L)
		{
			if (item2 == null || (string.IsNullOrEmpty(item2.Object_Path) && string.IsNullOrEmpty(item2.Object2_Path) && string.IsNullOrEmpty(item2.Object3_Path) && string.IsNullOrEmpty(item2.Object4_Path)))
			{
				continue;
			}
			switch (stageNum)
			{
			case 0:
			case 1:
				LoadManagedAsset<GameObject>(item2.Object_Path, ManageType.Stage);
				break;
			case 2:
			case 3:
				if (!string.IsNullOrEmpty(item2.Object2_Path))
				{
					LoadManagedAsset<GameObject>(item2.Object2_Path, ManageType.Stage);
				}
				else
				{
					LoadManagedAsset<GameObject>(item2.Object_Path, ManageType.Stage);
				}
				break;
			case 4:
				if (!string.IsNullOrEmpty(item2.Object2_Path))
				{
					LoadManagedAsset<GameObject>(item2.Object3_Path, ManageType.Stage);
				}
				else
				{
					LoadManagedAsset<GameObject>(item2.Object_Path, ManageType.Stage);
				}
				break;
			default:
				if (!string.IsNullOrEmpty(item2.Object2_Path))
				{
					LoadManagedAsset<GameObject>(item2.Object4_Path, ManageType.Stage);
				}
				else
				{
					LoadManagedAsset<GameObject>(item2.Object_Path, ManageType.Stage);
				}
				break;
			}
		}
		foreach (GDEFieldObjectData eventObject_ in SData.EventObject_S)
		{
			if (eventObject_ == null || (string.IsNullOrEmpty(eventObject_.Object_Path) && string.IsNullOrEmpty(eventObject_.Object2_Path) && string.IsNullOrEmpty(eventObject_.Object3_Path) && string.IsNullOrEmpty(eventObject_.Object4_Path)))
			{
				continue;
			}
			switch (stageNum)
			{
			case 0:
			case 1:
				LoadManagedAsset<GameObject>(eventObject_.Object_Path, ManageType.Stage);
				break;
			case 2:
			case 3:
				if (!string.IsNullOrEmpty(eventObject_.Object2_Path))
				{
					LoadManagedAsset<GameObject>(eventObject_.Object2_Path, ManageType.Stage);
				}
				else
				{
					LoadManagedAsset<GameObject>(eventObject_.Object_Path, ManageType.Stage);
				}
				break;
			case 4:
				if (!string.IsNullOrEmpty(eventObject_.Object2_Path))
				{
					LoadManagedAsset<GameObject>(eventObject_.Object3_Path, ManageType.Stage);
				}
				else
				{
					LoadManagedAsset<GameObject>(eventObject_.Object_Path, ManageType.Stage);
				}
				break;
			default:
				if (!string.IsNullOrEmpty(eventObject_.Object2_Path))
				{
					LoadManagedAsset<GameObject>(eventObject_.Object4_Path, ManageType.Stage);
				}
				else
				{
					LoadManagedAsset<GameObject>(eventObject_.Object_Path, ManageType.Stage);
				}
				break;
			}
		}
		switch (stageNum)
		{
		case 0:
		case 1:
			if (!string.IsNullOrEmpty(SData.FixedObject.Object_Path))
			{
				LoadManagedAsset<GameObject>(SData.FixedObject.Object_Path, ManageType.Stage);
			}
			break;
		case 2:
		case 3:
			if (!string.IsNullOrEmpty(SData.FixedObject.Object2_Path))
			{
				LoadManagedAsset<GameObject>(SData.FixedObject.Object2_Path, ManageType.Stage);
			}
			else if (!string.IsNullOrEmpty(SData.FixedObject.Object_Path))
			{
				LoadManagedAsset<GameObject>(SData.FixedObject.Object_Path, ManageType.Stage);
			}
			break;
		case 4:
			if (!string.IsNullOrEmpty(SData.FixedObject.Object3_Path))
			{
				LoadManagedAsset<GameObject>(SData.FixedObject.Object3_Path, ManageType.Stage);
			}
			else if (!string.IsNullOrEmpty(SData.FixedObject.Object_Path))
			{
				LoadManagedAsset<GameObject>(SData.FixedObject.Object_Path, ManageType.Stage);
			}
			break;
		default:
			if (!string.IsNullOrEmpty(SData.FixedObject.Object4_Path))
			{
				LoadManagedAsset<GameObject>(SData.FixedObject.Object4_Path, ManageType.Stage);
			}
			else if (!string.IsNullOrEmpty(SData.FixedObject.Object_Path))
			{
				LoadManagedAsset<GameObject>(SData.FixedObject.Object_Path, ManageType.Stage);
			}
			break;
		}
	}
}
You are not using the latest version of the tool, please update.
Latest version is '11.1.0.9782' (yours is '9.1.0.7988')
