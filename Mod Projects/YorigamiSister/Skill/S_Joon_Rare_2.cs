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
namespace YorigamiSister
{
	/// <summary>
	/// 「Queen of Bubble」
	/// 本场战斗中，获得 1 个额外装备栏。
	/// 那之后，依据自身装备的平均品质，将随机装备填满自身装备栏，直到战斗结束。
	/// </summary>
    public class S_Joon_Rare_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            Targets[0].Info.Equip.Add(null);

            int aveQuaility = P_YorigamiJoon.calculateAveEquipQuality(Targets[0]);

            List<ItemBase> list = new List<ItemBase>();
            foreach (ItemBase itemBase in PlayData.ALLITEMLIST)
            {
                if (itemBase is Item_Equip && (itemBase as Item_Equip).ItemClassNum == aveQuaility && !itemBase.GetNoDrop && itemBase.itemkey != GDEItemKeys.Item_Equip_Morph && itemBase.itemkey != GDEItemKeys.Item_Equip_Replica && (!itemBase.GetLock || SaveManager.NowData.unlockList.UnlockItems.Contains(itemBase.itemkey)))
                {
                    string key = (itemBase as Item_Equip).MyData.Key;
                    list.Add(ItemBase.GetItem(key));
                }
            }

            int emptySlotCount = Targets[0].Info.Equip.Count(item => item == null);

            for (int i = 0; i < emptySlotCount; i++)
            {
                BattleSystem.DelayInputAfter(this.After(list[i], Targets[0]));
            }
            
        }

        private IEnumerator After(ItemBase item, BattleChar targetBC)
        {
            yield return new WaitForFixedUpdate();

            int emptyIndex = targetBC.Info.Equip.FindIndex(e => e == null);

            if (emptyIndex != -1)
            {
                targetBC.Info.Equip[emptyIndex] = item;

                if (BattleSystem.instance.GetBattleValue<BV_Joon_TempEquip>() == null)
                {
                    BattleSystem.instance.BattleValues.Add(new BV_Joon_TempEquip());
                }

                BattleSystem.instance.GetBattleValue<BV_Joon_TempEquip>().tempEquipList.Add(targetBC.Info, emptyIndex);
                BattleSystem.instance.GetBattleValue<BV_Joon_TempEquip>().tempSlotList.Add(targetBC.Info, (Item_Equip)item);
            }

            yield break;
        }
    }
}