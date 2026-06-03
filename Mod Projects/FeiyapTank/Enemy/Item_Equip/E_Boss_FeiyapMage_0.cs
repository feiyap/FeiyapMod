using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace FeiyapTank
{
    /// <summary>
    /// 嬉笑魔女的面具
    /// 按顺序交替使用攻击技能和治疗技能，合计33次后，该装备升级为“狂笑魔女的面具”。
    /// </summary>
    public class E_Boss_FeiyapMage_0:EquipBase, IP_SkillUseHand_Team
    {
        public int SkillType = 0; //0:无，1：攻击，2：治疗
        public int count = 0;
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 1;
            this.PlusStat.reg = 1;
            this.PlusStat.def = 1;
            this.PlusStat.maxhp = 1;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", count.ToString());
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master.Info.Ally)
            {
                if (skill.IsHeal)
                {
                    if (SkillType == 1)
                    {
                        count++;
                    }
                    SkillType = 2;
                }
                else if (skill.IsDamage)
                {
                    if (SkillType == 2)
                    {
                        count++;
                    }
                    SkillType = 1;
                }
                else
                {
                    SkillType = 0;
                }
            }

            if (count >= 33)
            {
                int i = 0;
                while (i < this.MyChar.Equip.Count)
                {
                    if (this.MyChar.Equip[i] == this.MyItem)
                    {
                        this.MyChar.Equip[i] = ItemBase.GetItem("E_Boss_FeiyapMage_1");
                        if (!SaveManager.NowData.unlockList.FoundEquip.Contains("E_Boss_FeiyapMage_1"))
                        {
                            SaveManager.NowData.unlockList.FoundEquip.Add("E_Boss_FeiyapMage_1");
                            return;
                        }
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }
    }
}