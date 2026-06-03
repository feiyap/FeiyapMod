using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using I2.Loc;
using DarkTonic.MasterAudio;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using Debug = UnityEngine.Debug;
using ChronoArkMod.ModData;
using HarmonyLib;
using UnityEngine.Events;

namespace DiffcultSystem
{
    class EndorphinRelic
    {
        //游戏开始时添加内啡肽
        [HarmonyPatch(typeof(FieldSystem))]
        class FieldSystem_Patch
        {
            [HarmonyPostfix]
            [HarmonyPatch(nameof(FieldSystem.StageStart))]
            static void StageStartPostfix()
            {
                 EndorphinSave.SetEndorphinPassive();
            }
        }

        //注册点击事件
        [HarmonyPatch(typeof(ArkItemView))]
        class ArkItemView_Patch
        {
            [HarmonyPostfix]
            [HarmonyPatch(nameof(ArkItemView.Init))]
            static void InitPostfix(ArkItemView __instance)
            {
                if (__instance.Item.itemkey == "Endorphin")
                {
                    if (__instance.gameObject?.GetComponent<Button>() == null)
                    {
                        Button button = __instance.gameObject.AddComponent<Button>();
                        button.onClick.AddListener(new UnityAction(EndorphinRelic.Call));
                    }
                    else
                    {
                        Button button = __instance.gameObject.GetComponent<Button>();
                        button.onClick.RemoveAllListeners();
                        button.onClick.AddListener(new UnityAction(EndorphinRelic.Call));
                    }
                }
            }
        }

        //点击事件
        public static void Call()
        {
            SelectItemUI component = UIManager.InstantiateActive(UIManager.inst.SelectItemUI).GetComponent<SelectItemUI>();
            List<ItemBase> list = new List<ItemBase>();
            foreach (string str in endorphinList)
            {
                list.Add(ItemBase.GetItem(str, 1));
            }
            component.Init(list, new RandomItemBtn.SelectItemClickDel(setEndorphinUpdate), true);
        }

        //更新内啡肽状态
        public static void setEndorphinUpdate(ItemBase item)
        {
            if (EndorphinSave.Instance.endorphinActiveList.Find(a => a == item.itemkey) != null)
            {
                EndorphinSave.Instance.endorphinActiveList.Remove(item.itemkey);
                EndorphinSave.Instance.updateEndorphin(item.itemkey, false);
            }
            else
            {
                EndorphinSave.Instance.endorphinActiveList.Add(item.itemkey);
                EndorphinSave.Instance.updateEndorphin(item.itemkey, true);
            }
            
        }

        public static List<string> endorphinList = new List<string>
        {
            "Endorphin_Addicted",    //食髓知味
            "Endorphin_Paranoid",    //疑神疑鬼
            "Endorphin_Sly",         //鬼祟玲珑
            "Endorphin_InlandEmpire",//内陆帝国
            "Endorphin_Mystical",    //天人感应
            "Endorphin_Unified",     //同舟共济
            "Endorphin_Innovative",  //标新立异
            "Endorphin_Composed",    //平心定气
            "Endorphin_Guiding",     //循循善诱
            "Endorphin_Persistent"   //坚韧不拔
        };
    }
}
