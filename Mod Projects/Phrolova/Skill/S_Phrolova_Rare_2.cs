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
namespace Phrolova
{
	/// <summary>
	/// “我不会再等了。”
	/// 使&user以外的所有友军阵亡。
	/// 那之后，向牌库中添加所有友军牌组中的技能，并使持有者改为&user。
	/// 使“露西的项链”充能次数填充至 3 层。
	/// </summary>
    public class S_Phrolova_Rare_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (BattleAlly ba in BattleSystem.instance.AllyList)
            {
                if (ba == this.BChar)
                {
                    continue;
                }

                foreach (Skill sk in ba.Skills)
                {
                    Skill tempskill = sk.CloneSkill(true, this.BChar);
                    BattleSystem.instance.AllyTeam.Skills_Deck.Add(tempskill);
                }

                ba.ForceDead();
            }

            foreach (ItemBase itemBase3 in PartyInventory.InvenM.InventoryItems)
            {
                if (itemBase3 != null && (itemBase3.itemkey == GDEItemKeys.Item_Active_LucysNecklace || itemBase3.itemkey == GDEItemKeys.Item_Active_LucysNecklace2 || itemBase3.itemkey == GDEItemKeys.Item_Active_LucysNecklace3 || itemBase3.itemkey == GDEItemKeys.Item_Active_LucysNecklace4))
                {
                    Item_Active item_Active = itemBase3 as Item_Active;
                    int chargeNow = item_Active.ChargeNow;
                    item_Active.ChargeNow = chargeNow + 3;
                }
            }
        }
    }
}