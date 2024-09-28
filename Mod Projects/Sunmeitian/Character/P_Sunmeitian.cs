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
using HarmonyLib;
namespace Sunmeitian
{
    /// <summary>
    /// 孙美天
    /// Passive:
    /// 该被动在1级生效。
    /// 所有装备不会受到诅咒。你可以一直看到清晰的地图。
    /// </summary>
    public class P_Sunmeitian: Passive_Char
    {
        public override void Init()
        {
            Debug.Log("P_Sunmeitian_init");
            base.Init();

            List<string> collection = new List<string>();
            GDEDataManager.GetAllDataKeysBySchema(GDESchemaKeys.Item_Scroll, out collection);
            PlayData.TSavedata.IdentifyItems.AddRange(collection);
        }
    }
}