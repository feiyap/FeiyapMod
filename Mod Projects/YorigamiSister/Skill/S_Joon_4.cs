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
	/// 名流燃烧
	/// 如果自身装备栏已满，则额外获得 2 层“拜金主义”。
	/// 否则会根据自身装备的平均品质，展示 3 件随机装备。那之后，可以消耗 200 金币选择并装备其中 1 件装备，直到战斗结束。
	/// </summary>
    public class S_Joon_4:Skill_Extended
    {
        public BattleChar targetBC;

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            bool hasEmptySlot = Targets[0].Info.Equip.Any(item => item == null);
            if (!hasEmptySlot)
            {
                Targets[0].BuffAdd("B_Joon_4", this.BChar);
                Targets[0].BuffAdd("B_Joon_4", this.BChar);
            }
            else
            {
                int aveQuaility = P_YorigamiJoon.calculateAveEquipQuality(Targets[0]);
                
                Debug.Log(aveQuaility);
                //List<ItemBase> list = new List<ItemBase>();
                //HashSet<ItemBase> uniqueEquips = new HashSet<ItemBase>();

                //while (uniqueEquips.Count < 3)
                //{
                //    ItemBase newEquip = ItemBase.GetItem(PlayData.GetEquipRandom(aveQuaility));
                //    uniqueEquips.Add(newEquip); // HashSet会自动去重
                //}

                //list = uniqueEquips.ToList();
                List<ItemBase> list = new List<ItemBase>();
                foreach (ItemBase itemBase in PlayData.ALLITEMLIST)
                {
                    if (itemBase is Item_Equip && (itemBase as Item_Equip).ItemClassNum == aveQuaility && !itemBase.GetNoDrop && itemBase.itemkey != GDEItemKeys.Item_Equip_Morph && itemBase.itemkey != GDEItemKeys.Item_Equip_Replica && (!itemBase.GetLock || SaveManager.NowData.unlockList.UnlockItems.Contains(itemBase.itemkey)))
                    {
                        string key = (itemBase as Item_Equip).MyData.Key;
                        list.Add(ItemBase.GetItem(key));
                    }
                }
                List<ItemBase> list2 = new List<ItemBase>();
                for (int i = 0; i < 3; i++)
                {
                    ItemBase item = list.Random(this.BChar.GetRandomClass().Main);
                    list2.Add(item);
                    list.Remove(item);
                }

                targetBC = Targets[0];
                    
                UIManager.InstantiateActive(UIManager.inst.SelectItemUI).GetComponent<SelectItemUI>().Init(list2, new RandomItemBtn.SelectItemClickDel(this.GetEquipEffect), true);
            }
        }

        private void GetEquipEffect(ItemBase item)
        {
            BattleSystem.DelayInputAfter(this.After(item));
        }

        private IEnumerator After(ItemBase item)
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
            }

            yield break;
        }
    }
}