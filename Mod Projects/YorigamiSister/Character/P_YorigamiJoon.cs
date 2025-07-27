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
using EOS;
using EOS.Attributes;
using EOS.Tools;
namespace YorigamiSister
{
	/// <summary>
	/// 依神女苑
	/// Passive:
	/// 使人消耗财产程度的能力 - 每消耗100金币，使自身永久提升1%暴击率和0.5%暴击伤害。
	/// 在篝火处可以消耗1200金币为依神女苑购买额外的装备栏。
	/// 今宵是飘逸的利己主义者 - 使用点金卷轴时，额外获得50%金币。
	/// </summary>
    public class P_YorigamiJoon:Passive_Char, IP_BattleEnd, IP_BattleStart_Ones
    {
        //public static int costGold = 0;
        public static bool isListen = false;

        //初始化，生成CustomValue和Listener
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;

            Debug.Log(PlayData.TSavedata.GetCustomValue<CV_Gold>().costGold);

            if (PlayData.TSavedata.GetCustomValue<CV_Gold>() == null)
            {
                PlayData.TSavedata.AddCustomValue(new CV_Gold());
            }

            Debug.Log(PlayData.TSavedata.GetCustomValue<CV_Gold>().costGold);

            //PlayData.TSavedata.GetCustomValue<CV_Gold>().costGold = 0;

            if (!isListen)
            {
                isListen = true;
                EOSManager.AddListener(new GoldChangeListener());
                EOSManager.AddListener(new MidasListener());
            }
        }

        //战斗开始给自己上暴击率BUFF
        public void BattleStart(BattleSystem Ins)
        {
            this.BChar.BuffAdd("B_Joon_P", this.BChar);
        }

        //战斗结束释放所有临时装备格
        public void BattleEnd()
        {
            if (BattleSystem.instance.GetBattleValue<BV_Joon_TempEquip>() != null)
            {
                Dictionary<Character, Item_Equip> list2 = BattleSystem.instance.GetBattleValue<BV_Joon_TempEquip>().tempSlotList;

                foreach (Character character in list2.Keys)
                {
                    character.Equip.Remove(list2[character]);
                }

                Dictionary<Character, int> list = BattleSystem.instance.GetBattleValue<BV_Joon_TempEquip>().tempEquipList;

                foreach (Character character in list.Keys)
                {
                    character.Equip[list[character]] = null;
                }

                BattleSystem.instance.GetBattleValue<BV_Joon_TempEquip>().tempEquipList.Clear();
                BattleSystem.instance.GetBattleValue<BV_Joon_TempEquip>().tempSlotList.Clear();
            }
        }

        //计算平均装备品质
        public static int calculateAveEquipQuality(BattleChar bc)
        {
            int aveQuality = 0;

            int totalQuality = 0;
            int count = 0;
            foreach (ItemBase eq in bc.Info.Equip)
            {
                if (eq != null)
                {
                    totalQuality += eq.ItemClassNum;
                    count++;
                }
            }

            if (count != 0)
            {
                aveQuality = totalQuality / count;
            }

            return aveQuality;
        }

        //计算装备品质和
        public static int calculateTotalEquipQuality(BattleChar bc)
        {
            int totalQuality = 0;

            foreach (ItemBase eq in bc.Info.Equip)
            {
                if (eq != null)
                {
                    totalQuality += (eq.ItemClassNum + 1);
                }
            }

            return totalQuality;
        }
    }

    public class GoldChangeFunction : IEventListener
    {
        [EventListener(typeof(Gold_Event))]
        public virtual void GoldChange(int num)
        {

        }
    }

    public class GoldChangeListener : GoldChangeFunction
    {
        public override void GoldChange(int num)
        {
            if (num < 0)
            {
                if (PlayData.TSavedata.GetCustomValue<CV_Gold>() == null)
                {
                    PlayData.TSavedata.AddCustomValue(new CV_Gold());
                }
                PlayData.TSavedata.GetCustomValue<CV_Gold>().costGold -= num;
                //P_YorigamiJoon.costGold -= num;
            }
        }
    }

    public class MidasFunction : IEventListener
    {
        [EventListener(typeof(Midas_Event))]
        public virtual void Midas(int num)
        {

        }
    }

    public class MidasListener : MidasFunction
    {
        public override void Midas(int num)
        {
            if (num > 0)
            {
                InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Gold, num / 2));
            }
        }
    }
}