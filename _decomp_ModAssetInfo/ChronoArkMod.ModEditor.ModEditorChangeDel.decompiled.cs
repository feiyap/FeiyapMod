using System;
using System.Collections.Generic;
using ChronoArkMod.ModData;
using GameDataEditor;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ChronoArkMod.ModEditor;

public class ModEditorChangeDel : ModGDEInfo.GDEChangeDelBase
{
	public string myKey;

	public string myField;

	public Dictionary<string, object> myValues = new Dictionary<string, object>();

	public string MyChangeType;

	[JsonIgnore]
	public ModInfo modInfo;

	public HashSet<string> myKeys = new HashSet<string>();

	[JsonIgnore]
	private object Prepared;

	public override bool Match(string key, string field)
	{
		if (key == myKey || myKeys.Contains(key))
		{
			return field == myField;
		}
		return false;
	}

	public void Init(ModInfo Info)
	{
		modInfo = Info;
		myValues = Json.Deserialize(ModEditorUtil.SerializeJson(myValues)) as Dictionary<string, object>;
		try
		{
			PrePare();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}

	public void InitInEditor(ModEditorInfo modEditorInfo)
	{
		Init(ModManager.getModInfo(modEditorInfo.BasicInfoDict["id"].Value<string>()));
	}

	public void PrePare()
	{
		switch (MyChangeType)
		{
		case "FaceOriginChar":
			Prepared = GetFaceOriginChar();
			break;
		case "FaceSmallChar":
			Prepared = GetFaceSmallChar();
			break;
		case "BattleChar":
			Prepared = GetBattleChar();
			break;
		case "EnemyBattleObject":
			Prepared = GetEnemyBattleObject();
			break;
		case "Face":
			Prepared = GetFaceSmallChar();
			break;
		}
	}

	public override T DelApply<T>(T ori)
	{
		if (Prepared != null)
		{
			return (T)Prepared;
		}
		switch (MyChangeType)
		{
		case "RandomEventInStage":
		{
			if (typeof(T) == typeof(List<string>) && ori is List<string> list4 && myValues.TryGetString("RE_Key", out var value2) && !value2.IsNullOrEmpty() && !list4.Contains(value2))
			{
				list4.Add(value2);
				return (T)(object)list4;
			}
			break;
		}
		case "EnemyQueueInStage":
		{
			if (typeof(T) == typeof(List<string>) && ori is List<string> list3 && myValues.TryGetString("Queue_Key", out var value) && !value.IsNullOrEmpty() && !list3.Contains(value))
			{
				list3.Add(value);
				return (T)(object)list3;
			}
			break;
		}
		case "RandomEventImage":
			if (typeof(T) == typeof(string))
			{
				string text = ori as string;
				if (text.IsNullOrEmpty())
				{
					return ori;
				}
				Vector2 campPivot2 = GetCampPivot(0);
				if (campPivot2 == new Vector2(0.5f, 0.5f))
				{
					return ori;
				}
				return (T)(object)modInfo.assetInfo.ChangeSpritePivot(text, campPivot2);
			}
			break;
		case "CampSD":
		{
			if (!(typeof(T) == typeof(List<string>)) || !(ori is List<string> list))
			{
				break;
			}
			List<string> list2 = new List<string>();
			for (int i = 0; i < list.Count; i++)
			{
				Vector2 campPivot = GetCampPivot(i);
				if (campPivot == new Vector2(0.5f, 0.5f))
				{
					list2.Add(list[i]);
				}
				else
				{
					list2.Add(modInfo.assetInfo.ChangeSpritePivot(list[i], campPivot));
				}
			}
			return (T)(object)list2;
		}
		}
		return ori;
	}

	public Vector2 GetEnemyBattleObjectPosition(string Tag)
	{
		Vector2 value = new Vector2(0.5f, 0.5f);
		if (myValues.ContainsKey(Tag))
		{
			myValues.TryGetVector2(Tag, out value);
		}
		else
		{
			myValues[Tag] = value.ToDictValue();
		}
		return value;
	}

	public Vector2 GetCampPivot(int index)
	{
		Vector2 value = new Vector2(0.5f, 0.5f);
		if (index < 2)
		{
			if (myValues.ContainsKey("pivot01"))
			{
				myValues.TryGetVector2("pivot01", out value);
			}
			else
			{
				myValues["pivot01"] = value.ToDictValue();
			}
		}
		else if (myValues.ContainsKey("pivot23"))
		{
			myValues.TryGetVector2("pivot23", out value);
		}
		else
		{
			myValues["pivot23"] = value.ToDictValue();
		}
		return value;
	}

	public string GetFaceOriginChar()
	{
		if (!myValues.TryGetString("path", out var value))
		{
			value = "";
		}
		string imageKey = modInfo.assetInfo.ImageFromFile(value);
		if (value.IsNullOrEmpty())
		{
			imageKey = "";
		}
		return modInfo.assetInfo.CodeConstuctAsync<GameObject>(modInfo.assetInfo.FaceGameObject(imageKey, default(Vector2), default(Vector2), new Vector2(0.5f, 0.5f)), GetPos);
	}

	public string GetFaceSmallChar()
	{
		if (!myValues.TryGetString("path", out var value))
		{
			value = "";
		}
		string imageKey = modInfo.assetInfo.ImageFromFile(value);
		if (value.IsNullOrEmpty())
		{
			imageKey = "";
		}
		return modInfo.assetInfo.CodeConstuctAsync<GameObject>(modInfo.assetInfo.SmallFaceGameObject(imageKey, default(Vector2), default(Vector2), new Vector2(0.5f, 0.5f)), GetPos);
	}

	public string GetBattleChar()
	{
		if (!myValues.TryGetString("path", out var value))
		{
			value = "";
		}
		string imageKey = modInfo.assetInfo.ImageFromFile(value);
		if (value.IsNullOrEmpty())
		{
			imageKey = "";
		}
		return modInfo.assetInfo.CodeConstuctAsync<GameObject>(modInfo.assetInfo.BattleCharGameObject(imageKey, default(Vector2), default(Vector2), new Vector2(0.5f, 0.5f)), GetPos);
	}

	public string GetEnemyBattleObject()
	{
		if (!myValues.TryGetString("path", out var value))
		{
			value = "";
		}
		string text = modInfo.assetInfo.ImageFromFile(value);
		if (value.IsNullOrEmpty())
		{
			text = "";
		}
		if (text.IsNullOrEmpty())
		{
			return null;
		}
		return modInfo.assetInfo.CodeConstuctAsync<GameObject>(modInfo.assetInfo.EnemyGameObject(text, default(Vector2), default(Vector2), default(Vector2)), ChangeEnemyBattleObject);
	}

	public GameObject GetPos(GameObject original)
	{
		try
		{
			if (myValues.ContainsKey("offsetMax") && myValues.ContainsKey("offsetMin") && myValues.ContainsKey("pivot"))
			{
				if (myValues.TryGetVector2("offsetMax", out var value) && myValues.TryGetVector2("offsetMin", out var value2) && myValues.TryGetVector2("pivot", out var value3))
				{
					RectTransform component = original.GetComponent<RectTransform>();
					component.offsetMax = value;
					component.offsetMin = value2;
					component.pivot = value3;
					component.localPosition = Vector3.zero;
				}
			}
			else
			{
				original.GetComponent<Image>().SetNativeSize();
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return original;
	}

	public GameObject ChangeEnemyBattleObject(GameObject original)
	{
		try
		{
			SpriteRenderer component = original.GetComponent<SpriteRenderer>();
			Vector2 enemyBattleObjectPosition = GetEnemyBattleObjectPosition("Pivot");
			component.sprite = Sprite.Create(component.sprite.texture, component.sprite.textureRect, GetEnemyBattleObjectPosition("Pivot"));
			EnemyCustom component2 = original.GetComponent<EnemyCustom>();
			Vector2 vector = component.sprite.textureRect.size / component.sprite.pixelsPerUnit;
			Debug.Log(component.sprite.textureRect.size);
			component2.Head.localPosition = (GetEnemyBattleObjectPosition("Head") - enemyBattleObjectPosition) * vector;
			component2.Center.localPosition = (GetEnemyBattleObjectPosition("Center") - enemyBattleObjectPosition) * vector;
			component2.UI.localPosition = (GetEnemyBattleObjectPosition("UI") - enemyBattleObjectPosition) * vector;
			if (myValues.ContainsKey("Animation"))
			{
				string text = myValues["Animation"].ToString();
				if (!(text == "None"))
				{
					if (text == "Move Up and Down")
					{
						component2.Animation = AddressableLoadManager.LoadAsyncCompletion<AnimationClip>("Assets/ModTheArk/ModEditorV2/Enemy/ModEditor_EnemyBreathe.anim", AddressableLoadManager.ManageType.None);
					}
				}
				else
				{
					component2.Animation = AddressableLoadManager.LoadAsyncCompletion<AnimationClip>("Assets/ModTheArk/ModEditorV2/Enemy/ModEditor_EnemyNone.anim", AddressableLoadManager.ManageType.None);
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return original;
	}
}
