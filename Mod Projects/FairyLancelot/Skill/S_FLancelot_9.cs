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
namespace FairyLancelot
{
	/// <summary>
	/// 终焉
	/// 湖光骑士 - 使用该技能后，记录本回合使用的技能次数。回合结束时，每使用 1 个技能，对随机敌人造成 5 点伤害。
	/// 幻想种 - 额外造成 &a 伤害(攻击力的30%)。击杀敌人时，使所有友军获得持续 3 回合的“攻击力+1”。
	/// </summary>
    public class S_FLancelot_9:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_FLancelot_Rare_1"))
            {
                this.BChar.BuffAdd("B_FLancelot_9_0", this.BChar);
            }
            if (this.BChar.BuffFind("B_FLancelot_Rare_2"))
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.3);
            }
        }

        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);
            if (this.BChar.BuffFind("B_FLancelot_Rare_2"))
            {
                foreach (BattleChar bc in BattleSystem.instance.AllyList)
                {
                    bc.BuffAdd("B_FLancelot_9_1", this.BChar);
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.3f)).ToString());
        }
    }
}