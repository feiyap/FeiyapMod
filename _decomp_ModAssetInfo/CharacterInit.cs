using System;
using System.Collections.Generic;
using System.IO;
using ChronoArkMod.ModData;
using GameDataEditor;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChronoArkMod.ModEditor;

public class CharacterInit : ModEditorSubPanel_Schema
{
	public TextMeshProUGUI KeyID;

	public GameObject Detail;

	public TMP_InputField LoadKeyIDInputField;

	public TMP_InputField NameInputField;

	public TMP_InputField SelectInfoInputField;

	public TMP_Dropdown RoleDropDown;

	public TMP_Dropdown GenderDropDown;

	public Image BattleFaceImage;

	public Image BattleFaceImageBack;

	public string SavedBattleFace;

	public Transform FaceSmallCharShow;

	private GameObject FaceSmallCharGameObject;

	public ImageDrag FaceSmallCharDrag;

	private Sprite FaceSmallCharSprite;

	public string SavedFaceSmallChar;

	public Transform FaceOriginCharShow;

	private GameObject FaceOriginCharGameObject;

	public ImageDrag FaceOriginCharDrag;

	private Sprite FaceOriginCharSprite;

	public string SavedFaceOriginChar;

	public Transform BattleCharShow;

	private GameObject BattleCharGameObject;

	public ImageDrag BattleCharDrag;

	private Sprite BattleCharSprite;

	public string SavedBattleChar;

	public TMP_InputField FirstSkill_MainInputfield;

	public override string SubPanelTitle => "Basic";

	public override bool interactable => base.info != null;

