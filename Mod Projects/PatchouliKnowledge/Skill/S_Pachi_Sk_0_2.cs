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
	/// 金水符「水银之毒」
	/// 每个等级的“水”使这个技能额外治疗&a点体力(治疗力的10%)。
    /// 每个等级的“金”额外施加1层“生命涌现”。
	/// </summary>
    public class S_Pachi_Sk_0_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.SkillBasePlus.Target_BaseHeal = (int)(this.BChar.GetStat.reg * (0.1 * BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[2]));

            for (int i = 0; i < BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[0]; i++)
            {
                foreach (BattleChar bc in Targets)
                {
                    bc.BuffAdd("B_Pachi_0_2", this.BChar);
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.reg * 0.1f)).ToString());
        }
    }
}