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
namespace Morichika
{
    /// <summary>
    /// 森近霖之助
    /// Passive:
    /// <b>知足不辱的旧货店</b> - 每当使用卷轴时，自身最大体力值 + 1。
    /// <b>判别物品名字和用途程度的能力</b> - 每个区域开始时，获得 1 个“地图制作卷轴”、1 个“鉴定卷轴”、1 个“点金术卷轴”和 1 个“诅咒解除卷轴”。
    /// </summary>
    public class P_Morichika : Passive_Char, IP_ScrollUse, IP_StageStart
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void ScrollUse()
        {
            if (BattleSystem.instance != null)
            {
                this.BChar.Info.OriginStat.maxhp += 1;
            }
            else
            {
                this.MyChar.OriginStat.maxhp += 1;
            }
        }

        public void StageStart()
        {
            List<string> collection = new List<string>();
            GDEDataManager.GetAllDataKeysBySchema(GDESchemaKeys.Item_Scroll, out collection);
            PlayData.TSavedata.IdentifyItems.AddRange(collection);

            List<ItemBase> list = new List<ItemBase>();
            list.Add(ItemBase.GetItem(GDEItemKeys.Item_Scroll_Scroll_Mapping, 1));
            list.Add(ItemBase.GetItem(GDEItemKeys.Item_Scroll_Scroll_Identify, 1));
            list.Add(ItemBase.GetItem(GDEItemKeys.Item_Scroll_Scroll_Uncurse, 1));
            list.Add(ItemBase.GetItem(GDEItemKeys.Item_Scroll_Scroll_Midas, 1));

            InventoryManager.Reward(list);
        }
    }
}