	public override void UpdateInfo()
	{
		base.UpdateInfo();
		try
		{
			if (base.NowKeyID.IsNullOrEmpty())
			{
				KeyID.text = "";
				Detail.SetActive(value: false);
			}
			else
			{
				KeyID.text = base.NowKeyID;
				Detail.SetActive(value: true);
				NameInputField.text = (base.Main_Schema.Get("name", includeGame: true) as JValue)?.Value<string>();
				SelectInfoInputField.text = (base.Main_Schema.Get("SelectInfo", includeGame: true) as JValue)?.Value<string>();
				if (FaceSmallCharGameObject == null || FaceSmallCharSprite == null)
				{
					if (FaceSmallCharGameObject != null)
					{
						UnityEngine.Object.Destroy(FaceSmallCharGameObject);
					}
					string text = (base.Main_Schema.Get("FaceSmallChar", includeGame: true) as JValue)?.Value<string>();
					string text2 = "";
					ModEditorChangeDel del = base.info.GetDel(base.NowKeyID, "FaceSmallChar");
					if (del != null)
					{
						text2 = del.DelApply(text);
					}
					if (!text2.IsNullOrEmpty())
					{
						text = text2;
					}
					if (!text.IsNullOrEmpty())
					{
						FaceSmallCharGameObject = UnityEngine.Object.Instantiate(AddressableLoadManager.LoadAsyncCompletion<GameObject>(text, AddressableLoadManager.ManageType.None));
						FaceSmallCharGameObject.transform.SetParent(FaceSmallCharShow, worldPositionStays: false);
						FaceSmallCharDrag.m_rt = FaceSmallCharGameObject?.GetComponent<RectTransform>();
						if (FaceSmallCharSprite != null)
						{
							FaceSmallCharGameObject.GetComponent<Image>().sprite = FaceSmallCharSprite;
						}
						FaceSmallCharGameObject.GetComponent<Image>().SetNativeSize();
						FaceSmallCharSprite = FaceSmallCharGameObject.GetComponent<Image>().sprite;
					}
				}
				base.info.GetDel(base.NowKeyID, "FaceSmallChar")?.GetPos(FaceSmallCharGameObject);
				if (FaceOriginCharGameObject == null || FaceOriginCharSprite == null)
				{
					if (FaceOriginCharGameObject != null)
					{
						UnityEngine.Object.Destroy(FaceOriginCharGameObject);
					}
					string text3 = (base.Main_Schema.Get("FaceOriginChar", includeGame: true) as JValue)?.Value<string>();
					string text4 = "";
					ModEditorChangeDel del2 = base.info.GetDel(base.NowKeyID, "FaceOriginChar");
					if (del2 != null)
					{
						text4 = del2.DelApply(text3);
					}
					if (!text4.IsNullOrEmpty())
					{
						text3 = text4;
					}
					if (!text3.IsNullOrEmpty())
					{
						FaceOriginCharGameObject = UnityEngine.Object.Instantiate(AddressableLoadManager.LoadAsyncCompletion<GameObject>(text3, AddressableLoadManager.ManageType.None));
						FaceOriginCharGameObject.transform.SetParent(FaceOriginCharShow, worldPositionStays: false);
						FaceOriginCharDrag.m_rt = FaceOriginCharGameObject?.GetComponent<RectTransform>();
						if (FaceOriginCharSprite != null)
						{
							FaceOriginCharGameObject.GetComponent<Image>().sprite = FaceOriginCharSprite;
						}
						FaceOriginCharGameObject.GetComponent<Image>().SetNativeSize();
						FaceOriginCharSprite = FaceOriginCharGameObject.GetComponent<Image>().sprite;
					}
				}
				base.info.GetDel(base.NowKeyID, "FaceOriginChar")?.GetPos(FaceOriginCharGameObject);
				if (BattleCharGameObject == null || BattleCharSprite == null)
				{
					if (BattleCharGameObject != null)
					{
						UnityEngine.Object.Destroy(BattleCharGameObject);
					}
					string text5 = (base.Main_Schema.Get("BattleChar", includeGame: true) as JValue)?.Value<string>();
					string text6 = "";
					ModEditorChangeDel del3 = base.info.GetDel(base.NowKeyID, "BattleChar");
					if (del3 != null)
					{
						text6 = del3.DelApply(text5);
					}
					if (!text6.IsNullOrEmpty())
					{
						text5 = text6;
					}
					if (!text5.IsNullOrEmpty())
					{
						BattleCharGameObject = UnityEngine.Object.Instantiate(AddressableLoadManager.LoadAsyncCompletion<GameObject>(text5, AddressableLoadManager.ManageType.None));
						BattleCharGameObject.transform.SetParent(BattleCharShow, worldPositionStays: false);
						BattleCharDrag.m_rt = BattleCharGameObject?.GetComponent<RectTransform>();
						if (BattleCharSprite != null)
						{
							BattleCharGameObject.GetComponent<Image>().sprite = BattleCharSprite;
						}
						BattleCharGameObject.GetComponent<Image>().SetNativeSize();
						BattleCharSprite = BattleCharGameObject.GetComponent<Image>().sprite;
					}
				}
				base.info.GetDel(base.NowKeyID, "BattleChar")?.GetPos(BattleCharGameObject);
				RoleDropDown.ClearOptions();
				RoleDropDown.AddOptions(ModEditorInfo.GetGameKey(GDESchemaKeys.CharRole));
				int value = RoleDropDown.options.FindIndex((TMP_Dropdown.OptionData o) => o.text == (base.Main_Schema.Get("Role", includeGame: true) as JValue)?.Value<string>());
				RoleDropDown.value = value;
				if (BattleFaceImage.sprite == null)
				{
					string text7 = (base.Main_Schema.Get("face", includeGame: true) as JValue)?.Value<string>();
					if (!text7.IsNullOrEmpty())
					{
						Sprite sprite = AddressableLoadManager.LoadAsyncCompletion<Sprite>(text7, AddressableLoadManager.ManageType.None);
						if (sprite != null)
						{
							BattleFaceImage.sprite = sprite;
							BattleFaceImageBack.sprite = sprite;
						}
						else
						{
							BattleFaceImage.sprite = Misc.CreatSprite(AssetGeneratingTools.LoadTexture(Path.Combine(base.info.DirectoryPath, "Assets", text7)));
							BattleFaceImageBack.sprite = Misc.CreatSprite(AssetGeneratingTools.LoadTexture(Path.Combine(base.info.DirectoryPath, "Assets", text7)));
						}
					}
				}
				GenderDropDown.ClearOptions();
				GenderDropDown.AddOptions(new List<string> { "Male", "Female", "Phoenix" });
				int value2 = (base.Main_Schema.Get("Gender", includeGame: true) as JValue)?.Value<int>() ?? 0;
				GenderDropDown.value = value2;
				FirstSkill_MainInputfield.text = (base.Main_Schema.Get("FirstSkill", includeGame: true) as JValue)?.Value<string>();
				if (FirstSkill_MainInputfield.text.IsNullOrEmpty())
				{
					FirstSkill_MainInputfield.text = "null";
				}
			}
			LoadKeyIDInputField.text = "";
			FaceSmallCharDrag.onValueChange = FaceSmallCharPositionChange;
			FaceOriginCharDrag.onValueChange = FaceOriginCharPositionChange;
			BattleCharDrag.onValueChange = BattleCharPositionChange;
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}

	public override void ClearInfo()
	{
		base.ClearInfo();
		KeyID.text = "";
		Detail.SetActive(value: false);
		NameInputField.text = "";
		BattleFaceImage.sprite = null;
		BattleFaceImageBack.sprite = null;
		SavedBattleFace = "";
		UnityEngine.Object.Destroy(FaceSmallCharGameObject);
		FaceSmallCharGameObject = null;
		FaceSmallCharSprite = null;
		SavedFaceSmallChar = "";
		UnityEngine.Object.Destroy(FaceOriginCharGameObject);
		FaceOriginCharGameObject = null;
		FaceOriginCharSprite = null;
		SavedFaceOriginChar = "";
		UnityEngine.Object.Destroy(BattleCharGameObject);
		BattleCharGameObject = null;
		BattleCharSprite = null;
		SavedBattleChar = "";
	}

	public void LoadButtonClick()
	{
		Load(LoadKeyIDInputField.text);
	}

	public void LoadCharacter_Choose()
	{
		ModEditorV2.instance.ChooseKeyIDUI.Init("Load Character", GDESchemaKeys.Character, delegate(string s)
		{
			LoadKeyIDInputField.text = s;
		}, "name");
	}

	public void NameChange(string NewName)
	{
		ChangeField("name", NewName);
	}

	public void NameDelete()
	{
		DeleteField("name");
	}

	public void SelectInfoChange(string NewSelectInfo)
	{
		ChangeField("SelectInfo", NewSelectInfo);
	}

	public void SelectInfoDelete()
	{
		DeleteField("SelectInfo");
	}

	public void RoleChange(int index)
	{
		string text = RoleDropDown.options[index].text;
		ChangeField("Role", text);
	}

	public void RoleDelete()
	{
		DeleteField("Role");
	}

	public void GenderChange(int index)
	{
		ChangeField("Gender", index);
	}

	public void GenderDelete()
	{
		DeleteField("Gender");
	}

	public void BattleFaceSave()
	{
		if (!SavedBattleFace.IsNullOrEmpty())
		{
			string path = Path.Combine(ModEditorUtil.ValidFileName(base.NowKeyID) + "BattleFace.png");
			string text = Path.Combine(base.info.DirectoryPath, "Assets", ModEditorUtil.ValidFolderName(base.NowKeyID));
			Directory.CreateDirectory(text);
			string dest = Path.Combine(text, path);
			ModEditorUtil.CopyFile(SavedBattleFace, dest, overwrite: true);
		}
	}

	public void BattleFaceChange()
	{
		string text = ModEditorUtil.LoadImage("");
		if (!text.IsNullOrEmpty())
		{
			string text2 = Path.Combine(ModEditorUtil.ValidFolderName(base.NowKeyID), ModEditorUtil.ValidFileName(base.NowKeyID) + "BattleFace.png");
			AddSaveTask("face", text2, text);
			BattleFaceImage.sprite = Misc.CreatSprite(AssetGeneratingTools.LoadTexture(text));
			BattleFaceImageBack.sprite = Misc.CreatSprite(AssetGeneratingTools.LoadTexture(text));
			SavedBattleFace = text;
			ChangeField("face", text2);
		}
	}

	public void BattleFaceDelete()
	{
		DeleteField("face", delegate
		{
			SavedBattleFace = "";
			BattleFaceImage.sprite = null;
			BattleFaceImageBack.sprite = null;
		});
	}

	public static void SaveFaceSmallChar(string SavedFaceSmallChar, string NowKeyID, ModEditorInfo info)
	{
		if (!SavedFaceSmallChar.IsNullOrEmpty())
		{
			ModEditorChangeDel del = info.GetDel(NowKeyID, "FaceSmallChar");
			if (del != null)
			{
				string text = Path.Combine(info.DirectoryPath, "Assets", ModEditorUtil.ValidFolderName(NowKeyID));
				Directory.CreateDirectory(text);
				string path = Path.Combine(ModEditorUtil.ValidFileName(NowKeyID) + "FaceSmallChar.png");
				string dest = Path.Combine(text, path);
				ModEditorUtil.CopyFile(SavedFaceSmallChar, dest, overwrite: true);
				del.myValues["path"] = Path.Combine(ModEditorUtil.ValidFolderName(NowKeyID), path);
			}
		}
	}

	public void FaceSmallCharImageChange()
	{
		string ImagePath = ModEditorUtil.LoadImage("");
		if (!ImagePath.IsNullOrEmpty())
		{
			ModEditorChangeDel del = base.info.GetDel(base.NowKeyID, "FaceSmallChar", Create: true);
			del.MyChangeType = "FaceSmallChar";
			del.myValues.Remove("offsetMax");
			del.myValues.Remove("offsetMin");
			del.myValues.Remove("pivot");
			del.PrePare();
			AddSaveTask("FaceSmallChar", delegate
			{
				SaveFaceSmallChar(ImagePath, base.NowKeyID, base.info);
			});
			del.myValues["path"] = "";
			UnityEngine.Object.Destroy(FaceSmallCharGameObject);
			FaceSmallCharGameObject = null;
			FaceSmallCharSprite = Misc.CreatSprite(AssetGeneratingTools.LoadTexture(ImagePath));
			SavedFaceSmallChar = ImagePath;
			UpdateInfo();
		}
	}

	public void FaceSmallCharPositionChange(Vector2 offsetMax, Vector2 offsetMin, Vector2 pivot)
	{
		ModEditorChangeDel del = base.info.GetDel(base.NowKeyID, "FaceSmallChar");
		if (del != null)
		{
			del.myValues["offsetMax"] = offsetMax.ToDictValue();
			del.myValues["offsetMin"] = offsetMin.ToDictValue();
			del.myValues["pivot"] = pivot.ToDictValue();
		}
		UpdateInfo();
	}

	public void FaceSmallCharDelete()
	{
		base.confirmUI.Init("Delete [" + base.NowKeyID + "] [FaceSmallChar]?", "", delegate
		{
			DeleteFaceOriginChar_NoConfirm();
			UpdateInfo();
		});
	}

	public void DeleteFaceSmallChar_NoConfirm()
	{
		UnityEngine.Object.Destroy(FaceSmallCharGameObject);
		FaceSmallCharGameObject = null;
		FaceSmallCharSprite = null;
		SavedFaceSmallChar = "";
		base.info.DeleteDel(base.NowKeyID, "FaceSmallChar");
	}

	public static void SaveFaceOriginChar(string SavedFaceOriginChar, string NowKeyID, ModEditorInfo info)
	{
		if (!SavedFaceOriginChar.IsNullOrEmpty())
		{
			ModEditorChangeDel del = info.GetDel(NowKeyID, "FaceOriginChar");
			if (del != null)
			{
				string text = Path.Combine(info.DirectoryPath, "Assets", ModEditorUtil.ValidFolderName(NowKeyID));
				Directory.CreateDirectory(text);
				string path = Path.Combine(ModEditorUtil.ValidFileName(NowKeyID) + "FaceOriginChar.png");
				string dest = Path.Combine(text, path);
				ModEditorUtil.CopyFile(SavedFaceOriginChar, dest, overwrite: true);
				del.myValues["path"] = Path.Combine(ModEditorUtil.ValidFolderName(NowKeyID), path);
			}
		}
	}

	public void FaceOriginCharImageChange()
	{
		string ImagePath = ModEditorUtil.LoadImage("");
		if (!ImagePath.IsNullOrEmpty())
		{
			ModEditorChangeDel del = base.info.GetDel(base.NowKeyID, "FaceOriginChar", Create: true);
			del.MyChangeType = "FaceOriginChar";
			del.myValues.Remove("offsetMax");
			del.myValues.Remove("offsetMin");
			del.myValues.Remove("pivot");
			del.PrePare();
			AddSaveTask("FaceOriginChar", delegate
			{
				SaveFaceOriginChar(ImagePath, base.NowKeyID, base.info);
			});
			del.myValues["path"] = "";
			UnityEngine.Object.Destroy(FaceOriginCharGameObject);
			FaceOriginCharGameObject = null;
			SavedFaceOriginChar = ImagePath;
			FaceOriginCharSprite = Misc.CreatSprite(AssetGeneratingTools.LoadTexture(ImagePath));
			UpdateInfo();
		}
	}

	public void FaceOriginCharPositionChange(Vector2 offsetMax, Vector2 offsetMin, Vector2 pivot)
	{
		ModEditorChangeDel del = base.info.GetDel(base.NowKeyID, "FaceOriginChar");
		if (del != null)
		{
			del.myValues["offsetMax"] = offsetMax.ToDictValue();
			del.myValues["offsetMin"] = offsetMin.ToDictValue();
			del.myValues["pivot"] = pivot.ToDictValue();
		}
		UpdateInfo();
	}

	public void FaceOriginCharDelete()
	{
		base.confirmUI.Init("Delete [" + base.NowKeyID + "] [FaceOriginChar]?", "", delegate
		{
			DeleteFaceOriginChar_NoConfirm();
			UpdateInfo();
		});
	}

	public void DeleteFaceOriginChar_NoConfirm()
	{
		UnityEngine.Object.Destroy(FaceOriginCharGameObject);
		FaceOriginCharGameObject = null;
		FaceOriginCharSprite = null;
		SavedFaceOriginChar = "";
		base.info.DeleteDel(base.NowKeyID, "FaceOriginChar");
	}

	public static void SaveBattleChar(string SavedBattleChar, string NowKeyID, ModEditorInfo info)
	{
		if (!SavedBattleChar.IsNullOrEmpty())
		{
			ModEditorChangeDel del = info.GetDel(NowKeyID, "BattleChar");
			if (del != null)
			{
				string text = Path.Combine(info.DirectoryPath, "Assets", ModEditorUtil.ValidFolderName(NowKeyID));
				Directory.CreateDirectory(text);
				string path = Path.Combine(ModEditorUtil.ValidFileName(NowKeyID) + "BattleChar.png");
				string dest = Path.Combine(text, path);
				ModEditorUtil.CopyFile(SavedBattleChar, dest, overwrite: true);
				del.myValues["path"] = Path.Combine(ModEditorUtil.ValidFolderName(NowKeyID), path);
			}
		}
	}

	public void BattleCharImageChange()
	{
		string ImagePath = ModEditorUtil.LoadImage("");
		if (!ImagePath.IsNullOrEmpty())
		{
			ModEditorChangeDel del = base.info.GetDel(base.NowKeyID, "BattleChar", Create: true);
			del.MyChangeType = "BattleChar";
			del.myValues.Remove("offsetMax");
			del.myValues.Remove("offsetMin");
			del.myValues.Remove("pivot");
			del.PrePare();
			AddSaveTask("BattleChar", delegate
			{
				SaveBattleChar(ImagePath, base.NowKeyID, base.info);
			});
			del.myValues["path"] = "";
			UnityEngine.Object.Destroy(BattleCharGameObject);
			BattleCharGameObject = null;
			SavedBattleChar = ImagePath;
			BattleCharSprite = Misc.CreatSprite(AssetGeneratingTools.LoadTexture(ImagePath));
			UpdateInfo();
		}
	}

	public void BattleCharPositionChange(Vector2 offsetMax, Vector2 offsetMin, Vector2 pivot)
	{
		ModEditorChangeDel del = base.info.GetDel(base.NowKeyID, "BattleChar");
		if (del != null)
		{
			del.myValues["offsetMax"] = offsetMax.ToDictValue();
			del.myValues["offsetMin"] = offsetMin.ToDictValue();
			del.myValues["pivot"] = pivot.ToDictValue();
		}
		UpdateInfo();
	}

	public void BattleCharDelete()
	{
		base.confirmUI.Init("Delete [" + base.NowKeyID + "] [BattleChar]?", "", delegate
		{
			DeleteBattleChar_NoConfirm();
			UpdateInfo();
		});
	}

	public void DeleteBattleChar_NoConfirm()
	{
		UnityEngine.Object.Destroy(BattleCharGameObject);
		BattleCharGameObject = null;
		BattleCharSprite = null;
		SavedBattleChar = "";
		base.info.DeleteDel(base.NowKeyID, "BattleChar");
	}

	public void FirstSkill_Choose()
	{
		ModEditorV2.instance.ChooseKeyIDUI.Init("First Skill", GDESchemaKeys.Skill, delegate(string s)
		{
			FirstSkill_MainInputfield.text = s;
			FirstSkillChange(s);
		}, "Name", empty_option: false, null_option: true);
	}

	public void FirstSkillChange(string NewFirstSkill)
	{
		ChangeField("FirstSkill", NewFirstSkill);
	}

	public void FirstSkillDelete()
	{
		DeleteField("FirstSkill");
	}
}
You are not using the latest version of the tool, please update.
Latest version is '11.1.0.9782' (yours is '9.1.0.7988')
