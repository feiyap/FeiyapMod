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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 水符「湖葬」
	/// 如果目标无法受到治疗，则改为使目标的生命值提升 &a 点(治疗力的130%)。
	/// 每个等级的“水”使这个技能额外治疗或提升&a点体力(治疗力的20%)。
	/// </summary>
    public class S_Pachi_Sk_2_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (BattleChar bc in Targets)
            {
                if (bc.GetStat.CantHeal)
                {
                    bc.HP += (int)(this.BChar.GetStat.reg * 1.3f + (int)(this.BChar.GetStat.reg * (0.2 * BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[2])));
                }
            }

            this.SkillBasePlus.Target_BaseHeal = (int)(this.BChar.GetStat.reg * (0.2 * BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[2]));
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.reg * 1.3f)).ToString())
                                          .Replace("&b", ((int)(this.BChar.GetStat.reg * 0.2f)).ToString());
        }
    }
}